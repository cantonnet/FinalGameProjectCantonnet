using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject Menuinicial;
    [SerializeField] private GameObject MenuInferior;
    [SerializeField] private GameObject Creditos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Cargando Escena");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCreditos()
    {
        Creditos.SetActive(true);
    }

    public void MenuPrincipal()
    {
        Menuinicial.SetActive(true);
        MenuInferior.SetActive(false);
        Creditos.SetActive(false);
    }

    public void Menuinferior()
    {
        Menuinicial.SetActive(false);
        MenuInferior.SetActive(true);
        Creditos.SetActive(false);
    }

    public void Volver()
    {
        SceneManager.LoadScene("MapaCripta");
    }

    public void EscenaAventura()
    {
        SceneManager.LoadScene("MapaCripta");
    }

        public void EscenaColiseo()
    {
        SceneManager.LoadScene("Coliseo");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
