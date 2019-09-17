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
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
                if(_instance == null)
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
    [HideInInspector]
    public bool gameOver = false;

    float playerScore;
    float playerHighScore;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = string.Format("High Score: {0}", playerHighScore);
        scoreText.text = string.Format("Score: {0}", playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score(int scorePoint)
    {
        playerScore += scorePoint;
        scoreText.text = string.Format("Score: {0}", playerScore);
        if(playerScore >= playerHighScore)
        {
            playerHighScore = playerScore;
            highScoreText.text = string.Format("High Score: {0}", playerHighScore);
        }

    }

}
