using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : ProcessingLite.GP21
{
    int numberOfBalls = 20;
    public int numberOfActiveBalls = 0;
    //public static Transform playerPos;

    Ball[] balls;

    void Start()
    {


        StartCoroutine(BallCoroutine());

    }

    IEnumerator BallCoroutine()
    {
        balls = new Ball[numberOfBalls];

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball(Random.Range(1, 12), Random.Range(1, 7), Random.Range(0, 256), Random.Range(1, 3));
            numberOfActiveBalls++;
            yield return new WaitForSeconds(3);
        }
    }

    void Update()
    {
        for (int i = 0; i < numberOfActiveBalls; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();
            balls[i].BounceAlongEdges();
            if (balls[i].CircleCollision(Player.x, Player.y, (2f / 2), balls[i].position.x, balls[i].position.y, (balls[i].size / 2)))
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }


}


