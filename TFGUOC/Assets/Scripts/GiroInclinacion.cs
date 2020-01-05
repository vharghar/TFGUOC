using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroInclinacion : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform inclinacionCoche;
    public Transform imagenI;
    float rotacionX = 0;
    //float rotacionY = 0;
    //float rotacionZ = 0;
    // Quaternion rota;



    // Update is called once per frame
    void Update()
    {
        //   float rotDelta = Quaternion.Angle(rota, inclinacionCoche.transform.rotation);
        // rota = inclinacionCoche.transform.rotation;

        rotacionX = inclinacionCoche.transform.localRotation.x;
       // rotacionY = inclinacionCoche.transform.localRotation.y;
        //rotacionZ = inclinacionCoche.transform.localRotation.z;
        

        Vector3 temp = transform.rotation.eulerAngles;
        temp = new Vector3(0f, 0f, 0f);
        temp.z = rotacionX * (-100);
        transform.localRotation = Quaternion.Euler(temp);



    }
}
