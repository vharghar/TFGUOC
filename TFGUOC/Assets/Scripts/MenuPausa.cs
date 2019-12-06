using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public static bool JuegoEnPausa = false;

    public GameObject menuPausaUI;
    public GameObject optionsUI;
    public GameObject audioUI;
    public GameObject graficsUI;
    public GameObject exitUI;
    public GameObject camara;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoEnPausa)
            {
                if (menuPausaUI.activeSelf)
                {
                    Continuar();
                }
                else
                {
                    MenuActivo();
                }
                
            }
            else
            {
                Pausa();
            }
        }
    }
    public void MenuActivo()
    {
        optionsUI.SetActive(false);
        audioUI.SetActive(false);
        graficsUI.SetActive(false);
        exitUI.SetActive(false);
        menuPausaUI.SetActive(true);
        
        
    }
    public void Continuar()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        JuegoEnPausa = false;
        //player.SetActive (true);

    }

    void Pausa()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoEnPausa = true;
        //player.SetActive(false);
    }

    public void LoadMenu()
    {
        Debug.Log("Cargando menu ...");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego ...");
        Application.Quit();

    }
}
