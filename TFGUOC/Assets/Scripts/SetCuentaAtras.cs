using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCuentaAtras : MonoBehaviour
{
    private GameManagerScript GMS;

    public void SetCuentaAtrasAhora()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.cuentaAtrasAcabada = true;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
