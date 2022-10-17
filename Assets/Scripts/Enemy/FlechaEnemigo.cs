using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaEnemigo : LogicaFlecha
{
        public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
            Debug.Log("Hit Jugador");
        }
        if (other.gameObject.CompareTag("Criatura"))
        { 
        }
    }
}
