using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointActivo : MonoBehaviour
{
    public bool activado = false;
    public static GameObject[] ListaPuntosControl;
    public static int PuntoActivo = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        ListaPuntosControl = GameObject.FindGameObjectsWithTag("PuntoDeControl");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Activate the checkpoint
    private void ActivarCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in ListaPuntosControl)
        {
            cp.GetComponent<CheckpointActivo>().activado = false;
            cp.SetActive(false);
        }

        // We activate the current checkpoint
        activado = true;
        int num = System.Array.IndexOf(ListaPuntosControl, this);
        Debug.Log(num);

        
    }
    
    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivarCheckPoint();
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
                        default:
                            numeroCP = 0;
                            break;
                    }
                   
                    break;
                }
            }
        }

        return numeroCP;
    }
}

