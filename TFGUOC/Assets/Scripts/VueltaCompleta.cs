using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VueltaCompleta : MonoBehaviour
{
    public GameObject VueltaCompletaTrig;
    public GameObject CP_1;
    //  public GameObject CP_2;
    //public GameObject CP_3;
    //  public GameObject CP_4;
  


    public  GameObject MinutosBest;
    public  GameObject SegundosBest;
    public  GameObject MilesimasBest;
    
      int mejorMinuto;
      int mejorSegundo;
      float mejorMilesima;

    // Start is called before the first frame update
    void Start()
    {
        CargarMejorTiempo();


       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter()
    {
        int actMinutos = LapTimeManager.ContaMinutos;
        int actSegundos = LapTimeManager.ContaSegundos;
        float actMilesimas = LapTimeManager.ContaMilesimas;


        if (mejorMinuto == 0 && mejorSegundo == 0 && mejorMilesima == 0f)
        {
            ActualizarTextos();
            AlmacenarMejorTiempo();
        }
        else
        {
            if (actMinutos < mejorMinuto)
            {
                ActualizarTextos();
                AlmacenarMejorTiempo();
            }
            else
            {
                if (actMinutos == mejorMinuto)
                {
                    if (actSegundos < mejorSegundo)
                    {
                        ActualizarTextos();
                        AlmacenarMejorTiempo();
                    }
                    else
                    {
                        if (actSegundos == mejorSegundo)
                        {
                            if (actMilesimas < mejorMilesima)
                            {
                                ActualizarTextos();
                                AlmacenarMejorTiempo();
                            }
                        }
                    }
                }

            }
        }

        CargarMejorTiempo();
        ReiniciarReloj();

        VueltaCompletaTrig.SetActive(false);
        CP_1.SetActive(true);

    }

    void ActualizarTextos()
    {
        if (LapTimeManager.ContaSegundos <= 9)
        {
            SegundosBest.GetComponent<Text>().text = "0" + LapTimeManager.ContaSegundos + ".";
        }
        else
        {
            SegundosBest.GetComponent<Text>().text = "" + LapTimeManager.ContaSegundos + ".";
        }

        if (LapTimeManager.ContaMinutos <= 9)
        {
            MinutosBest.GetComponent<Text>().text = "0" + LapTimeManager.ContaMinutos + ":";

        }
        else
        {
            MinutosBest.GetComponent<Text>().text = "" + LapTimeManager.ContaMinutos + ":";
        }
        
        MilesimasBest.GetComponent<Text>().text = "" + LapTimeManager.ContaMilesimas.ToString("F0");
        


       

    }
    void AlmacenarMejorTiempo()
    {
        mejorMinuto = LapTimeManager.ContaMinutos;
        mejorSegundo = LapTimeManager.ContaSegundos;
        mejorMilesima = LapTimeManager.ContaMilesimas;

        PlayerPrefs.SetInt("MejorMinuto00Save", mejorMinuto);
        PlayerPrefs.SetInt("MejorSegundo00Save", mejorSegundo);
        PlayerPrefs.SetFloat("MejorMilesima00Save", mejorMilesima);
    }
    void ReiniciarReloj()
    {
        LapTimeManager.ContaMinutos = 0;
        LapTimeManager.ContaSegundos = 0;
        LapTimeManager.ContaMilesimas = 0;

        
    }

    void CargarMejorTiempo()
    {
        mejorMinuto = PlayerPrefs.GetInt("MejorMinuto00Save");
        mejorSegundo = PlayerPrefs.GetInt("MejorSegundo00Save");
        mejorMilesima = PlayerPrefs.GetFloat("MejorMilesima00Save");

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
        MilesimasBest.GetComponent<Text>().text = "" + mejorMilesima.ToString("F0");

    }

   

    
}
