using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarPotion : MonoBehaviour
{

    enum potiontype { Mana, Healt, Arrows};
    [SerializeField] potiontype PotionType;
    //[SerializeField] ControlDeTerceraPersona ControlDeTerceraPersona;
    //public GameObject ObjetoBuscar;
    //string tagObjeto = "Player";
    //public float salud = 20f;
    //public float magia = 20f;
    //public int flechas = 5;
    // Start is called before the first frame update

    private void Start() {
        //ObjetoBuscar = GameObject.FindWithTag(tagObjeto);
        //ObjetoBuscar = FindObjectOfType<ControlDeTerceraPersona>().gameObject;
        //Debug.Log("Objeto encontrado con nombre --> " + ObjetoBuscar.name);
    }
   public void swicher()
    {
        switch (PotionType)
        {
            case potiontype.Mana:
                transform.gameObject.tag = "ManaPotion";
                break;
            case potiontype.Healt:
                transform.gameObject.tag = "HealtPotion";
                break;
            case potiontype.Arrows:
                transform.gameObject.tag = "ArrowPotion";
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            swicher();
            Debug.Log("PotionTake");
            Debug.Log("Potion add "+PotionType);
            destruir();
        }
    }

    public void destruir()
    {
        Destroy(gameObject);
    }
}
