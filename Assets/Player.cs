using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player : ProcessingLite.GP21
{
    private float speedModifier = 8;

    public static float x;
    public static float y;

    void Start()
    {

    }

    void Update()
    {

        x += Input.GetAxisRaw("Horizontal") * speedModifier * Time.deltaTime;
        y += Input.GetAxisRaw("Vertical") * speedModifier * Time.deltaTime;

        Background(0);
        Circle(x, y, 2);

        //BallController.playerPos.position = new Vector2(x, y);
    }
}
