using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LogicaFlecha : MonoBehaviour
{
    public int speed = 6;
    float y;
    float time;
    public float eliminaral = 9;
    // Start is called before the first frame update
    void Start()
    {
        y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(0, 0, y * speed * Time.deltaTime);
        time += Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        if (time >= eliminaral)
        {
            time = 0f;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Criatura"))
        { 
            Destroy(gameObject);
            speed = 0;
            Debug.Log("Hit Enemy");
        }
    }
}
