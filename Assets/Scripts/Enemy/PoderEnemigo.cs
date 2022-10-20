using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderEnemigo : LogicaFireball
{
    public void OnTriggerEnter(Collider other)
    {   // El fireball del Poder enemigo hereda su logica a este script, y se autodestruye al impactar con el jugador avisando en debug, tambien se autodestruye al impactar contra otros objetos con colision
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
