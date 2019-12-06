using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarVelocidad : MonoBehaviour
{
    public static Text vText;
    static float minEscala = 0;
    static float maxXEscala = 1.5f;
    static float maxYEscala = 1.3f;
    static MostrarVelocidad estaVelocidad;
    

    void Start()
    {
        estaVelocidad = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public static void MostrarV(float velocidad, float velocidadMin, float velocidadMax)
    {
        float escalaX = Mathf.Lerp(minEscala, maxXEscala, Mathf.InverseLerp(velocidadMin, velocidadMax, velocidad));
        float escalaY = Mathf.Lerp(minEscala, maxYEscala, Mathf.InverseLerp(velocidadMin, velocidadMax, velocidad));
        string velocidadText;
  
        estaVelocidad.transform.localScale = new Vector3(escalaX, escalaY);

        velocidadText = velocidad.ToString("F1");
        vText.text = velocidadText;
    }
}
