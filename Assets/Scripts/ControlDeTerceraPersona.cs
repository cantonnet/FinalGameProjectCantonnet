using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class ControlDeTerceraPersona : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] SwitchCamera SwitchCamera;
    private AudioSource audiosource;

    private Animator anim;

    public float speed = 2.6f;
    float x, y, z;
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
        trasladando();
        ataque();
        stances();
        aiming();
        if(isaiming == false)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
        if(isaiming == true)
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

        bool isAtaking = Input.GetMouseButtonDown(0);
         if (isAtaking) {anim.SetBool("Atacar", true);}
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
            if (((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))))
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
    {
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

    void stances()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (swordstance == true)
            {
                swordstance = false;
                bowstance = false;
                magestance = false;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
            else
            {
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
                swordstance = false;
                bowstance = false;
                magestance = false;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
            else{
            swordstance = false;
            bowstance = true;
            magestance = false;
            SwitchCamera.Setbowstancevalue(bowstance);}
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (magestance == true)
            {
                swordstance = false;
                bowstance = false;
                magestance = false;
                SwitchCamera.Setbowstancevalue(bowstance);
            }
            else
            {swordstance = false;
            bowstance = false;
            magestance = true;
            SwitchCamera.Setbowstancevalue(bowstance);}
        } 
    }

    //AUDIO

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
    {
        int index = Random.Range(0, audioClip.Length  - 1);
        return audioClip[index];
    }

    private void footrun()
    {
        AudioClip clip = GetRandomClip();
        audiosource.PlayOneShot(clip);
    }
    private void walkrun()
    {
        AudioClip clip = GetRandomClip();
        audiosource.PlayOneShot(clip);
    }

    private void ataque()
    {
        if((swordstance == true) || (magestance == true))
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
}
