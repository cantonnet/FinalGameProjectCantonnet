using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject Menuinicial;
    [SerializeField] private GameObject MenuInferior;
    [SerializeField] private GameObject Creditos;
    // Aviso de carga de la Escena en debug
    void Start()
    {
        Debug.Log("Cargando Escena");
    }
    // muestra los creditos
    public void LoadCreditos()
    {
        Creditos.SetActive(true);
    }
    // Muestra el menu principal desactivando el resto
    public void MenuPrincipal()
    {
        Menuinicial.SetActive(true);
        MenuInferior.SetActive(false);
        Creditos.SetActive(false);
    }
    // muestra el menu de los mapas desactivando el resto de menues
    public void Menuinferior()
    {
        Menuinicial.SetActive(false);
        MenuInferior.SetActive(true);
        Creditos.SetActive(false);
    }
    //Jugar el mapa De Aventura
    public void EscenaAventura()
    {
        SceneManager.LoadScene("MapaCripta");
    }
    // Jugar en el Coliseo
    public void EscenaColiseo()
    {
        SceneManager.LoadScene("Coliseo");
    }
    // Salir del programa
    public void ExitGame()
    {
        Application.Quit();
    }
}
