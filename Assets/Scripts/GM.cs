using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{

    public bool gameOver = false; //bool de juego terminado

    public GameObject gameOverPanel; //referencia a panel de gameOver

    public TextMeshProUGUI scoreText, highScoreText; //Referencia a textos de puntaje

    [SerializeField] private AudioClip gameoverSound; //Referencia a sonido de gameover
    [SerializeField] private AudioClip music; //referencia a música de fondo
    [SerializeField] private AudioSource audioSource; //referencia a fuente de audio

    [SerializeField] GameObject[] goToDisableOnGameOver; //referencia de objetos a desactivar cuando se pierde

    private int highScore = 0, score = 0; //variables de puntaje

    bool endGame = false; //bool para terminar el juego (si ya se perdio)
    private GameObject player; //judador

    int scoreOffset = 0; //offset de puntaje

    void Awake(){
        player = FindObjectOfType<Player_Controller>().gameObject; //obtiene script del jugador
        scoreOffset = (int)player.transform.position.x; //obtiene obset de puntaje
        audioSource.clip = music; //asigna musica de fondo a audio source
        audioSource.Play(); //reproduce audiosource

        highScore = PlayerPrefs.GetInt("HighScore", 0); //obtiene puntaje más alto actual (si no hay lo pone como 0)

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si se perdió el juego
        if(gameOver == true){ 
            if(!endGame){ // Evita que se ejecute varias veces

                EndGame();//Función que se encarga de terminar juego
                
            }
            return;
        }
        
            
       
        //actualiza texto del puntaje    
        score = (int)(player.transform.position.x - scoreOffset);
        scoreText.text = "" + score;
        
        
        
        
    }

    void EndGame(){

        //desactiva objetos a desactivar
        foreach(GameObject go in goToDisableOnGameOver){
            go.SetActive(false);//desactiva objeto
        }

        //si el puntaje actual es el mayor ese es el nuevo high score
        if(score > highScore){
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.text = "High Score: " + highScore; //actualiza texto de high score

        audioSource.Stop();//detiene audiosource
        audioSource.loop = false; //detiene loop de audiosource

        audioSource.clip = gameoverSound; //asigna sonido de game over a audio source
        audioSource.Play(); //reproduce audio source
        gameOverPanel.SetActive(true); //activa panel de game over
        endGame = true; //termina el juego
    }

    public void Restart(){ // Reinicia el juego
       SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Obtiene nombre actual de escena y la vuelve a cargar
    }

    public void Pause(){ //Pausa juego
        Time.timeScale = 0f; //Para el tiempo (Función Update deja de ejecutarse)
        
    }

    public void Resume(){//Reanuda juego (Función Update vuelve a ejecutarse)
        Time.timeScale = 1f;
        
    }
}
