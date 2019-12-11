using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapControl : MonoBehaviour
{
    public GameObject VueltaCompletaTrig;
    public GameObject CP_1;
    // Start is called before the first frame update
    void Start()
    {
      }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter()
    {
       
        VueltaCompletaTrig.SetActive(true);
        CP_1.SetActive(false);

    }
}
