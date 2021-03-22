using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;





public class Game_Manager : MonoBehaviour
{

    public float Score;

    public Text scoreBoard;

    public Text gameOver;

    public Button restart;

    public Button start;

    public Text description;

    Text restat;
    Text startT;

    bool paused;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Score = 1000;
        gameOver.enabled = false;
        restart.enabled = false;
        restart.image.enabled = false;
         restat =   restart.GetComponentInChildren<Text>();

        restat.enabled = false;
    }

    private void OnEnable()
    {
        blockMove.onColliddde += updateScore;
        blockMove.wallhit += updateNEgativeScore;
    }


    // Update is called once per frame
    void Update()
    {
       // pausegame();

        scoreBoard.text = "Score" + Score;

        if(Score <= 0)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            restart.enabled = true;
            restart.image.enabled = true;
            restat.enabled = true;

          
        }

    }

    void updateScore()
    {
        Score = Score + 10;

        Debug.Log(Score);

    }

    void updateNEgativeScore()
    {
        Score = Score - 100;
    }

   public  void restartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void startgame()
    {
        Time.timeScale = 1;

        start.enabled = false;
        start.image.enabled = false;
        startT = start.GetComponentInChildren<Text>();

        startT.enabled = false;

        description.enabled = false;
    }
   
   /* public void pausegame()
    {
        // paused = false;

        int click = 0;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            


            click++;

            click = click % 2;

            
        }
        

        if (click == 0)
        {
            paused = false;
        }

        if (click == 1)
        {
            paused = true;
        }

        Time.timeScale = paused ? 0 : 1;
        
    }
   */


  



}
