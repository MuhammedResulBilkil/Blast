using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(GameController).Name;
                    _instance = go.AddComponent<GameController>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    //[HideInInspector]
    //public bool gameOver = false;
    public Player player;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = string.Format("High Score: {0}", player.playerHighScore);
        scoreText.text = string.Format("Score: {0}", player.playerScore);
    }

    public void Score(int scorePoint)
    {
        player.playerScore += scorePoint;
        scoreText.text = string.Format("Score: {0}", player.playerScore);
        if(player.playerScore >= player.playerHighScore)
        {
            player.playerHighScore = player.playerScore;
            highScoreText.text = string.Format("High Score: {0}", player.playerHighScore);
        }

        player.SavePlayer();
    }

    private void Update()
    {
        if (!scoreText)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    public void RestartGame()
    {
        EnemySpawnController.Instance.ResetPositions();
        player.transform.position = Vector2.zero;
        player.gameObject.SetActive(true);
        
        player.playerScore = 0;
        Score(0);
    }

}
