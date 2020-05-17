using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : MonoBehaviour {


    Transform theBall;
    Rigidbody2D myRacket;

    float ballPosY;
    float ballVelX;



	// Use this for initialization
	void Start () {

        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
        //theBall = GameObject.Find("Ball").transform;

        // script attach at bracket 
        myRacket = GetComponent<Rigidbody2D>();


	}
	
	// Update is called once per frame
	void Update () {

        ballPosY = theBall.position.y; // + Random.Range(-1.5f, 1.5f);

        ballVelX = theBall.GetComponent<Rigidbody2D>().velocity.x;


        if(ballVelX != 0)
        {

            // ball is in motion 
            if(ballPosY > myRacket.position.y + 0.2)
            {
                myRacket.velocity = new Vector2(0, 5);

            }
            else if(ballPosY < myRacket.position.y - 0.2)
            {
                myRacket.velocity = new Vector2(0, -5);
            }
            else
            {
                myRacket.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            //ball still at 00

            if(myRacket.position.y > 0)
            {
                myRacket.velocity = new Vector2(0, -5);
                
            }
            else
            {
                myRacket.velocity = new Vector2(0, 5);

            }


        }


	}
}
