using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEspada : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Criatura"))
        {
            Debug.Log("Hit Enemy");
        }
    }
}
