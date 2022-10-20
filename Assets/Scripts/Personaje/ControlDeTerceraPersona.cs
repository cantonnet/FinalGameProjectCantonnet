using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class ControlDeTerceraPersona : MonoBehaviour
{
    [SerializeField]
    HudManager HudManager;

    [SerializeField]
    MenuPausa MenuPausa;

    [SerializeField]
    AudioClip[] audioClip;

    [SerializeField]
    SwitchCamera SwitchCamera;
    private AudioSource audiosource;

    private Animator anim;

    public static event Action OnDead;

    public float vida = 100f;
    public float mana = 100f;
    public int municion = 20;
    public bool Defeat = false;

    public float speed = 2.6f;
    float x,
        y,
        z;
    public float rotationspeed = 180f;
    public float lateralspeed = 2.5f;
    public bool canrun = false;
    public bool isaiming = false;
    public bool isAtaking = false;
    public bool swordstance = false;
    public bool bowstance = false;
    public bool magestance = false;
    public bool Combo1 = false;
    public bool Combo2 = false;
    public bool Combo3 = false;
    public bool Combo4 = false;
    public bool Combo5 = false;
    public bool Combo6 = false;
    public bool OnAtaque = false;
    public bool Traslado = false;
    public bool CameraAim = false;
    public bool fixCombo3 = false;
    public bool DamageON = false;
    int indexstance = 0;
    bool eventomoririnvocado = false;

    public bool warrior = false;
    public bool Archer = false;

    public GameObject Bala;

    [SerializeField]
    public Transform Salidabala;

    public GameObject PowerMagic;

    [SerializeField]
    public Transform SalidaPowerMagic;

    private void DisparoFlecha()
    {
        if (municion >= 1)
        {
            Instantiate(Bala, Salidabala.position, transform.rotation);
            municion = municion - 1;
            Debug.Log("Municion = " + municion);
            HudManager.Setammo(municion);
        }
    }

    private void DisparoFireball()
    {
        if (mana >= 15)
        {
            Instantiate(PowerMagic, SalidaPowerMagic.position, transform.rotation);
            mana = mana - 15;
            Debug.Log("Mana = " + mana);
            HudManager.SetMPBar(mana);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AnimationClip clip;
        AnimationEvent evt;
        evt = new AnimationEvent();
        clip = anim.runtimeAnimatorController.animationClips[0];
        clip.AddEvent(evt);
    }

    // Update is called once per frame
    void Update()
    {
        fixhpmp();
        trasladando();
        ataque();
        stances();
        aiming();
        Muerte();
        HudManager.SetStanceImage(indexstance);
        if (isaiming == false)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
        if (isaiming == true)
        {
            x = 0f;
            y = 0f;
        }
        z = Input.GetAxis("Mouse X");

        anim.SetFloat("ValX", x);
        anim.SetFloat("ValY", y);
        anim.SetFloat("Speed", speed);
        anim.SetBool("SwordOn", swordstance);
        anim.SetBool("BowOn", bowstance);
        anim.SetBool("MagicOn", magestance);
        anim.SetBool("Aiming", isaiming);
        anim.SetBool("Combo1ON", Combo1);
        anim.SetBool("Combo2ON", Combo2);
        anim.SetBool("Combo3ON", Combo3);
        anim.SetBool("Combo4ON", Combo4);
        anim.SetBool("Combo5ON", Combo5);
        anim.SetBool("Combo6ON", Combo6);
        anim.SetBool("OnAtaque", OnAtaque);
        anim.SetBool("Defeat", Defeat);
        anim.SetBool("DamageOn", DamageON);
        anim.SetFloat("Municion", municion);

        bool isAtaking = Input.GetMouseButtonDown(0);
        if (isAtaking)
        {
            anim.SetBool("Atacar", true);
        }
        anim.SetBool("Atacar", isAtaking);

        MovePlayer();
        RotatePlayer();
        correr();
    }

    private void trasladaron()
    {
        if (fixCombo3 == false)
        {
            Traslado = true;
            CameraAim = true;
            SwitchCamera.SetAim(CameraAim);
        }
    }

    private void trasladaroff()
    {
        Traslado = false;
        CameraAim = false;
        SwitchCamera.SetAim(CameraAim);
    }

    private void trasladando()
    {
        if (Traslado == true)
        {
            transform.Translate(0, 0, 4 * Time.deltaTime);
        }
    }

    private void MovePlayer()
    {
        transform.Translate(0, 0, y * speed * Time.deltaTime);
        transform.Translate(x * lateralspeed * Time.deltaTime, 0, 0);
    }

    public void RotatePlayer()
    {
        transform.Rotate(0, z * Time.deltaTime * rotationspeed, 0);
    }

    void correr()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canrun = false;
            speed = 2.6f;
            lateralspeed = 2.5f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (OnAtaque == false)
            {
                canrun = true;
                if (
                    (
                        (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                        || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                        || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
                        || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                    )
                )
                {
                    lateralspeed = 3.5f;
                    speed = 3f;
                }
                else
                {
                    lateralspeed = 4.5f;
                    speed = 5f;
                }
            }
        }
    }

    void aiming()
    { //acciones al momento de hacer aiming con el personaje
        if (Input.GetMouseButtonDown(1))
        {
            lateralspeed = 0f;
            speed = 0f;
            isaiming = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            speed = 2.6f;
            lateralspeed = 2.5f;
            isaiming = false;
        }
    }

    void drenarmana()
    //aviso para animator
    {
        mana = mana - 20f;
        Debug.Log("Mana = " + mana);
        HudManager.SetMPBar(mana);
    }

    void stances()
    {
        //Se generan los diferentes pasajes de estado segun las teclas 1, 2 y 3
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (swordstance == true)
            {
                indexstance = 0;
                swordstance = false;
                bowstance = false;
                magestance = false;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
            else
            {
                indexstance = 1;
                swordstance = true;
                bowstance = false;
                magestance = false;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (bowstance == true)
            {
                indexstance = 0;
                swordstance = false;
                bowstance = false;
                magestance = false;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
            else
            {
                indexstance = 2;
                swordstance = false;
                bowstance = true;
                magestance = false;
                HudManager.Setammo(municion);
                SwitchCamera.Setbowstancevalue(bowstance);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (magestance == true)
            {
                indexstance = 0;
                swordstance = false;
                bowstance = false;
                magestance = false;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
            else
            {
                indexstance = 3;
                swordstance = false;
                bowstance = false;
                magestance = true;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
        }
    }

    //---------------------AUDIO---------------------------------------------

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    //Evento del footstep
    private void footstep(AnimationEvent evt)
    {
        if (evt.animatorClipInfo.weight > 0.5)
        {
            AudioClip clip = GetRandomClip();
            audiosource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip()
    { //aviso para tomar clips de audio de forma aleatoria
        int index = Random.Range(0, audioClip.Length - 1);
        return audioClip[index];
    }

    private void footrun()
    { //aviso para animator para generar audio en los pasos al caminar
        AudioClip clip = GetRandomClip();
        audiosource.PlayOneShot(clip);
    }

    private void walkrun()
    { //aviso para animator para generar audio en los pasos al correr
        AudioClip clip = GetRandomClip();
        audiosource.PlayOneShot(clip);
    }

    //------------------------------------------------------------------------Conjunto de aviso y eventos para animator para realizar diferentes animaciones----------------------------------------------------------------------
    private void ataque()
    {
        if ((swordstance == true) || (magestance == true))
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnAtaque = true;
                lateralspeed = 0f;
                speed = 0f;
                if (Combo1 == true)
                {
                    Combo2 = true;
                }
                if (Combo4 == true)
                {
                    Combo3 = true;
                }
                if (Combo5 == true)
                {
                    Combo6 = true;
                }
            }
        }
    }

    private void ataqueoff()
    {
        if (Combo2 == false)
        {
            OnAtaque = false;
            speed = 2.6f;
            lateralspeed = 2.5f;
        }
    }

    private void combo1on()
    {
        Combo1 = true;
    }

    private void combo1off()
    {
        Combo1 = false;
    }

    private void ataque2off()
    {
        Combo2 = false;
    }

    private void combo4on()
    {
        Combo4 = true;
    }

    private void combo4off()
    {
        Combo4 = false;
    }

    private void combo3off()
    {
        Combo3 = false;
        Combo4 = false;
        OnAtaque = false;
        Combo2 = false;
        speed = 2.6f;
        lateralspeed = 2.5f;
    }

    private void combo3offmagia()
    {
        Combo3 = false;
    }

    private void fixcombo3()
    {
        fixCombo3 = false;
    }

    private void fixcombo3true()
    {
        fixCombo3 = true;
    }

    private void combo5on()
    {
        Combo5 = true;
    }

    private void combo5off()
    {
        Combo5 = true;
        Combo6 = false;
    }

    private void DamageOn()
    {
        DamageON = true;
    }

    private void DamageOff()
    {
        DamageON = false;
    }

    //-------------------------------------------------------------------------FIN Conjunto de aviso y eventos para animator para realizar diferentes animaciones----------------------------------------------------------------------

    public void Muerte()
    // las acciones al morir el personaje, tambien genera un evento publico para otros scripts
    {
        if (vida <= 0)
        {
            Defeat = true;
            lateralspeed = 0f;
            speed = 0f;
            if (eventomoririnvocado == true)
            {
                ControlDeTerceraPersona.OnDead.Invoke();
                eventomoririnvocado = false;
            }
        }
    }

    //Aviso para animator
    public void AnimationMorir()
    {
        eventomoririnvocado = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Avisoy acciones que se generan al chocar con los diferentes colliders en cuestion
        if (other.gameObject.CompareTag("BalaEnemiga"))
        {
            DamageOn();
            Debug.Log("DanioDeBalaEnemiga");
            if ((isaiming == true) && (swordstance == true))
            {
                vida = vida - 2.5f;
                Debug.Log("vida = " + vida);
                HudManager.SetHPBar(vida);
            }
            if ((isaiming == true) && (magestance == true))
            {
                vida = vida - 0.2f;
                mana = mana - 15f;
                Debug.Log("vida = " + vida);
                HudManager.SetMPBar(mana);
                HudManager.SetHPBar(vida);
            }
            if ((isaiming == false))
            {
                vida = vida - 5f;
                Debug.Log("vida = " + vida);
                HudManager.SetHPBar(vida);
            }
            if (
                (isaiming == false)
                && ((bowstance == true) || (swordstance == true) || (magestance == true))
            )
            {
                vida = vida - 5f;
                Debug.Log("vida = " + vida);
                HudManager.SetHPBar(vida);
            }

            if (
                (isaiming == true)
                && ((bowstance == true) || (swordstance == false) || (magestance == false))
            )
            {
                vida = vida - 5f;
                Debug.Log("vida = " + vida);
                HudManager.SetHPBar(vida);
            }

            if (
                (isaiming == true)
                && ((bowstance == false) || (swordstance == false) || (magestance == false))
            )
            {
                vida = vida - 5f;
                Debug.Log("vida = " + vida);
                HudManager.SetHPBar(vida);
            }
        }
        if (other.gameObject.CompareTag("Trampa"))
        {
            DamageOn();
            vida = 0;
            Debug.Log("vida = " + vida);
            HudManager.SetHPBar(vida);
        }
        if (other.gameObject.CompareTag("ManaPotion"))
        {
            mana = mana + 15f;
            Debug.Log("Mana Actual = " + mana);
            HudManager.SetMPBar(mana);
        }
        if (other.gameObject.CompareTag("HealtPotion"))
        {
            vida = vida + 20f;
            Debug.Log("vida Actual = " + vida);
            HudManager.SetHPBar(vida);
        }
        if (other.gameObject.CompareTag("ArrowPotion"))
        {
            municion = municion + 10;
            Debug.Log("Municion Actual = " + municion);
        }
    }

    void fixhpmp()
    // metodo para fix de vida y mana para que no decaigan de 0 ni sobrepasen el nivel 100
    {
        if (vida >= 101f)
        {
            vida = 100f;
            HudManager.SetHPBar(vida);
        }
        if (vida <= -1f)
        {
            vida = 0f;
            HudManager.SetHPBar(vida);
        }
        if (mana >= 101f)
        {
            mana = 100f;
            HudManager.SetMPBar(mana);
        }
        if (mana <= -1f)
        {
            mana = 0f;
            HudManager.SetMPBar(mana);
        }
    }
}
