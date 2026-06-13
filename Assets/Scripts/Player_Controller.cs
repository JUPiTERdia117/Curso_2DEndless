using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    [SerializeField] private float speedIncrement = 0.01f;

    [SerializeField] private float fuerzaSalto = 1f;

    public Transform cameraTransform;

    private bool inGround, greatJump = false, firstLanding = true;

    private Animator animator;



    private Rigidbody2D rb;

   
    void Awake(){

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     

         if(Input.GetKeyDown(KeyCode.Space) == true && inGround == true){

           


            inGround = false;

            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                

            animator.SetTrigger("release");

            
        }

        transform.position += transform.right * speed * Time.deltaTime;
        cameraTransform.position += transform.right * speed * Time.deltaTime;

        speed += speedIncrement* Time.deltaTime;
        
    }



    void OnTriggerEnter2D(Collider2D other){
        
      
       

        if(other.gameObject.tag == "Obstacle"){
            

            GM gameManager = FindObjectOfType<GM>();
            gameManager.gameOver = true;
            
        }

     
    }
    
    void OnCollisionEnter2D(Collision2D other){

        

        
        inGround = true;
        if(other.gameObject.tag == "Piso"){
            
           Debug.Log("Tocaste el piso");
            animator.SetTrigger("landing");
          

            
        }
       
        
     
    }





}
