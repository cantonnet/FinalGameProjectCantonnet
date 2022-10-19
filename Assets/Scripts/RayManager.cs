using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    [SerializeField] Transform Comienzo;
    [SerializeField] Transform Final;

    [SerializeField]
    [Range(1f,20f)]
    private float rayDistancia = 10;
    public bool pasojugador = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void AccionColicion()
    {

    }

    void Update()
    {
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
}
