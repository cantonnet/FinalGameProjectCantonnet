using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderEnemigo : LogicaFireball
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            Debug.Log("Hit Jugador");
            destruir();
        }
        if (other.gameObject.CompareTag("Criatura"))
        { 
            Debug.Log("Hit sobre si mismo");
        }
        destruir();
    }
}
