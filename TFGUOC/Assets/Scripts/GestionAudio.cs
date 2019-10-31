using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionAudio : MonoBehaviour
{

    public Slider VolumenMaestro;
    public Slider VolumenMusica;
    public Slider VolumenEfectos;
   // public AudioListener vol;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderAVolumen()
    {
        AudioListener.volume = VolumenMaestro.value;
    }
}
