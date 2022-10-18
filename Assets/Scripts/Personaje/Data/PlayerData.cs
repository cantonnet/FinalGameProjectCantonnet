using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Crear Enemy Data")]
public class PlayerData : ScriptableObject
{
    [Header("Caracteristicas")]
    public float vida = 100f;
    public float mana = 100f;
    public int municion = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
