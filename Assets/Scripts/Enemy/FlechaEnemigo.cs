using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaEnemigo : LogicaFlecha
{// script de la flecha(balas) del enemigo trae logicaa de LogicaFlecha y se autodestruye al tocar al jugador
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
