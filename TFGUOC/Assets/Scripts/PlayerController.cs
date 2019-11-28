using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
  
    public float velocidad = 100;
    public float maxAnguloGiro = 30;

   // public Vector3 centroDeMasa = Vector3.zero;
    public WheelCollider ruedaDelanteraIzquierda;
    public WheelCollider ruedaDelanteraDerecha;

    private bool ruedaTocaSuelo = false;
    private float fuerzaMotor = 0;

    void Start()
    {
    //    GetComponent<Rigidbody>().centroDeMasa = centroDeMasa;
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    void FixedUpdate()
    {
        fuerzaMotor = Input.GetAxis("Velocidad") * velocidad;
        if (ruedaTocaSuelo)
        {
            ruedaDelanteraIzquierda.motorTorque = fuerzaMotor;
            ruedaDelanteraDerecha.motorTorque = fuerzaMotor;
        }


        float rotation = Input.GetAxis("Direccion") * maxAnguloGiro;

        ruedaDelanteraIzquierda.steerAngle = rotation;
        ruedaDelanteraDerecha.steerAngle = rotation;


        ruedaDelanteraIzquierda.transform.localEulerAngles = new Vector3(0, rotation, 0);
        ruedaDelanteraDerecha.transform.localEulerAngles = new Vector3(0, rotation, 0);
        ruedaTocaSuelo = false;
    }
}
