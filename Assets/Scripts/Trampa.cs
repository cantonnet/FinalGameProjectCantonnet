using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{   //Objetos que van a interactuar con el script
    [SerializeField] GameObject PinchosIzq;
    [SerializeField] GameObject PinchosDer;
    bool activo = false;
    // movimiento que va a realizar estos objetos al colicionar con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (activo == false)
        {
            if (other.gameObject.CompareTag("Player"))
            { 
                PinchosIzq.transform.position = transform.position + Vector3.forward * (Time.deltaTime);
                PinchosDer.transform.position = transform.position + Vector3.back * (Time.deltaTime);
                activo = true;
            }
            if (other.gameObject.CompareTag("Parar"))
            { 
                PinchosIzq.transform.position = transform.position + Vector3.forward * (Time.deltaTime * 0);
                PinchosDer.transform.position = transform.position + Vector3.back * (Time.deltaTime * 0);
                activo = true;
            }
        }
    }
}
