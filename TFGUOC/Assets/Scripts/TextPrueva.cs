using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrueva : MonoBehaviour
{
    // Start is called before the first frame update
    public Text miTexto = null;
    void Start()
    {
        miTexto.text = "Hola Caracola";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
