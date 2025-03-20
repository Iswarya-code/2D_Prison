using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    [SerializeField] Text ScoreDisplay;
    int score;

    [SerializeField] GameObject GameOverScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Red")
        {
            Destroy(collision.gameObject);
            score++;
            ScoreDisplay.text = score.ToString();
        }
    }

    private void Start()
    {
        GameOverScreen.SetActive(false);

    }
    private void Update()
    {
        if(score == 3)
        {
            GameOverScreen.SetActive(true);
        }

    }
}
