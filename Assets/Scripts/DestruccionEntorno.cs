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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
