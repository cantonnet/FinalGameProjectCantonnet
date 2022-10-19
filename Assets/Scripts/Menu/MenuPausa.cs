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

    // Start is called before the first frame update
    void Start()
    {
        PausaPanel.SetActive(false);
    }

    private void Awake() {
        ControlDeTerceraPersona.OnDead += GameOverAcivePausa;
    }

    // Update is called once per frame
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

    public void Reanudar()
    {
        PauseActive = false;
        Debug.Log("Desactive Pause");
        Time.timeScale = 1f;
        PausaPanel.SetActive(false);
        HudPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
    }

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
