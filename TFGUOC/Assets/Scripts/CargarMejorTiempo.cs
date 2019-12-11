using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarMejorTiempo : MonoBehaviour
{
    public GameObject MinutosBest;
    public GameObject SegundosBest;
    public GameObject MilesimasBest;
   
    // Start is called before the first frame update
    void Start()
    {
        cargarMT();


    }

    // Update is called once per frame
    void cargarMT()
    {
        int mejorMinuto = PlayerPrefs.GetInt("MejorMinuto00Save");
        int mejorSegundo = PlayerPrefs.GetInt("MejorSegundo00Save");
        float mejorMilesima = PlayerPrefs.GetFloat("MejorMilesima00Save");
        if (mejorSegundo <= 9)
        {
            SegundosBest.GetComponent<Text>().text = "0" + mejorSegundo + ".";
        }
        else
        {
            SegundosBest.GetComponent<Text>().text = "" + mejorSegundo + ".";
        }

        if (mejorMinuto <= 9)
        {
            MinutosBest.GetComponent<Text>().text = "0" + mejorMinuto + ":";

        }
        else
        {
            MinutosBest.GetComponent<Text>().text = "" + mejorMinuto + ":";
        }
        MilesimasBest.GetComponent<Text>().text = "" + mejorMilesima;
    }
 
}
