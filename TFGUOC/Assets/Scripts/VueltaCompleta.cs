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

    public int actMinutos;
    public int actSegundos;
    public float actMilesimas;

    public int mejorMinuto;
    public int mejorSegundo;
    public float mejorMilesima;

    // Start is called before the first frame update
    void Start()
    {
       // CargarMejorTiempo();


       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter()
    {
        mejorMinuto = PlayerPrefs.GetInt("MejorMinuto00Save");
        mejorSegundo = PlayerPrefs.GetInt("MejorSegundo00Save");
        mejorMilesima = PlayerPrefs.GetFloat("MejorMilesima00Save");

        actMinutos = LapTimeManager.ContaMinutos;
        actSegundos = LapTimeManager.ContaSegundos;
        actMilesimas = LapTimeManager.ContaMilesimas;


        if (mejorMinuto == 0 && mejorSegundo == 0 && mejorMilesima == 0f)
        {
           
            Debug.Log("todo -- " + actMinutos + ":" + actSegundos + "." + actMilesimas);
            ActualizarTextos();
        }
        else
        {
            if (actMinutos < mejorMinuto)
            {
                
                Debug.Log("minuto -- " + actMinutos + ":" + actSegundos + "." + actMilesimas);
                ActualizarTextos();
            }
            else
            {
                if (actMinutos == mejorMinuto)
                {
                    if (actSegundos < mejorSegundo)
                    {
                        
                        Debug.Log("segundo -- " + actMinutos + ":" + actSegundos + "." + actMilesimas);
                        ActualizarTextos();
                    }
                    else
                    {
                        if (actSegundos == mejorSegundo)
                        {
                            if (actMilesimas < mejorMilesima)
                            {
                                
                                Debug.Log("milesima -- " + actMinutos + ":" + actSegundos + "." + actMilesimas);
                                ActualizarTextos();
                            }
                        }
                    }
                }

            }
        }

        //CargarMejorTiempo();
        ReiniciarReloj();

        VueltaCompletaTrig.SetActive(false);
        CP_1.SetActive(true);

    }

    void ActualizarTextos()
    {
        MilesimasBest.GetComponent<Text>().text = actMilesimas.ToString("F0"); 
        SegundosBest.GetComponent<Text>().text = actSegundos.ToString("00") + ".";
        MinutosBest.GetComponent<Text>().text = actMinutos.ToString("00") + ":";
       
       
        // AlmacenarMejorTiempo();
      /*
        mejorMinuto = actMinutos;
        mejorSegundo = actSegundos;
        mejorMilesima = actMilesimas;
*/
        PlayerPrefs.SetInt("MejorMinuto00Save", actMinutos);
        PlayerPrefs.SetInt("MejorSegundo00Save", actSegundos);
        PlayerPrefs.SetFloat("MejorMilesima00Save", actMilesimas);

        //CargarMejorTiempo();

    }
    void AlmacenarMejorTiempo()
    {
        mejorMinuto = actMinutos;
        mejorSegundo = actSegundos;
        mejorMilesima = actMilesimas;

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


        MilesimasBest.GetComponent<Text>().text = mejorMilesima.ToString("F0");
        SegundosBest.GetComponent<Text>().text = mejorSegundo.ToString("00") + ".";
        MinutosBest.GetComponent<Text>().text =  mejorMinuto.ToString("00") + ":";
        
        Debug.Log("Cargar Mejor tiempo Ingame -- " + mejorMinuto + ":" + mejorSegundo + "." + mejorMilesima);
    }

   

    
}
