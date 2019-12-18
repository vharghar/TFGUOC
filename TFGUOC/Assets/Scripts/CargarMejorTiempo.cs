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
    public void cargarMT()
    {
        int mejorMinuto = PlayerPrefs.GetInt("MejorMinuto00Save");
        int mejorSegundo = PlayerPrefs.GetInt("MejorSegundo00Save");
        float mejorMilesima = PlayerPrefs.GetFloat("MejorMilesima00Save");


        MinutosBest.GetComponent<Text>().text = mejorMinuto.ToString("00") + ":";
        SegundosBest.GetComponent<Text>().text = mejorSegundo.ToString("00") + ".";
        MilesimasBest.GetComponent<Text>().text = mejorMilesima.ToString("F0");

        Debug.Log("Carga Mejor Tiempo -- " + mejorMinuto + ":" + mejorSegundo + "." + mejorMilesima);
    }
 
}
