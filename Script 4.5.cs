//4.5 комменты
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveRight;
    Transform Player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool back = false;    


    void Start()
    {
        Player =  GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, Player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            back = false;
        }
        if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
        {
            back = true;
            angry = false;
        }
        if(chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (back == true)
        {
            Back();
        }
    }

    void Chill()
    { 
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            moveRight = false;
        }
        else if(transform.position.x < point.position.x - positionOfPatrol)
        {
            moveRight = true;
        }
        if(moveRight == true)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        speed = 3;
    }

    void Back()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        speed = 4;
    }
}
