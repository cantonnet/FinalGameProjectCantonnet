using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject pcam;
    public GameObject aimcam;
    public GameObject aimcambow;
    public bool isAiming;
    public bool stancebow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

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
