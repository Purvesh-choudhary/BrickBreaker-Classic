using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Ball ball{get; private set;}
    public Paddle paddle{get; private set;}
    public Brick[] bricks;

    public int level = 1;
    public int score = 0;
    public int lives = 3;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;  
    }

    void Start()
    {
        NewGame();
    }

    void NewGame()
    {
        score = 0;
        lives = 3;
        LoadLevel(1);
    }

    void LoadLevel(int level){
        this.level = level;
        SceneManager.LoadScene("Level"+level);
    }


    void ResetLevel(){
        SoundManager.Instance.PlaySound("Miss");
        UIManager.Instance.UpdateLivesUI(lives);
        ball.Reset();
        paddle.Reset(); 
    }

    void GameOver(){
        NewGame();
    }

    void OnSceneLoaded(Scene scene , LoadSceneMode  mode){
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }


    public void Hit(Brick brick){
        score += brick.points;
        SoundManager.Instance.PlaySound("Hit");    
        UIManager.Instance.UpdateScoreUI(score);
        if(Cleared()){
            LoadLevel(level+1);
        }
    }


    bool Cleared(){
        for(int i =0 ; i < bricks.Length ; i ++){
            if(bricks[i].gameObject.activeInHierarchy && !bricks[i].isUnbreakable){
                return false;
            }
        }
        return true;
    }


    public void Miss(){
        lives--;
        if(lives>0){
            ResetLevel();
        }else{
            GameOver();
        }
    }

}
