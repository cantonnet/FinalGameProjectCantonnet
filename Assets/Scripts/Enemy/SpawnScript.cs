using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] Enemigos;
    public float tiempodespawn = 25f;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
