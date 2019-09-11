using UnityEngine;
using System.Collections;


public class KeyController : MonoBehaviour{

    public AudioClip sound =  null;
    protected Transform position = null;


    // Start is called before the first frame update
    void Start()
    {
        position = transform;
    }

    public void OnCollisionEnter(Collision col){
        if(sound){
            AudioSource.PlayClipAtPoint(sound, position.position,100);
        }
    }

    public void OnTriggerEnter(Collider col){
        if(sound){
            AudioSource.PlayClipAtPoint(sound, position.position,100);
        }
    }

}