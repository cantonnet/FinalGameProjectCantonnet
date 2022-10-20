using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class HudManager : MonoBehaviour

{
    private static HudManager instance;
    public static HudManager Instance {get => instance; }
    [SerializeField] private TMP_Text selectedtext;
    [SerializeField] private TMP_Text ammotext;
    [SerializeField] private GameObject stancemode;
    public Material[] imagenes;
    [SerializeField] private Slider hpbar;
    [SerializeField] private Slider mpbar;

    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Bow;
    [SerializeField] private GameObject Magic;
    // Singleton de cuando aparece el hud detecta si no se duplica el mismo en la instancia de juego, si lo hace el mismo es eliminado para ser el unico in game
    private void Awake() {
        if (instance == null)
        {
            
            instance = this;
            Debug.Log(instance);
            ControlDeTerceraPersona.OnDead += GameOver;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void SetSelectedText(string newText)
    {
        selectedtext.text = newText;
    }
    //Cambia la imagen segun el estado del juegador que es avisado a travez de eventos que vienen del control de personaje
    public void SetStanceImage(int Index)
    {
        if (Index == 0)
        {
            Sword.gameObject.SetActive (false);
            Bow.gameObject.SetActive (false);
            Magic.gameObject.SetActive (false);
            ammotext.text = "0";
            selectedtext.text = "Estados";
        }
        if (Index == 1)
        {
            Sword.gameObject.SetActive (true);
            Bow.gameObject.SetActive (false);
            Magic.gameObject.SetActive (false);
            ammotext.text = "1";
            selectedtext.text = "Guerrero";
        }
        if (Index == 2)
        {
            Sword.gameObject.SetActive (false);
            Bow.gameObject.SetActive (true);
            Magic.gameObject.SetActive (false);
            selectedtext.text = "Arquero";
        }
        if (Index == 3)
        {
            Sword.gameObject.SetActive (false);
            Bow.gameObject.SetActive (false);
            Magic.gameObject.SetActive (true);
            ammotext.text = "++";
            selectedtext.text = "Mago";
        }
    }
    // la barra de vida se actualiza de acuerdo a como va avisando el control de personaje
    public static void SetHPBar (float newValue)
    {
        instance.hpbar.value = newValue;
    }
    // la barra de mana se va actualizando deacuerdo al aviso de evento desde control de personaje
    public static void SetMPBar (float newValue)
    {
        instance.mpbar.value = newValue;
    }
    //el valor de la cantidad de municion se va avisando a travez de eventos que vienen desde control de personaje
    public static void Setammo (int newValue)
    {
        instance.ammotext.text = newValue.ToString();
    }
    // respues de prueba de evento que viene desde el control de personaje para debug
    private void GameOver()
    {
        Debug.Log("Respuesta desde Script Control3raP para HudManager");
    }
}
