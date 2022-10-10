using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplocionFireball : MonoBehaviour
{
    float time;
    public float eliminaral = 2;

    void Update()
    {
        // transform.Translate(0, 0, y * speed * Time.deltaTime);
        time += Time.deltaTime;
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
}
