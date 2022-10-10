using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Crear Enemy Data")]
public class EnemyData : ScriptableObject
{

    private Animator anim;

    //Desing Data
    [Header("Movimiento")]
    [SerializeField]
    [Range(1f, 10f)]
    public float speed = 2f;
    public float rotationspeed = 180f;
    public float lateralspeed = 2.5f;

    public bool warrior = false;
    public bool Archer = false;

    [Header("Caracteristicas")]
    [SerializeField]
    [Range(1, 10)]
    public int escalamenor = 1;

    [SerializeField]
    [Range(1, 10)]
    public int escalamayor = 4;

    [SerializeField]
    [Range(1, 10)]
    public int vida = 3;

    [SerializeField]
    [Range(1, 10)]
    public int damage = 1;



}
