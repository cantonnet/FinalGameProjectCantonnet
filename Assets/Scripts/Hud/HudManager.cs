using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour

{
    private static HudManager instance;
    public static HudManager Instance {get => instance; }
    [SerializeField] private Text selectedtext;
    [SerializeField] private GameObject stancemode;
    public Material[] imagenes;
    [SerializeField] private Slider hpbar;
    [SerializeField] private Slider mpbar;

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
        instance.hpbar.value = 50;
    }

    public void SetSelectedText(string newText)
    {
        selectedtext.text = newText;
    }

    public void EnableWeapon(int childIndex)
    {
        if (childIndex == 0)
        {
            Instance.stancemode.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.blue;
        }
        if (childIndex == 1)
        {
            Instance.stancemode.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
        }
        if (childIndex == 2)
        {
            Instance.stancemode.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
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

    private void GameOver()
    {
        Debug.Log("Respuesta desde Script Control3raP para HudManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
