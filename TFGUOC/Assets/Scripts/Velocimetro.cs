using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocimetro : MonoBehaviour
{
    // Start is called before the first frame update
    public float actSpeed = 0;
    public string velocidadText;
    public string inclinacionText;
    public Transform inclinacion;
    public GameObject elCoche;
    public float minSp;
    public float maxSp;
    public bool isKmh = true; // true muestra Kmh si False muestra Millas Mph
    public Text verVelocidad;
    public Text verInclinacion;


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnGUI()
    {
    

        ActualizarVelocidad();
        ActualizarInclinacion();
      
        ActualizarGUI();

      
    }

    void ActualizarVelocidad()
    {
        if (isKmh == true)
        {

            actSpeed = this.transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;

        }
        else if (isKmh == false)
        {

            actSpeed = this.transform.GetComponent<Rigidbody>().velocity.magnitude * 2.237f;

        }

        velocidadText = actSpeed.ToString("000");
       
    }

    void ActualizarInclinacion()
    {
       
        inclinacion.rotation = transform.GetComponent<Rigidbody>().rotation;
        float incX = inclinacion.rotation.x * 100;
        float incY = inclinacion.rotation.y * 100;
        float incZ = inclinacion.rotation.z * 100;
        inclinacionText = " X: " + incX.ToString("000") + " - Y: " + incY.ToString("000") + " - Z: " + incZ.ToString("000");

    }

    void ActualizarGUI()
    {
        verVelocidad.text = velocidadText;
        verInclinacion.text = inclinacionText;

    }
}
