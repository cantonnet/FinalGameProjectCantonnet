using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private static MenuPausa instance;
    public static MenuPausa Instance {get => instance; }
    public bool PauseActive = false;
    [SerializeField] private GameObject PausaPanel;
    [SerializeField] private GameObject HudPanel;

    [SerializeField] private GameObject BotonReanudar;
    [SerializeField] private GameObject BotonSalir;
    [SerializeField] private GameObject BotonReiniciar;

    // Al iniciar el menu pausa se encuentra desactivado
    void Start()
    {
        PausaPanel.SetActive(false);
    }
    // llamado del evento desde el Control del personaje cuando este muere lo toma como GameOverActivePausa
    private void Awake() {
        ControlDeTerceraPersona.OnDead += GameOverAcivePausa;
    }

    //Con Escape Activamos y desactivamos el menu de pausa segun el booleano de PauseAvtive
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseActive == false)
            {
                PausaPanel.SetActive(true);
                HudPanel.SetActive(false);
                Debug.Log("Active Pause");
                PauseActive = true;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Reanudar();
            }
        }
    }
    // Reanuda vuelve al juego desactivando el menu de pausa
    public void Reanudar()
    {
        PauseActive = false;
        Debug.Log("Desactive Pause");
        Time.timeScale = 1f;
        PausaPanel.SetActive(false);
        HudPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    //El boton de reinicio reinicia el mapa actual segun el SceneManager y getactiveescene
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Salir sale del mapa y va directo al menu principal
    public void Salir()
    {
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
    }
    //Cuando el personaje muere es avisado el evento desde el control de personaje y se activa GameOverActivePausa para desplegar el menu de pausa
    private void GameOverAcivePausa()
    {
        if (PauseActive == false)
            {
                PausaPanel.SetActive(true);
                HudPanel.SetActive(false);
                Debug.Log("Active Pause");
                PauseActive = true;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Respuesta desde Script Control3raP para Pausa");
            }
            else
            {
                Reanudar();
            }
    }

}
