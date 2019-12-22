using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointActivo : MonoBehaviour
{
    public bool activado = false;
    public bool siguiente = false;
    public static GameObject[] ListaPuntosControl;
    public GameObject[] ListaCP;
    public static int PuntoActivo = 0;
    public Material activo_tex;
    public Material noActivo_tex;
    public Material siguienteActivo_tex;
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
            MostrarConsejos(this.GetComponent<CheckpointActivo>().name);
        }
        else
        {
         //   Debug.Log(other.tag);

        }
        Debug.Log(this.GetComponent<CheckpointActivo>().name + " -- " + PuntoActivo);
    }

    void MostrarConsejos(string nombreCheckpoint)
    {
        string consejo="Inicio";


        switch (nombreCheckpoint)
        {
            case "RampaCP":
                consejo = "Prueva 1 Rampa:\n Colocarse en la base y subir a una velocidad constante, no parar ni frenar a media subida";
                break;
            case "ZigzagCP":
                consejo = "Prueva 2 Zigzag:\n Procuran mantenerse en el centro del paso, controlar la inclinacion del vehiculo para evitar volcar";
                break;
            case "BachesCP":
                consejo = "Prueva 3 Baches: \n Mantener una velocidad constante reducida, intentar mantener las ruedas en contacto con el suelo, en caso de atasco retroceder y volver a avanzar";
                break;
            case "EscalerasCP":
                consejo = "Prueva 4 Escaleras: \n Reducir la velocidad y avanzar con decision, evitando la perpendicular con la escalera, recomendable afrontar la escalera un poco de lado de forma que cada rueda contacte con un escalon diferente";
                break;
            case "GrietasCP":
                consejo = "Prueva 5 Grietas: \n Velocidad reducida, afrontar las grietas en diagonal para evitar que las dos ruedas entren a la vez en la grieta";
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
        int puntoActivoSiguiente = PuntoActivo + 1;
        int puntoSiguienteSiguiente;
        int longitudLista = ListaPuntosControl.Length;
        
        string nombreThisCP = this.gameObject.name;
        string nombreNextCP;

        if (puntoActivoSiguiente < longitudLista)
        {
            nombreNextCP = ListaPuntosControl[puntoActivoSiguiente].gameObject.name;
        }
        else
        {
            nombreNextCP = ListaPuntosControl[0].gameObject.name;
            puntoActivoSiguiente = 0;
        }

        puntoSiguienteSiguiente = puntoActivoSiguiente + 1;

        if (puntoSiguienteSiguiente >= longitudLista) {
            puntoSiguienteSiguiente = 0;
        }

        if (nombreThisCP == "RampaCP")
        {
            foreach (GameObject cp in ListaPuntosControl)
            {
                cp.GetComponent<CheckpointActivo>().activado = false;
                cp.GetComponent<CheckpointActivo>().siguiente = false;
                //cp.SetActive(false);
            }

            // We activate the current checkpoint
            activado = true;
            // marcamos el siguiente checkpoint
            ListaPuntosControl[1].GetComponent<CheckpointActivo>().siguiente = true;

            PuntoActivo = GetActiveCheckPoint();

        }
        else{

            if (nombreThisCP == nombreNextCP) 
            {
        
                // We deactive all checkpoints in the scene
                foreach (GameObject cp in ListaPuntosControl)
                {
                    
                    cp.GetComponent<CheckpointActivo>().activado = false;
                    cp.GetComponent<CheckpointActivo>().siguiente = false;
                    //cp.SetActive(false);
                }

                // We activate the current checkpoint
                activado = true;
                // marcamos el siguiente checkpoint
                ListaPuntosControl[puntoSiguienteSiguiente].GetComponent<CheckpointActivo>().siguiente = true;
                
                PuntoActivo = GetActiveCheckPoint(); //actualizamos nuevo checkpoint

            }
            else
            {
               // Debug.Log("Error activando checkpoint");
            }
        }

    }
    
    void MaterialCheckpoint()
    {
        
        if (activado)
        {
            cartel.gameObject.GetComponent<MeshRenderer>().material = activo_tex;

        }
        else
        {
            if (siguiente)
            {
                cartel.gameObject.GetComponent<MeshRenderer>().material = siguienteActivo_tex;

            }
            else
            {
                cartel.gameObject.GetComponent<MeshRenderer>().material = noActivo_tex;

            }
            

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
                if (cp.GetComponent<CheckpointActivo>().activado)
                {
                    string nombre = cp.GetComponent<CheckpointActivo>().name;

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

