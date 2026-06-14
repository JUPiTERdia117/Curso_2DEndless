using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{

    public bool gameOver = false;

    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreText;

    private GameObject player;

    int scoreOffset = 0;

    void Awake(){
        player = FindObjectOfType<Player_Controller>().gameObject;
        scoreOffset = (int)player.transform.position.x;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true){
            gameOverPanel.SetActive(true);
        }else{
            scoreText.text = "" + (int)(player.transform.position.x - scoreOffset);
        }
        
    }

    public void Restart(){
        Application.LoadLevel(Application.loadedLevel);
    }
}
