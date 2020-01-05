using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarMejorTiempo : MonoBehaviour
{
    public GameObject MinutosBest;
    public GameObject SegundosBest;
    public GameObject MilesimasBest;

    public string mMinSave;
    public string mSecSave;
    public string mMilSave;


    // Start is called before the first frame update
    void Start()
    {

        mMinSave = "MejorMinuto00Save";
        mSecSave = "MejorSegundo00Save";
        mMilSave = "MejorMilesima00Save";

        CargarMT();


    }

    // Update is called once per frame
    public void CargarMT()
    {
        int mejorMinuto;
        int mejorSegundo;
        float mejorMilesima;


        // mejor tiempo
        mejorMinuto = PlayerPrefs.GetInt("MejorMinuto00Save");
        mejorSegundo = PlayerPrefs.GetInt("MejorSegundo00Save");
        mejorMilesima = PlayerPrefs.GetFloat("MejorMilesima00Save");


        MinutosBest.GetComponent<Text>().text = mejorMinuto.ToString("00") + ":";
        SegundosBest.GetComponent<Text>().text = mejorSegundo.ToString("00") + ".";
        MilesimasBest.GetComponent<Text>().text = mejorMilesima.ToString("F0");



        Debug.Log("Carga Mejor Tiempo -- " + mejorMinuto + ":" + mejorSegundo + "." + mejorMilesima);
    }
 
}
