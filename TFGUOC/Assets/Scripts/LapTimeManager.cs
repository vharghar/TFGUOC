using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public static int ContaMinutos;
    public static int ContaSegundos;
    public static float ContaMilesimas;
    public static string PantallaMili;

    public GameObject MinutosGO;
    public GameObject SegundosGO;
    public GameObject MilesimasGO;

    private GameManagerScript GMS;

    
        


        // Start is called before the first frame update
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ActivarCronometro();

    }
    void ActivarCronometro()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        if (GMS.cuentaAtrasAcabada) 
        { 
            ContaMilesimas += Time.deltaTime * 10;
            PantallaMili = ContaMilesimas.ToString("F0");
            MilesimasGO.GetComponent<Text>().text = "" + PantallaMili;

            if (ContaMilesimas >= 10)
            {
                ContaMilesimas = 0;
                ContaSegundos += 1;

            }
            if (ContaSegundos <= 9)
            {
                SegundosGO.GetComponent<Text>().text = "0" + ContaSegundos + ".";

            }
            else
            {
                SegundosGO.GetComponent<Text>().text = "" + ContaSegundos + ".";
            }
            if (ContaSegundos >= 60)
            {
                ContaSegundos = 0;
                ContaMinutos += 1;
            }
            if (ContaMinutos <= 9)
            {
                MinutosGO.GetComponent<Text>().text = "0" + ContaMinutos + ":";

            }
            else
            {
                MinutosGO.GetComponent<Text>().text = "" + ContaMinutos + ":";
            }
        }

    }
}
