using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;

public class RestaurarCochePL : MonoBehaviour
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
            controlActivo = CheckpointActivoPL.GetActiveCheckPoint();

            ResetearCoche();
        }
    }
    void ResetearCoche()
    {


        // Now we reset the car!
        float posX = puntosDeControl[controlActivo].position.x;
        float posY = puntosDeControl[controlActivo].position.y + alturaSeguridad;
        float posZ = puntosDeControl[controlActivo].position.z;
        // posicionamos el coche en el punto de respawn
        transform.position = new Vector3(posX, posY, posZ);
       
        transform.localRotation = puntosDeControl[controlActivo].localRotation;
        coche.velocity = Vector3.zero;
        //restauramos el coche
        VehiclePhysics.VPResetVehicle.ResetVehicle(vpcoche, alturaSeguridad);

       
    }

    public static void ActualizarControlActivo(int CtrlAct)
    {
        controlActivo = CtrlAct;
    }
}
