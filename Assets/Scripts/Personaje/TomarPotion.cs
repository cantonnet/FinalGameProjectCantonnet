using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarPotion : MonoBehaviour
{

    // dependiendo del tipo de item es el efecto que ocurre al tomar ya que cambia el tag del prefab
    enum potiontype
    {
        Mana,
        Healt,
        Arrows
    };

    [SerializeField]
    potiontype PotionType;

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
            Debug.Log("Potion add " + PotionType);
            destruir();
        }
    }

    public void destruir()
    {
        Destroy(gameObject);
    }
}
