using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour{
    
    private Rigidbody rb;
    
    public float speed = 5; //The sentence public show in the inspector this variable
    public Transform particlesSpike;
    public Transform particlesKey;
    public Transform particlesArc;
    private ParticleSystem systemParticles;
    private Vector3 position;
    private int cubos;
    private AudioSource audioRecolectable;
    private int keys;
    public GameObject block;
    public GameObject platform;
    public GameObject gate;
    public Text textCounter;
    public Text textGoal;
    
    
    // Start is called before the first frame update
    void Start(){
        systemParticles = particlesSpike.GetComponent<ParticleSystem>();
        systemParticles.Stop();

        rb = GetComponent<Rigidbody>();                                          //Get components of game object that contain this script
        audioRecolectable = GetComponent<AudioSource>();
        textCounter.text = "Consigue los 5 escudos para anotar el gol.";
        transform.localScale = new Vector3(3,3,3);
        keys = 0;
        
    }

    //Exec once each frame after of physic calculates 
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");                      //Input.GetAxis return -1 to 1  
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 is a array of size 3 X,Y,Z 
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Rotate (new Vector3(0,0,180)*Time.deltaTime); //Rotation effect to object  deltatime = seconds

        //Apply movement to component Rigidbody
        rb.AddForce(move*speed);
    }

    //This a automatic function that listen a event of collation between anything object
    void OnTriggerEnter(Collider otherObject){
        
        Debug.Log(otherObject.gameObject.tag);                                  // "other" is a reference of collider that touch this object
        if(otherObject.gameObject.CompareTag("spike")){
           actionForSpike(otherObject);
        }

        if(otherObject.gameObject.CompareTag("key")){
            actionForKey(otherObject);
            keys++;
            textCounter.text = "Llaves: \n" + keys;
            if(keys == 1){
                finishRecollection();
            }
        }        
    }


    void OnCollisionEnter(Collision otherObject){
        if(otherObject.gameObject.CompareTag("ground")){
             Destroy(platform);
        }

        if(otherObject.gameObject.CompareTag("goal")){
            textCounter.text = "";
            textGoal.text = "GOOOOOOOOOOOOOOL";
            StartCoroutine("ChangeLevel");
        }

        if(otherObject.gameObject.CompareTag("block")){
            textCounter.color = Color.red;
            textCounter.text = "PERDISTE :(";
           StartCoroutine("ChangeLevel");
        }

    }

    void actionForKey(Collider otherObject){
        otherObject.gameObject.SetActive(false);
        activeParticles(otherObject.gameObject.transform.position, particlesKey);
                
    }

    void actionForSpike(Collider otherObject){
        otherObject.gameObject.SetActive(false);
        transform.localScale = new Vector3(3,0.2f,3);
        speed = 0;
        transform.Rotate (new Vector3(0,0,0));
        activeParticles(otherObject.gameObject.transform.position, particlesSpike);
        audioRecolectable.Play();
        StartCoroutine("tempEffect");
    }

    void finishRecollection(){
        block.SetActive(false);
        activeParticles(block.gameObject.transform.position, particlesArc);
        
    }

    void activeParticles(Vector3 position, Transform particles){
        
        particles.position = position;
        systemParticles = particles.GetComponent<ParticleSystem>();
        systemParticles.Play();

    }

    public IEnumerator tempEffect(){

        yield return new WaitForSecondsRealtime(5.0f); 
        transform.localScale = new Vector3(3,3,3);
        transform.Rotate (new Vector3(0,0,180)*Time.deltaTime);
        audioRecolectable.Play();
        speed = 5;
    }

    public IEnumerator ChangeLevel(){
        yield return new WaitForSecondsRealtime(5.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
