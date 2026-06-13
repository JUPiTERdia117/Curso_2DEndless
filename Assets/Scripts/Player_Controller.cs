using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    [SerializeField] private float speedIncrement = 0.01f;

    [SerializeField] private float fuerzaSalto = 1f;

    private bool inGround = false;



    private Rigidbody2D rb;

   
    void Awake(){

        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y > 1.005f){
            inGround = false;
            
        }else{
            inGround = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) == true && inGround == true){

            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

            
        }

        

        transform.position += transform.right * speed * Time.deltaTime;

        speed += speedIncrement* Time.deltaTime;
        
    }

    void OnTriggerEnter2D(Collider2D other){
       

        if(other.gameObject.tag == "Obstacle"){
            inGround = true;

            Debug.Log("Game Over");

            GM gameManager = FindObjectOfType<GM>();
            gameManager.gameOver = true;
            
        }

     
    }





}
