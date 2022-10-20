using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{   
    // Las 3 camaras que van a interactuar en el juego
    public GameObject pcam;
    public GameObject aimcam;
    public GameObject aimcambow;
    public bool isAiming;
    public bool stancebow;

    void Update()
    {
        buttonmouse();
        setcamera();
    }

    public void SetAim (bool newValue)
    {
        isAiming = newValue;
    }

    public void Setbowstancevalue (bool newValue)
    {
        stancebow = newValue;
    }
    // segun el estado en que se encuentre el personaje es la camara Aim que se activa
    public void setcamera()
    {
        if (isAiming == false)
        {
            pcam.gameObject.SetActive (true);
            aimcam.gameObject.SetActive (false);
            aimcambow.gameObject.SetActive (false);
        }
        if (isAiming == true)
        {
            if (stancebow == true)
            {pcam.gameObject.SetActive (false);
            aimcam.gameObject.SetActive (false);
            aimcambow.gameObject.SetActive (true);}
            else
            {
            pcam.gameObject.SetActive (false);
            aimcambow.gameObject.SetActive (false);
            aimcam.gameObject.SetActive (true);
            }
        }
    }
    // al usar el boton derecho del mouse se activa el booleano de Aim el cual da paso a cambio de camara
    public void buttonmouse()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }
    }


}
