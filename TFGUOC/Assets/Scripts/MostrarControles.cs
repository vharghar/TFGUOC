using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarControles : MonoBehaviour
{
    public KeyCode teclaDeControles;
    public KeyCode teclaConsejos;
    public KeyCode teclaFPS;
    public GameObject CntrolText;
    public GameObject fpsText;
    public GameObject panelConsejos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teclaDeControles))

        {
            Mostrar();
        }

        if (Input.GetKeyUp(teclaDeControles))

        {
            NoMostrar();
        }

        if (Input.GetKeyDown(teclaFPS))

        {
            MostrarFPS();
        }

        if (Input.GetKeyDown(teclaConsejos))

        {
            MostrarConsejos();
        }
    }
    void Mostrar()
    {
        CntrolText.SetActive(true); 
    }
    void NoMostrar()
    {
        CntrolText.SetActive(false);
    }

    void MostrarFPS()
    {
        if (fpsText.activeInHierarchy)
        {
            fpsText.SetActive(false);
        }
        else
        {
            fpsText.SetActive(true);
        }
    }

    void MostrarConsejos()
    {
        
            if (panelConsejos.activeInHierarchy)
            {
                panelConsejos.SetActive(false);
            }
            else
            {
                panelConsejos.SetActive(true);
            }
        
    }
}
