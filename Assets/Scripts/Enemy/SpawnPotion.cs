using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPotion : MonoBehaviour
{

    [SerializeField] GameObject[] PotionObjects;
    private GameObject Potion;
    float tiempotrasladar = 5f;
    float tiempovivo = 0f;
    [SerializeField] public Transform SalidaSpawn;
    // Start is called before the first frame update
    void Start()
    {
        tiempovivo += Time.deltaTime;
    }

    private void Awake() 
    {

    }

    // Update is called once per frame
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
