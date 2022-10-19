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
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetSelectedText(string newText)
    {
        selectedtext.text = newText;
    }

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

    public static void SetHPBar (float newValue)
    {
        instance.hpbar.value = newValue;
    }

    public static void SetMPBar (float newValue)
    {
        instance.mpbar.value = newValue;
    }

    public static void Setammo (int newValue)
    {
        instance.ammotext.text = newValue.ToString();
    }

    private void GameOver()
    {
        Debug.Log("Respuesta desde Script Control3raP para HudManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
