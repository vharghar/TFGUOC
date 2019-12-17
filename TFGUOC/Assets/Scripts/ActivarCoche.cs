﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;

public class ActivarCoche : MonoBehaviour
{
    public GameObject coche;
    public VehicleBase vpcoche;
    private GameManagerScript GMS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        if (GMS.cuentaAtrasAcabada)
        {
            coche.SetActive(true);
            
        }else
        {
            coche.SetActive(false);
        }


    }
}
