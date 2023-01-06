using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    
    int score= 0;
    public Text scoreText;
    public Text ScoreMenu;

    bool gameOverBL;
    public int life;
    public GameObject lifeObject;
    public GameObject panelGameOver;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        if (!gameOverBL)
        {
            score++;
            scoreText.text = score.ToString();
            ScoreMenu.text = score.ToString();
           
        }
    }
    public void DecreaseLife()
    {
        if (life > 0)
        {
            life--;
            
            lifeObject.transform.GetChild(life).gameObject.SetActive(false); 
            
            Debug.Log(life);

        }
        else if (life < 1)
        {
            gameOverBL = true;
            
            GameOver();
        }

    }
    public void GameOver()
    {
        SpawnGameObjects.instance.StopSpawningBox();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        panelGameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
