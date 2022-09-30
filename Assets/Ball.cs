using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite, so we get access to all functions
class Ball : ProcessingLite.GP21
{
    public Vector2 position;
    Vector2 velocity;
    //int color;
    public float size;

    public float speedModifier;

    int greenColorValue;
    int blueColorValue;
    int redColorValue;

    public Ball(float x, float y, int colorValue, float size)
    {
        position = new Vector2(x, y);

        //color = Random.Range(0, 256);
        //color = colorValue;
        greenColorValue = Random.Range(0, 256);
        blueColorValue = Random.Range(0, 256);
        redColorValue = colorValue;
        //Fill(0, Random.Range(0, 256), Random.Range(0, 256));


        this.size = size;
        //transform.localScale = new Vector2(size, size);

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }

    public void Draw()
    {
        Fill(redColorValue, blueColorValue, greenColorValue);
        Circle(position.x, position.y, size);
    }

    public void UpdatePos()
    {

        position += velocity * Time.deltaTime;
    }

    public void BounceAlongEdges()
    {


        if (position.y > Height)
        {
            velocity = Vector2.Reflect(velocity, Vector2.down);
        }

        if (position.y < 0)
        {
            velocity = Vector2.Reflect(velocity, Vector2.up);
        }

        if (position.x > Width)
        {
            velocity = Vector2.Reflect(velocity, Vector2.left);
        }

        if (position.x < 0)
        {
            velocity = Vector2.Reflect(velocity, Vector2.right);
        }


    }

    //Check collision, 2 circles
    //x1, y1 is the position of the first circle
    //size1 is the radius of the first circle
    //then the same data for circle number two

    //function will return true (collision) or false (no collision)
    //bool is the return type

    public bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1 + size2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }
    //A better way to do this is to have a circle object and pass the objects in to the function,
    //then we just have to pass 2 objects instead of 6 different values.
}



