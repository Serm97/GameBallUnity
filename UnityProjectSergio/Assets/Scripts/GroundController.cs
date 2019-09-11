using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundController : MonoBehaviour{

    public GameObject ball;
   

    // Start is called before the first frame update
    void Start(){

        ramdomInitialPosition();
        
    }


    void ramdomInitialPosition(){
        int pos = UnityEngine.Random.Range(1,6);
        Vector3 position = new Vector3(0,0,0);

        switch (pos){
            case 1:
                position = new Vector3(-5.89f,6.75f,-6.48f);
                break;
            case 2:
                position = new Vector3(6.23f,6.75f,-6.85f);
                break;
            case 3:
                position = new Vector3(6.85f,6.75f,6.53f);
                break;
            case 4:
                position = new Vector3(-6.97f,6.75f,6.84f);
                break;
            case 5:
                position = new Vector3(-3.54f,6.75f,-0.54f);
                break;
        }

        ball.transform.position = position;
    }
}
