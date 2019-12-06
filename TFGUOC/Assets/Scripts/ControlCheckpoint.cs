using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public int controlAct;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PuntoDeControl")
        {
            controlAct = CheckpointActivo.GetActiveCheckPoint();
            RestaurarCoche.ActualizarControlActivo(controlAct);
        }
    }


}
