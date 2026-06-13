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

            StartCoroutine("Crouch");
            
        }

         if(Input.GetKeyUp(KeyCode.Space) == true && inGround == true){

            StopCoroutine("Crouch");


            inGround = false;

            if(greatJump == true){
                rb.AddForce(Vector2.up * fuerzaSalto*1.5f, ForceMode2D.Impulse);
                Debug.Log("Gran Salto");

                animator.SetTrigger("release");

                greatJump = false;
            }else{
                rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

                Debug.Log("Salto Normal");

                //animator.SetTrigger("jump");
            }
            
        }

        transform.position += transform.right * speed * Time.deltaTime;
        cameraTransform.position += transform.right * speed * Time.deltaTime;

        speed += speedIncrement* Time.deltaTime;
        
    }

    IEnumerator Crouch(){

        yield return new WaitForSeconds(1.0f);

        Debug.Log("Preparado para gran salto");

        animator.SetTrigger("crouch");

        greatJump = true;
    }

    void OnTriggerEnter2D(Collider2D other){
        
      
       
        Debug.Log("Game Over");
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Obstacle"){
            



            

            GM gameManager = FindObjectOfType<GM>();
            gameManager.gameOver = true;
            
        }

     
    }

    void OnCollisionEnter2D(Collision2D other){

        

        
        inGround = true;
        if(other.gameObject.tag == "Piso"){
            
            if(firstLanding == true){
                firstLanding = false;
                return;
            }
            Debug.Log("Aterrizaje");    
            animator.SetTrigger("landing");
          

            
        }
       
        
     
    }





}
