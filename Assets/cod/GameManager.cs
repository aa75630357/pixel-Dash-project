using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ground;
    public GameObject ground1;
    public GameObject ground2;
    public GameObject ground3;
    public GameObject ground4;
    public GameObject ground5;
    public GameObject ground6;
    public GameObject player;
    public GameObject GroundMaker;
    public GameObject GameTitle;
    public AudioManager MusicPlay;
    float Distance = 0f;
    public TextMeshProUGUI score;
    public TextMeshProUGUI LastScore;
    float LastDistance = 0f;
    bool GameStarted = false;

    bool isGameOver = false; 
    public PlayerMovement playerMovement;
    void Start()
    {
        MusicPlay.PlayTitle();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted == false && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        if (GameStarted)
        {
            Distance += GroundMove.speed * Time.deltaTime;
            //text是顯示文字在遊戲$這是必須寫""和這個一樣{這是要引用宣告才要}一般不用F0是零位小數
            score.text = $"{Distance:F0}m";
        }
        if (playerMovement.isDead && !isGameOver)
        {
            GameOver();
        }
    }


    void StartGame()
    {
        score.gameObject.SetActive(true);
        GameStarted = true;
        ground.SetActive(true);
        ground1.SetActive(true);
        ground2.SetActive(true);
        ground3.SetActive(true);
        ground4.SetActive(true);
        ground5.SetActive(true);
        ground6.SetActive(true);
        GroundMaker.SetActive(true);
        player.SetActive(true);
        GameTitle.SetActive(false);
        MusicPlay.StopAudio();
        MusicPlay.Playbgm();

    }
    void GameOver()
    {
        isGameOver = true;
        LastDistance = Distance;
        score.gameObject.SetActive(false);
        LastScore.gameObject.SetActive(true);
        LastScore.text = $"{LastDistance:F0}m";
    }
}
