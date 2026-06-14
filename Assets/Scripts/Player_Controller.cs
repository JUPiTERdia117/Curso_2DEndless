using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    [SerializeField] private float speedIncrement = 0.01f;

    [SerializeField] private float fuerzaSalto = 1f;

    public Transform cameraTransform;

    private bool inGround,  dead = false, isCrouching = false;

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
        if(dead == true){
            return;
        }

     

         if(Input.GetKeyDown(KeyCode.Space) == true && inGround == true && isCrouching == false){

           

            Debug.Log("Salto");
            inGround = false;

            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                
            animator.SetBool("still", false);
            animator.SetBool("crouch", false);
            animator.SetBool("jump", true);


            
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) == true && inGround == true && isCrouching == false){

            isCrouching = true;

            Debug.Log("Agachate");
            

            
                
            animator.SetBool("still", false);
            animator.SetBool("jump", false);
            animator.SetBool("rejoin", false);
            animator.SetBool("crouch", true);


            
        }

        if(Input.GetKeyUp(KeyCode.DownArrow) == true && inGround == true && isCrouching == true){

            isCrouching = false;

            Debug.Log("Deja de agacharte");
            

            
                
            animator.SetBool("still", false);
            animator.SetBool("jump", false);
            animator.SetBool("crouch", false);
            animator.SetBool("rejoin", true);


            
        }

        transform.position += transform.right * speed * Time.deltaTime;
        cameraTransform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;

        if(speed < 16f){
            speed += speedIncrement* Time.deltaTime;
        }
        
        
    }



  
    void OnCollisionEnter2D(Collision2D other){

        Debug.Log("Colisionaste con " + other.gameObject.name);

        
        if(other.gameObject.tag == "Obstacle"){
            //rb.constraints = RigidbodyConstraints2D.r;
            dead = true;
            animator.SetTrigger("dead");

            GM gameManager = FindObjectOfType<GM>();
            gameManager.gameOver = true;
            
        }
        
        
        if(other.gameObject.tag == "Piso"){
            
           Debug.Log("Tocaste el piso");
           animator.SetBool("jump", false);
           animator.SetBool("crouch", false);
           animator.SetBool("still", true);
           inGround = true;
           

            
        }
       
        
     
    }





}
