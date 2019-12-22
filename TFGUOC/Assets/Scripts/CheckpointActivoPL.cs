using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointActivoPL : MonoBehaviour
{
    public bool activado = false;
   
    public static GameObject[] ListaPuntosControl;
    public GameObject[] ListaCP;
    public static int PuntoActivo = 0;
    public Material activo_tex;
    public Material noActivo_tex;
    
    public GameObject respawn;
    public GameObject cartel;
    public Text consejosText;



    // Start is called before the first frame update
    void Start()
    {
        //ListaPuntosControl = GameObject.FindGameObjectsWithTag("PuntoDeControl");
        ListaPuntosControl = ListaCP;
    }

    // Update is called once per frame
    void Update()
    {
        MaterialCheckpoint();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "carroceria")
        {
            // Debug.Log("Player");
            ActivarCheckPoint();
            MostrarConsejos(this.GetComponent<CheckpointActivoPL>().name);
        }
        else
        {
            //   Debug.Log(other.tag);

        }
        Debug.Log(this.GetComponent<CheckpointActivoPL>().name + " -- " + PuntoActivo);
    }

    void MostrarConsejos(string nombreCheckpoint)
    {
        string consejo = "Inicio";


        switch (nombreCheckpoint)
        {
            case "RampaCP":
                consejo = "Prueba 1 Rampa:\n Colocarse en la base y subir a una velocidad constante, no parar ni frenar a media subida.";
                break;
            case "ZigzagCP":
                consejo = "Prueba 2 Zigzag:\n Procuran mantenerse en el centro del paso, controlar la inclinación del vehículo para evitar volcar.";
                break;
            case "BachesCP":
                consejo = "Prueba 3 Baches: \n Mantener una velocidad constante reducida, intentar mantener las ruedas en contacto con el suelo, en caso de atasco retroceder y volver a avanzar.";
                break;
            case "EscalerasCP":
                consejo = "Prueba 4 Escaleras: \n Reducir la velocidad y avanzar con decisión, evitando la perpendicular con la escalera, recomendable afrontar la escalera un poco de lado de forma que cada rueda contacte con un escalón diferente.";
                break;
            case "GrietasCP":
                consejo = "Prueba 5 Grietas: \n Velocidad reducida, afrontar las grietas en diagonal para evitar que las dos ruedas entren a la vez en la grieta.";
                break;
                //  default:
                //    numeroCP = 0;
                //  break;
        }

        consejosText.text = consejo;

    }
    // Activate the checkpoint
    private void ActivarCheckPoint()
    {
       

        
             
            foreach (GameObject cp in ListaPuntosControl)
            {
                cp.GetComponent<CheckpointActivoPL>().activado = false;
                
                //cp.SetActive(false);
            }

            // We activate the current checkpoint
            activado = true;
           

            PuntoActivo = GetActiveCheckPoint();
        
    }

    void MaterialCheckpoint()
    {

        if (activado)
        {
            cartel.gameObject.GetComponent<MeshRenderer>().material = activo_tex;

        }
        else
        {
            cartel.gameObject.GetComponent<MeshRenderer>().material = noActivo_tex;
            
        }

    }

    // Get position of the last activated checkpoint
    public static int GetActiveCheckPoint()
    {
        // If player die without activate any checkpoint, we will return a default position
        int numeroCP = PuntoActivo;

        if (ListaPuntosControl != null)
        {
            foreach (GameObject cp in ListaPuntosControl)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckpointActivoPL>().activado)
                {
                    string nombre = cp.GetComponent<CheckpointActivoPL>().name;

                    switch (nombre)
                    {
                        case "RampaCP":
                            numeroCP = 0;
                            break;
                        case "ZigzagCP":
                            numeroCP = 1;
                            break;
                        case "BachesCP":
                            numeroCP = 2;
                            break;
                        case "EscalerasCP":
                            numeroCP = 3;
                            break;
                        case "GrietasCP":
                            numeroCP = 4;
                            break;
                            //  default:
                            //    numeroCP = 0;
                            //  break;
                    }

                    // break;
                }
            }
        }
        Debug.Log("GetActiveCheckPoint -- " + numeroCP);
        return numeroCP;
    }
}
