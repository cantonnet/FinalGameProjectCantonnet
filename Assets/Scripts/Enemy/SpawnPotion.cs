using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPotion : MonoBehaviour
{
    //Script para poder invocar e instanciar las pociones que el jugador puede tomar para recuperar stats

    [SerializeField] GameObject[] PotionObjects;
    private GameObject Potion;
    float tiempotrasladar = 5f;
    float tiempovivo = 0f;
    [SerializeField] public Transform SalidaSpawn;

    void Start()
    {
        tiempovivo += Time.deltaTime;
    }

    void Update()
    {
        if (tiempotrasladar <= tiempovivo)
        {
            transform.Translate(Vector3.up * 10 * Time.deltaTime);
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            tiempovivo = 0;
        }
    }

    public void spawnpotion()
    {
        tiempovivo = 0;
        int rnd = Random.Range(0, PotionObjects.Length);
        Potion = PotionObjects[rnd];
        Instantiate(Potion, SalidaSpawn.position, transform.rotation);
    }
}
