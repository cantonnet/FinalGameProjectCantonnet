using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{   //Este script es usado para el prefab de Spawner para generar enemigos aleatorios en el mapa
    public GameObject[] Enemigos;
    public float tiempodespawn = 25f;
    float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        instanciar();
    }

    private void instanciar()
    {
        if (time >= tiempodespawn)
        {
            int RandomEnemy = Random.Range(0, Enemigos.Length);
            Instantiate(Enemigos[RandomEnemy], transform);
        time = 0f;
        }
    }
}
