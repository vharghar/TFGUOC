using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recomendacion : MonoBehaviour
{
    public KeyCode teclaRecomendacion;
   
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teclaRecomendacion))

        {
            if (panel.activeInHierarchy)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }

       
    }
    
}
