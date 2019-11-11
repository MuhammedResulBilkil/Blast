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
                //if (_instance == null)
                //{
                //    GameObject go = new GameObject();
                //    go.name = typeof(GameController).Name;
                //    _instance = go.AddComponent<GameController>();
                //    DontDestroyOnLoad(go);
                //}
            }
            return _instance;
        }
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    //[HideInInspector]
    //public bool gameOver = false;
    public Player player;

    // private Coroutine co;

    public InitializeAdsScript unityAds;

    public bool IsPlayerDead = false;

    private void Awake()
    {
        if (_instance == null) // burada bir bug var. AudioController da oluyor ama burada işlemiyor...
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        unityAds = GetComponent<InitializeAdsScript>();
        DontDestroyOnLoad(this.gameObject); // 
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
        if (player.playerScore >= player.playerHighScore)
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

        if (!IsPlayerDead)
            CancelInvoke("UnityAdStateCheck");

    }

    public void RestartGame()
    {
        EnemySpawnController.Instance.ResetPositions();
        player.transform.position = Vector2.zero;
        player.gameObject.SetActive(false);


        player.playerScore = 0;
        Score(0);
        //Debug.Log("Is Player Dead = " + IsPlayerDead);

        if (IsPlayerDead)
        {
            unityAds.ShowAd();
            // co = StartCoroutine(UnityAdStateCheck());
            // player.gameObject.SetActive(true);
            InvokeRepeating("UnityAdStateCheck", 0, 0.5f);
        }
        else
        {
            player.gameObject.SetActive(true);
        }

        Debug.Log("Game Restarted...");
    }

    void UnityAdStateCheck()
    {
        if (!unityAds.isAdShowing)
        {
            player.gameObject.SetActive(true);
            //StopCoroutine(co);
            //yield return null;
        }

        //Debug.LogError("Coroutine is Working !!!!");

        Debug.LogError("InvokeRepeating is Working !!!!");

        //yield return new WaitForSeconds(1.0f);

        //yield return UnityAdStateCheck();



    }

}
