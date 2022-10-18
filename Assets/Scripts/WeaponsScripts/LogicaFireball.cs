using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LogicaFireball : MonoBehaviour
{
    public int speed = 12;
    float y;
    float time;
    public float eliminaral = 2.5f;
    public GameObject Efecto;
    [SerializeField] public Transform SalidaEfecto;
    // Start is called before the first frame update
    void Start()
    {
        y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(0, 0, y * speed * Time.deltaTime);
        time += Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        if (time >= eliminaral)
        {
            time = 0f;
            Instantiate(Efecto, SalidaEfecto.position, transform.rotation);
            destruir();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Criatura"))
        { 
            Debug.Log("Hit Enemy");
            destruir();
        }
        destruir();
    }

    public void destruir()
    {
        Instantiate(Efecto, SalidaEfecto.position, transform.rotation);
        Destroy(gameObject);
    }
}
