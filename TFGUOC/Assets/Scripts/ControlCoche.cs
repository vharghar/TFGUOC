using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCoche : MonoBehaviour
{
    // Start is called before the first frame update
    public WheelCollider RuedaDeDe; // ruedas colisiones
    public WheelCollider RuedaDeIz;
    public WheelCollider RuedaTrDe;
    public WheelCollider RuedaTrIz;

    public const double pi = System.Math.PI;

    public GameObject RuDeDe; // ruedas objetos del juego
    public GameObject RuDeIz;
    public GameObject RuTrDe;
    public GameObject RuTrIz;

    public float velocidadMax = 100f;  // velocidad maxima
    public float torqueMax = 200f;  // potencia maxima aplicada a las ruedas
    public float giroMaxAngulo = 45f;
    public float velocidadActual;
    public float torqueMaxFreno = 2200;

    private float Acelerar; // movimiento de avance del vehiculo
    private float Girar;  // movimiento de giro del vehiculo
    private float FrenarP;  // reducir la velocidad, freno de pie
    private float FrenoMano; // reducir velocidad o bloquear ruedas con el freno de mano
    private float Marcha; // posicion de la caja de cambios, marcha activa





    private Rigidbody rb; // cuerpo rigido del coche



    void Start()
    {
        rb = GetComponent<Rigidbody>();


        RuDeIz.transform.Rotate(0, 0, 90);
        RuDeDe.transform.Rotate(0, 0, 90);
        RuTrIz.transform.Rotate(0, 0, 90);
        RuTrDe.transform.Rotate(0, 0, 90);
        /*
        
        RuDeIz.transform.rotate = RuedaDeIzQ; // rotacion de las ruedas
        RuDeDe.transform.rotation = RuedaDeDeQ;
        RuTrIz.transform.rotation = RuedaTrIzQ;
        RuTrDe.transform.rotation = RuedaTrDeQ;
        */

    }

    // Update is called once per frame
    void FixedUpdate() // para hacer las fisicas mas realistas
    {
        Acelerar = Input.GetAxis("Vertical");
        Girar = Input.GetAxis("Horizontal");
        FrenarP = Input.GetAxis("Jump");

        RuedaDeDe.steerAngle = giroMaxAngulo * Girar; // angulo de giro de las ruedas
        RuedaDeIz.steerAngle = giroMaxAngulo * Girar;

        velocidadActual = 2 * (float)pi * RuedaDeDe.radius * RuedaDeDe.rpm * 60 / 1000; // velocidad de las ruedas en kmph

        if (velocidadActual < velocidadMax) //cuando se aprosime a la velocidad maxima no acelarar tan rapido
        {
            RuedaTrIz.motorTorque = torqueMax * Acelerar;// 2 ruedas motrices las que tienen la traccion 
            RuedaTrDe.motorTorque = torqueMax * Acelerar;

            RuedaDeIz.motorTorque = torqueMax * Acelerar;// las 4 ruedas motrices las que tienen la traccion 
            RuedaDeDe.motorTorque = torqueMax * Acelerar;
        }

        RuedaTrIz.brakeTorque = torqueMaxFreno * FrenarP;  // aplicamos la potencia del freno de pie a todas las ruedas
        RuedaTrDe.brakeTorque = torqueMaxFreno * FrenarP;
        RuedaDeDe.brakeTorque = torqueMaxFreno * FrenarP;
        RuedaDeIz.brakeTorque = torqueMaxFreno * FrenarP;

        
    }
    void Update() // para hacer las fisicas mas realistas
    {
        Quaternion RuedaDeIzQ; // rotacion de del collider de las ruedas
        Quaternion RuedaDeDeQ;
        Quaternion RuedaTrIzQ;
        Quaternion RuedaTrDeQ;
               
        Vector3 RuedaDeIzV; // posicion del collider de las ruedas
        Vector3 RuedaDeDeV;
        Vector3 RuedaTrIzV;
        Vector3 RuedaTrDeV;

        RuedaDeIz.GetWorldPose(out RuedaDeIzV, out RuedaDeIzQ); // angulo de giro de las ruedas
        RuedaDeDe.GetWorldPose(out RuedaDeDeV, out RuedaDeDeQ);
        RuedaTrIz.GetWorldPose(out RuedaTrIzV, out RuedaTrIzQ);
        RuedaTrDe.GetWorldPose(out RuedaTrDeV, out RuedaTrDeQ);

        RuDeIz.transform.position = RuedaDeIzV; // posicion de las ruedas
        RuDeDe.transform.position = RuedaDeDeV;
        RuTrIz.transform.position = RuedaTrIzV;
        RuTrDe.transform.position = RuedaTrDeV;

        RuDeIz.transform.rotation = RuedaDeIzQ; // rotacion de las ruedas
        RuDeDe.transform.rotation = RuedaDeDeQ;
        RuTrIz.transform.rotation = RuedaTrIzQ;
        RuTrDe.transform.rotation = RuedaTrDeQ;

        
    }
  }
