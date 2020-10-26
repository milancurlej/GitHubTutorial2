using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;
    public Text winText;
    public Text livesText;

    private int Lives = 3;

    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        livesText.text = "Lives: " + Lives.ToString();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetscoreValue();
        }
    }
    void SetscoreValue()
    {
        if (scoreValue >=8)
        {
            winText.text = "You Win Milan Curlej's Game! ";
        }
        if (scoreValue == 4)
        {
            transform.position = new Vector3(70.0f, 0.0f, 0.0f); 
        }
    }
    void SetLives()
    {
        if (Lives <=0)
        {
            Destroy(this);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}