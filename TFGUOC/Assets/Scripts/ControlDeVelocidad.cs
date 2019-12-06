using UnityEngine;
using System.Collections;

public class ControlDeVelocidad : MonoBehaviour
{
    public static float Velocidad;
    public Rigidbody Coche;
    public WheelCollider Rueda;
    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Velocidad = (2 * Mathf.PI * Rueda.radius) * Rueda.rpm * 60 / 1000;
    }

    public static float GetVelocity()
    {
        return Velocidad;
    }

}
