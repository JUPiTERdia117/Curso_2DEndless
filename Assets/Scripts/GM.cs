using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{

    public bool gameOver = false;

    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreText, highScoreText;

    [SerializeField] private AudioClip gameoverSound;
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] GameObject[] goToDisableOnGameOver;

    private int highScore = 0, score = 0;

    bool endGame = false;
    private GameObject player;

    int scoreOffset = 0;

    void Awake(){
        player = FindObjectOfType<Player_Controller>().gameObject;
        scoreOffset = (int)player.transform.position.x;
        audioSource.clip = music;
        audioSource.Play();

        highScore = PlayerPrefs.GetInt("HighScore", 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true){
            if(!endGame){ // Evita que se ejecute varias veces

                EndGame();
                
            }
            return;
        }
        
            
       
            
        score = (int)(player.transform.position.x - scoreOffset);
        scoreText.text = "" + score;
        
        
        
        
    }

    void EndGame(){

        foreach(GameObject go in goToDisableOnGameOver){
            go.SetActive(false);
        }

        if(score > highScore){
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.text = "High Score: " + highScore;

        audioSource.Stop();
        audioSource.loop = false;

        audioSource.clip = gameoverSound;
        audioSource.Play();
        gameOverPanel.SetActive(true);
        endGame = true;
    }

    public void Restart(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause(){
        Time.timeScale = 0f;
        
    }

    public void Resume(){
        Time.timeScale = 1f;
        
    }
}
