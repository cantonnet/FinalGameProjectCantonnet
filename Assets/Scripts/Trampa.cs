using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] GameObject PinchosIzq;
    [SerializeField] GameObject PinchosDer;
    bool activo = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
