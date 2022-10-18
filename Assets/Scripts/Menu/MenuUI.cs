using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Cargando Escena");
    }

    // Update is called once per frame
    void Update()
    {
        
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
