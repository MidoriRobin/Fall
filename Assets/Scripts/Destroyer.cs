using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    public static int level = 1;
    public static int score;

    public static int state = 0;

    public Text scoreText;
    public Text gameOverText;
    public GameObject gameOverPanel;
    public GameObject sBorder;

    //void OnCollisionEnter2D (Collision2D col)
    //{
    //    if((col.gameObject.tag == "Player") || (col.gameObject.tag == "Platform"))
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}

    void Start()
    {
        gameOverPanel.SetActive(false);
        state = 0;
        score = 0;
        level = 2;
    }

    private void Update()
    {
        if(state == 1)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Hold this L, Score: " + score.ToString();
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(collision.gameObject);

            if (state != 1)
            {
                score += 1;
                scoreText.text = "Score: " + score.ToString();

                if (score % 10 == 0)
                {
                    level += 1;
                }
            }
            
        }

        else if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            state = 1;
        }
    }
        
}
