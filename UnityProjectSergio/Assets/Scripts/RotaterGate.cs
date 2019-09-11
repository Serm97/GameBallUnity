using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterGate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3(360,0,0)*Time.deltaTime*3); //Rotation effect to object  deltatime = seconds
    }
}
