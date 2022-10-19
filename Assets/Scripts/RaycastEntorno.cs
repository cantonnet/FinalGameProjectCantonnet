using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEntorno : MonoBehaviour
{ 
    [SerializeField] Transform Comienzo;
    [SerializeField] Transform Final;

    [SerializeField]
    [Range(1f,20f)]
    private float rayDistancia = 10;
    public bool pasojugador = false;

    [SerializeField] GameObject PrimerPlano;
    [SerializeField] GameObject SegundoPlano;
    float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        RaycastHit hit;
        if (Physics.Raycast(Comienzo.position, Final.position, out hit, rayDistancia))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Colision con Raycast");
                AccionColicion();
            }
        }
    }

    void AccionColicion()
    {
        if (time >= 0.5f)
        {
            if (pasojugador == false)
                {
                    SegundoPlano.SetActive(true);
                    PrimerPlano.SetActive(false);
                    pasojugador = true;
                }
            else
                {
                    SegundoPlano.SetActive(false);
                    PrimerPlano.SetActive(true);
                    pasojugador = false;
                } 
            time = 0f;
        }
    }
}
