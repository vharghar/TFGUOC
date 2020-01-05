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

    public string mMinSave;
    public string mSecSave;
    public string mMilSave;

    // Start is called before the first frame update
    void Start()
    {
        // CargarMejorTiempo();

        mMinSave = "MejorMinuto00Save";
        mSecSave = "MejorSegundo00Save";
        mMilSave = "MejorMilesima00Save";


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter()
    {



     mejorMinuto = PlayerPrefs.GetInt(mMinSave);
     mejorSegundo = PlayerPrefs.GetInt(mSecSave);
     mejorMilesima = PlayerPrefs.GetFloat(mMilSave);

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
                            else
                            {
                                ComprobarOtrosTiempos(actMinutos, actSegundos, actMilesimas);
                            }
                        }
                        else
                        {
                            ComprobarOtrosTiempos(actMinutos, actSegundos, actMilesimas);
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

          PlayerPrefs.SetInt(mMinSave, actMinutos);
          PlayerPrefs.SetInt(mSecSave, actSegundos);
          PlayerPrefs.SetFloat(mMilSave, actMilesimas);

      */
        ComprobarOtrosTiempos(actMinutos, actSegundos, actMilesimas);
        //CargarMejorTiempo();

    }
    void AlmacenarMejorTiempo()
    {
        mejorMinuto = actMinutos;
        mejorSegundo = actSegundos;
        mejorMilesima = actMilesimas;

        PlayerPrefs.SetInt(mMinSave, mejorMinuto);
        PlayerPrefs.SetInt(mSecSave, mejorSegundo);
        PlayerPrefs.SetFloat(mMilSave, mejorMilesima);
    }
    void ReiniciarReloj()
    {
        LapTimeManager.ContaMinutos = 0;
        LapTimeManager.ContaSegundos = 0;
        LapTimeManager.ContaMilesimas = 0;

        
    }

    void CargarMejorTiempo()
    {
        mejorMinuto = PlayerPrefs.GetInt(mMinSave);
        mejorSegundo = PlayerPrefs.GetInt(mSecSave);
        mejorMilesima = PlayerPrefs.GetFloat(mMilSave);


        MilesimasBest.GetComponent<Text>().text = mejorMilesima.ToString("F0");
        SegundosBest.GetComponent<Text>().text = mejorSegundo.ToString("00") + ".";
        MinutosBest.GetComponent<Text>().text =  mejorMinuto.ToString("00") + ":";
        
        Debug.Log("Cargar Mejor tiempo Ingame -- " + mejorMinuto + ":" + mejorSegundo + "." + mejorMilesima);
    }

   
    void ComprobarOtrosTiempos(int minut, int secon, float milesi)
    {
        string mMS;
        string mSS;
        string mMlS;
        int posicionAlmacenado = 5;
        int minAlmacenado;
        int secAlmacenado;
        float milAlmacenado;

        for (int i = 0; i < 4; i += 1)
        {
            mMS = "MejorMinuto0" + i + "Save";
            mSS = "MejorSegundo0" + i + "Save";
            mMlS = "MejorMilesima0" + i + "Save";

            minAlmacenado = PlayerPrefs.GetInt(mMS);
            secAlmacenado = PlayerPrefs.GetInt(mSS);
            milAlmacenado = PlayerPrefs.GetFloat(mMlS);

            if (minAlmacenado == 0 && secAlmacenado == 0 && milAlmacenado == 0f)
            {

                posicionAlmacenado = i;
                break;
            }
            else
            {
                if (minut < minAlmacenado)
                {

                    posicionAlmacenado = i;
                    break;
                }
                else
                {
                    if (minut == minAlmacenado)
                    {
                        if (secon < secAlmacenado)
                        {

                            posicionAlmacenado = i;
                            break;
                        }
                        else
                        {
                            if (secon == secAlmacenado)
                            {
                                if (milesi < milAlmacenado)
                                {

                                    posicionAlmacenado = i;
                                    break;
                                }
                            }
                        }
                    }

                }

            }
        }

            if (posicionAlmacenado != 5)
            {
                ActualizarRegistros(posicionAlmacenado, minut, secon, milesi);
            }
    }

    void ActualizarRegistros(int posicion, int minut, int secon, float milesi)
    {
        string mMS = "MejorMinuto0" + posicion + "Save";
        string mSS = "MejorSegundo0" + posicion + "Save";
        string mMlS = "MejorMilesima0" + posicion + "Save";
        string mMSPrevio ;
        string mSSPrevio ;
        string mMlSPrevio;
            string mMSNuevo;
            string mSSNuevo;
            string mMlSNuevo;
            int minutoNuevo;
            int segundoNuevo;
            float milesimaNuevo;
            int minutoViejo;
            int segundoViejo;
            float milesimaViejo;


            if (posicion == 3)
            {
                PlayerPrefs.SetInt(mMS, minut);
                PlayerPrefs.SetInt(mSS, secon);
                PlayerPrefs.SetFloat(mMlS, milesi);

            }
            else
            {
                for (int i=3; i>posicion; i -= 1)
                {
                    if (posicion == i - 1)
                    {
                        mMSPrevio = "MejorMinuto0" + posicion + "Save";
                        mSSPrevio = "MejorSegundo0" + posicion + "Save";
                        mMlSPrevio = "MejorMilesima0" + posicion + "Save";

                        mMSNuevo = "MejorMinuto0" + i + "Save";
                        mSSNuevo = "MejorSegundo0" + i + "Save";
                        mMlSNuevo = "MejorMilesima0" + i + "Save";

                        minutoNuevo = PlayerPrefs.GetInt(mMSPrevio);
                        segundoNuevo = PlayerPrefs.GetInt(mSSPrevio);
                        milesimaNuevo = PlayerPrefs.GetFloat(mMlSPrevio); ;
                                         
                        PlayerPrefs.SetInt(mMSNuevo, minutoNuevo);
                        PlayerPrefs.SetInt(mSSNuevo, segundoNuevo);
                        PlayerPrefs.SetFloat(mMlSNuevo, milesimaNuevo);

                        PlayerPrefs.SetInt(mMSPrevio, minut);
                        PlayerPrefs.SetInt(mSSPrevio, secon);
                        PlayerPrefs.SetFloat(mMlSPrevio, milesi);

                    }
                    else
                    {
                        mMSPrevio = "MejorMinuto0" + (i-1) + "Save";
                        mSSPrevio = "MejorSegundo0" + (i-1) + "Save";
                        mMlSPrevio = "MejorMilesima0" + (i-1) + "Save";

                        mMSNuevo = "MejorMinuto0" + i + "Save";
                        mSSNuevo = "MejorSegundo0" + i + "Save";
                        mMlSNuevo = "MejorMilesima0" + i + "Save";

                        minutoViejo = PlayerPrefs.GetInt(mMSPrevio); ;
                        segundoViejo = PlayerPrefs.GetInt(mSSPrevio); ;
                        milesimaViejo = PlayerPrefs.GetFloat(mMlSPrevio);

                        PlayerPrefs.SetInt(mMSNuevo, minutoViejo);
                        PlayerPrefs.SetInt(mSSNuevo, segundoViejo);
                        PlayerPrefs.SetFloat(mMlSNuevo, milesimaViejo);

                    
                    }
                }
            }

      

    }
    
}
