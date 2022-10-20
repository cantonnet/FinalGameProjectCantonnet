using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEntorno : MonoBehaviour
{
    // Objetos y opciones que vam a interactuar con el script de deteccion
    [SerializeField]
    Transform Comienzo;

    [SerializeField]
    Transform Final;

    [SerializeField]
    [Range(1f, 20f)]
    private float rayDistancia = 10;
    public bool pasojugador = false;

    [SerializeField]
    GameObject PrimerPlano;

    [SerializeField]
    GameObject SegundoPlano;
    float time = 0f;

    //Cuando el jugador coliciona con el rayo detector generado entre los puntos comienzo y final se produce la accion de AccionColicion()
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

    // Al pasar por el rayo toma un pequeno delay con time para que no loope con la colicion por causa del update, al pasar se eimina un plano del espacio del mapa por el otro.
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
