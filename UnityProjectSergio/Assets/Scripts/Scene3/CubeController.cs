using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public Material material;
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    // Start is called before the first frame update
    void Start(){
        material = GetComponent<Renderer>().material;
        material.color = Color.black;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void RotateCube(){
        transform.Rotate(new Vector3(45,45,45));
    }

    public void ScaleCube(float value){
        transform.localScale = new Vector3(value,value,value);
    }

    public void changeColor(int option){
        Debug.Log("Parametro: " + option);
        switch(option){
            case 0:
                Debug.Log("Option 1");
                material.color = Color.black;
                break;
            case 1:
                Debug.Log("Option 2");
                material.color = Color.red;
                break;
            case 2:
                Debug.Log("Option 3");
                material.color = Color.yellow;
                break;
        }
    }

    public void changeDimension(float option){
        


    }
}
