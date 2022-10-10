using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDeEnemigos : MonoBehaviour
{
    enum enemytype { Peon, Guerrero, Mago, Arquero};
    [SerializeField] enemytype EnemyType;
    [SerializeField] Transform playerTransform;
    public Animator animator;
    public float speed = 0f;

    [SerializeField]
    protected EnemyData enemyData;
    // Start is called before the first frame update
    public bool canrun = false;
    public bool isAtaking = false;
    public bool swordstance = false;
    public bool bowstance = false;
    public bool magestance = false;
    public bool isHit = false;

    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Bow;
    [SerializeField] private GameObject MagicFire;

    public GameObject Bala;
    [SerializeField] public Transform Salidabala;

    public GameObject PowerMagic;
    [SerializeField] public Transform SalidaPowerMagic;

// Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        VerJugador();
        speed = 0f;//enemyData.speed;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", speed);
        swicher();
        animator.SetBool("guerrero", swordstance);
        animator.SetBool("mago", magestance);
        animator.SetBool("arquero", bowstance);
        animator.SetBool("PuedeAtacar", isAtaking);
        animator.SetBool("HitTrue", isHit);
    }

    public void swicher()
    {
        switch (EnemyType)
        {
            case enemytype.Peon:
                swordstance = false;
                magestance = false;
                bowstance = false;
                Sword.gameObject.SetActive (false);
                Bow.gameObject.SetActive (false);
                MagicFire.gameObject.SetActive (false);
                Comportamiento();
                break;
            case enemytype.Guerrero:
                swordstance = true;
                magestance = false;
                bowstance = false;
                Sword.gameObject.SetActive (true);
                Bow.gameObject.SetActive (false);
                MagicFire.gameObject.SetActive (false);
                Comportamiento();
                break;
            case enemytype.Mago:
                swordstance = false;
                magestance = true;
                bowstance = false;
                Sword.gameObject.SetActive (false);
                Bow.gameObject.SetActive (false);
                MagicFire.gameObject.SetActive (true);
                Comportamiento();
                break;
            case enemytype.Arquero:
                swordstance = false;
                magestance = false;
                bowstance = true;
                Sword.gameObject.SetActive (false);
                Bow.gameObject.SetActive (true);
                MagicFire.gameObject.SetActive (false);
                Comportamiento();
                break;
        }
    }

    public void BuscarJugador()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void BuscarSpawn()
    {
        playerTransform = GameObject.FindWithTag("SpawnPoint1").transform;
    }

    public void isAtakingOFF()
    {
        isAtaking = false;
        Debug.Log("isAtakingOFF");
        animator.SetBool("PuedeAtacar", isAtaking);
    }

    private void DisparoFlecha()
    {
        Instantiate(Bala, Salidabala.position, transform.rotation);
    }

    private void tirarpoder()
    {
        Instantiate(PowerMagic, SalidaPowerMagic.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {   
            isHit = true;
            Debug.Log("Danio");
        }
    }

    public void hitoff()
    {
        isHit = false;
    }

    public void VerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }
    public void NoVerJugador()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position + transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }

    public void Comportamiento()
    {
        Vector3 direction = (playerTransform.position - transform.position);
        if (EnemyType == enemytype.Guerrero)
        {
            if ((direction.magnitude > 1.5f)  && (direction.magnitude < 5f))
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
        }
        //----------------------Arquero mago--------------------------
        if ((EnemyType == enemytype.Arquero) || (EnemyType == enemytype.Mago))
        {
            if ((direction.magnitude >5.5f)  && (direction.magnitude < 10f))
            {   isAtaking = true;
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
}
