using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class LogicaDeEnemigos : MonoBehaviour
{
    enum enemytype
    {
        Peon,
        Guerrero,
        Mago,
        Arquero
    };

    [SerializeField]
    enemytype EnemyType;

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    SpawnPotion SpawnPotion;
    public Animator animator;
    public float speed = 0f;

    [SerializeField]
    protected EnemyData enemyData;
    public bool canrun = false;
    public bool isAtaking = false;
    public bool swordstance = false;
    public bool bowstance = false;
    public bool magestance = false;
    public bool isHit = false;
    public bool Defeat = false;
    public bool spawnitem = false;
    public float eliminaral = 5;

    public float vida = 100f;

    [SerializeField]
    private GameObject Sword;

    [SerializeField]
    private GameObject Bow;

    [SerializeField]
    private GameObject MagicFire;

    public GameObject Bala;

    [SerializeField]
    public Transform Salidabala;

    public GameObject PowerMagic;

    [SerializeField]
    public Transform SalidaPowerMagic;

    // Tomamos el start la animacion y buscamos el jugador por el mapa para poder luego mirarlo
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        VerJugador();
        speed = 0f;
    }

    //Avisamos en update al animator sobre los cambios de estado del enemigo para cambiar animaciones
    void Update()
    {
        idle();
        animator.SetFloat("speed", speed);
        swicher();
        Muerte();
        animator.SetBool("guerrero", swordstance);
        animator.SetBool("mago", magestance);
        animator.SetBool("arquero", bowstance);
        animator.SetBool("PuedeAtacar", isAtaking);
        animator.SetBool("HitTrue", isHit);
        animator.SetBool("Defeat", Defeat);
    }

    //Dependiendo del tipo de enemigo son los estados que se activan
    public void swicher()
    {
        switch (EnemyType)
        {
            case enemytype.Peon:
                swordstance = false;
                magestance = false;
                bowstance = false;
                Sword.gameObject.SetActive(false);
                Bow.gameObject.SetActive(false);
                MagicFire.gameObject.SetActive(false);
                Comportamiento();
                break;
            case enemytype.Guerrero:
                swordstance = true;
                magestance = false;
                bowstance = false;
                Sword.gameObject.SetActive(true);
                Bow.gameObject.SetActive(false);
                MagicFire.gameObject.SetActive(false);
                Comportamiento();
                break;
            case enemytype.Mago:
                swordstance = false;
                magestance = true;
                bowstance = false;
                Sword.gameObject.SetActive(false);
                Bow.gameObject.SetActive(false);
                MagicFire.gameObject.SetActive(true);
                Comportamiento();
                break;
            case enemytype.Arquero:
                swordstance = false;
                magestance = false;
                bowstance = true;
                Sword.gameObject.SetActive(false);
                Bow.gameObject.SetActive(true);
                MagicFire.gameObject.SetActive(false);
                Comportamiento();
                break;
        }
    }

    // codigo para poder buscar al jugador
    public void BuscarJugador()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void BuscarSpawn()
    {
        playerTransform = GameObject.FindWithTag("SpawnPoint1").transform;
    }

    //evento para el animatr
    public void isAtakingOFF()
    {
        isAtaking = false;
        Debug.Log("isAtakingOFF");
        animator.SetBool("PuedeAtacar", isAtaking);
    }

    //Instanciar la flecha
    private void DisparoFlecha()
    {
        Instantiate(Bala, Salidabala.position, transform.rotation);
    }

    //evento para avisar en animator
    private void tirarpoder()
    {
        Instantiate(PowerMagic, SalidaPowerMagic.position, transform.rotation);
    }

    // al chocar con la bala del jugador se le quita 20 puntos de vida al enemigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            isHit = true;
            Debug.Log("Danio");
            vida = vida - 20;
        }
    }

    //evento para avisar al animator
    public void hitoff()
    {
        isHit = false;
    }

    // girar para ver al jugador
    public void VerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(
            playerTransform.position - transform.position
        );
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            newRotation,
            1.5f * Time.deltaTime
        );
    }

    public void NoVerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(
            playerTransform.position + transform.position
        );
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            newRotation,
            1.5f * Time.deltaTime
        );
    }

    // el comportamiento que realiza el enemigo. dependiendo del estado en el que se encuentre, se aleja ataca o se acerca del jugador o queda en estado idle esperando la llegada del mismo
    public void Comportamiento()
    {
        //-----------------------------Guerrero------------------------------- siempre va hacia el jugador
        Vector3 direction = (playerTransform.position - transform.position);
        if (EnemyType == enemytype.Guerrero)
        {
            if ((direction.magnitude > 1.5f) && (direction.magnitude < 5f))
            {
                if (isAtaking == true)
                {
                    speed = 0;
                }
                else
                {
                    speed = 3f;
                }
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
            if (direction.magnitude < 1.5f)
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
                speed = 0f;
                isAtaking = true;
            }
            if (direction.magnitude > 5f)
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
                if (isAtaking == true)
                {
                    speed = 0;
                }
                else
                {
                    speed = 5f;
                }
            }
            VerJugador();
        }
        //----------------------Arquero mago-------------------------- se aleja cuando el jugador se acerca
        if ((EnemyType == enemytype.Arquero) || (EnemyType == enemytype.Mago))
        {
            if ((direction.magnitude > 5.5f) && (direction.magnitude < 10f))
            {
                isAtaking = true;
                speed = 0;
                VerJugador();
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
            if (direction.magnitude <= 5f)
            {
                VerJugador();
                transform.position += direction.normalized * speed * Time.deltaTime;
                speed = -3.5f;
                isAtaking = false;
            }
            if (direction.magnitude > 10f)
            {
                VerJugador();
                transform.position += direction.normalized * speed * Time.deltaTime;
                if (isAtaking == true)
                {
                    speed = 0;
                }
                else
                {
                    speed = 3f;
                }
            }
        }
    }

    //-----------------------------------estado de espera---------------------------------------
    private void idle()
    {
        Vector3 direction = (playerTransform.position - transform.position);
        if ((direction.magnitude < 20f) && (EnemyType == enemytype.Peon))
        {
            VerJugador();
        }
        if ((direction.magnitude < 15f) && (EnemyType == enemytype.Peon))
        {
            Random random = new Random();
            VerJugador();
            Type type = typeof(enemytype);
            Array values = type.GetEnumValues();
            int index = random.Next(values.Length);

            EnemyType = (enemytype)values.GetValue(index);
        }
    }

    // evento de la muerte del enemigo
    private void Muerte()
    {
        if (vida <= 0)
        {
            Defeat = true;
            speed = 0f;
            if (spawnitem == false)
            {
                SpawnPotion.spawnpotion();
                spawnitem = true;
                Destroy(GetComponent<BoxCollider>());
                Destroy(gameObject, 5);
            }
            float time = Time.deltaTime;
        }
    }
}
