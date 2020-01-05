using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarMejorTiempoCompleto : MonoBehaviour
{
    public GameObject MinutosBest;
    public GameObject SegundosBest;
    public GameObject MilesimasBest;

    public GameObject Minutos2nd;
    public GameObject Segundos2nd;
    public GameObject Milesimas2nd;

    public GameObject Minutos3th;
    public GameObject Segundos3th;
    public GameObject Milesimas3th;

    public GameObject Minutos4th;
    public GameObject Segundos4th;
    public GameObject Milesimas4th;


    public string mMinSave;
    public string mSecSave;
    public string mMilSave;


    // Start is called before the first frame update
    void Start()
    {

        mMinSave = "MejorMinuto00Save";
        mSecSave = "MejorSegundo00Save";
        mMilSave = "MejorMilesima00Save";

        CargarMTC();


    }

    // Update is called once per frame
    public void CargarMTC()
    {
        int mejorMinuto, mejorMinuto01, mejorMinuto02, mejorMinuto03;
        int mejorSegundo, mejorSegundo01, mejorSegundo02, mejorSegundo03;
        float mejorMilesima, mejorMilesima01, mejorMilesima02, mejorMilesima03;


        // mejor tiempo
        mejorMinuto = PlayerPrefs.GetInt("MejorMinuto00Save");
        mejorSegundo = PlayerPrefs.GetInt("MejorSegundo00Save");
        mejorMilesima = PlayerPrefs.GetFloat("MejorMilesima00Save");


        MinutosBest.GetComponent<Text>().text = mejorMinuto.ToString("00") + ":";
        SegundosBest.GetComponent<Text>().text = mejorSegundo.ToString("00") + ".";
        MilesimasBest.GetComponent<Text>().text = mejorMilesima.ToString("F0");

        // 2º mejor tiempo
        mejorMinuto01 = PlayerPrefs.GetInt("MejorMinuto01Save");
        mejorSegundo01 = PlayerPrefs.GetInt("MejorSegundo01Save");
        mejorMilesima01 = PlayerPrefs.GetFloat("MejorMilesima01Save");


        Minutos2nd.GetComponent<Text>().text = mejorMinuto01.ToString("00") + ":";
        Segundos2nd.GetComponent<Text>().text = mejorSegundo01.ToString("00") + ".";
        Milesimas2nd.GetComponent<Text>().text = mejorMilesima01.ToString("F0");

        //3º mejor tiempo

        mejorMinuto02 = PlayerPrefs.GetInt("MejorMinuto02Save");
        mejorSegundo02 = PlayerPrefs.GetInt("MejorSegundo02Save");
        mejorMilesima02 = PlayerPrefs.GetFloat("MejorMilesima02Save");

        Minutos3th.GetComponent<Text>().text = mejorMinuto02.ToString("00") + ":";
        Segundos3th.GetComponent<Text>().text = mejorSegundo02.ToString("00") + ".";
        Milesimas3th.GetComponent<Text>().text = mejorMilesima02.ToString("F0");

            //4º mejor tiempo
        mejorMinuto03 = PlayerPrefs.GetInt("MejorMinuto03Save");
        mejorSegundo03 = PlayerPrefs.GetInt("MejorSegundo03Save");
        mejorMilesima03 = PlayerPrefs.GetFloat("MejorMilesima03Save");


        Minutos4th.GetComponent<Text>().text = mejorMinuto03.ToString("00") + ":";
        Segundos4th.GetComponent<Text>().text = mejorSegundo03.ToString("00") + ".";
        Milesimas4th.GetComponent<Text>().text = mejorMilesima03.ToString("F0");

        

        Debug.Log("Carga Mejor Tiempo -- " + mejorMinuto + ":" + mejorSegundo + "." + mejorMilesima);
    }

}
