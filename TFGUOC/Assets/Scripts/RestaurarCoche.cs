using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;

public class RestaurarCoche : MonoBehaviour
{

    public KeyCode teclaDeRestauracion;
    public Transform[] puntosDeControl;
    public static int controlActivo = 0;
    public float alturaSeguridad = 2;
    public Rigidbody coche;
    public VehicleBase vpcoche;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teclaDeRestauracion))

        {
            controlActivo = CheckpointActivo.GetActiveCheckPoint();

            ResetearCoche();
        }
    }
    void ResetearCoche()
    {
        

       // float tempX = puntosDeControl[controlActivo].rotation.x;
        float tempY = puntosDeControl[controlActivo].rotation.y;
        // float tempZ = puntosDeControl[controlActivo].rotation.z;
        // Now we reset the car!
        float posX = puntosDeControl[controlActivo].position.x;
        float posY = puntosDeControl[controlActivo].position.y + alturaSeguridad;
        float posZ = puntosDeControl[controlActivo].position.z;
        transform.position = new Vector3(posX, posY , posZ);
        //transform.localRotation = Quaternion.Euler(0, puntosDeControl[controlActivo].localRotation.y, 0);
        transform.localRotation = puntosDeControl[controlActivo].localRotation;
        coche.velocity = Vector3.zero;
        VehiclePhysics.VPResetVehicle.ResetVehicle(vpcoche, alturaSeguridad);

        //transform.localRotation = puntosDeControl[controlActivo].localRotation;
    }

    public static void ActualizarControlActivo(int CtrlAct )
    {
        controlActivo = CtrlAct;
    }
}

