using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Disparar : MonoBehaviour
{
    public GameObject Bala;
    public static event Action OnPowerInvoke;
    public Animator anim;

    private void DisparoFlecha()
    {
        Instantiate(Bala, transform.position, transform.rotation);
        Disparar.OnPowerInvoke.Invoke();
    }
    
}
