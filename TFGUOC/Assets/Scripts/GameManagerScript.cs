using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool cuentaAtrasAcabada = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SetFalseCuentaAtras()
    {
        cuentaAtrasAcabada = false;
    }
}
