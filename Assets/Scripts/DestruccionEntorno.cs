using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionEntorno : MonoBehaviour
{
    [SerializeField] GameObject Adestruir;
    [SerializeField] GameObject Cdestruir;
    [SerializeField] GameObject Breforma;
    public GameObject Efecto;
    [SerializeField] public Transform SalidaEfecto;
    bool exploto = false;
    /* este script se utiliza para destruir determinados objetos que requieren de la interaccion de la espada del 
    jugador como la puerta a la base goblin y el desactivador de la trampa un poco mas adelante de la puerta*/
    private void OnTriggerEnter(Collider other)
    {
        if (exploto == false)
        {
            if (other.gameObject.CompareTag("Bala"))
            { 
            Debug.Log("Explotar");
            Destroy(Adestruir);
            Destroy(Cdestruir);
            Adestruir.SetActive(false);
            Cdestruir.SetActive(false);
            Breforma.SetActive(true);
            Instantiate(Efecto, SalidaEfecto.position, transform.rotation);
            exploto = true;
            }
        }
    }
}
