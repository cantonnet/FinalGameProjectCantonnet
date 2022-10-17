using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarPotion : MonoBehaviour
{

    enum potiontype { Mana, Healt, Arrows};
    [SerializeField] potiontype PotionType;
    // Start is called before the first frame update
   public void swicher()
    {
        switch (PotionType)
        {
            case potiontype.Mana:
                break;
            case potiontype.Healt:
                break;
            case potiontype.Arrows:
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            Debug.Log("PotionTake");
            destruir();
        }
    }

    public void destruir()
    {
        //Instantiate(Efecto, SalidaEfecto.position, transform.rotation);
        Destroy(gameObject);
    }
}
