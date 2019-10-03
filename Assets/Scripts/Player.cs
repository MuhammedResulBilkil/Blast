using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    [HideInInspector]
    public int playerScore;
    [HideInInspector]
    public int playerHighScore;

    Camera cam;
    Rigidbody2D rb2d;
    Vector2 movement;
    Vector2 mousePos;
    //Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        LoadPlayer();
        //pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //transform.Translate(movement * moveSpeed * Time.deltaTime);

        //transform.position += new Vector3(movement.x,movement.y,0)*moveSpeed*Time.deltaTime;

    }

    private void FixedUpdate()
    {
        // MovePosition yerine velocity kullanmanin aciklamasi:
        // https://forum.unity.com/threads/particle-system-distance-rate-rigidbody-2d.445785/#post-3038484

        rb2d.velocity = movement * moveSpeed; 
        // rigidbody ile karakteri ilerletmen daha iyi cunku arkada calisan fizik motoruyla is yaptığından dolayı.
        // Eger transform dan karakteri ilerletirsen, bir objeye carptiginda sen surekli objeye ilerlemeye calistiginda fizik motoru
        // seni objenin icine girmeni engellemek icin objeyle ilk temas ettigin yere geri koyar. Bundan dolayi 
        // objede surekli bir oynama gorulur objenin collider'i na surekli ilerlerken. Eger Rigidbody ile yaparsan bu sorun ortadan
        // kalkmis olur.
        // Burada Time.fixedDeltaTime kullanmana gerek yok. Cunku velocity zaten "distance / time" dan olusuyor.

        Vector2 lookDir = mousePos - rb2d.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb2d.SetRotation(angle);

    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerHighScore = data.highScore;
        GameController.Instance.highScoreText.text = string.Format("High Score: {0}", playerHighScore);
    }

}
