using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public GUISkin layout;

    GameObject theBall;


	// Use this for initialization
	void Start () {

        theBall = GameObject.FindGameObjectWithTag("Ball");

	}



    public static void Score(string wallID)
    {

        if(wallID == "WallRight")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }



    void OnGUI()
    {

        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150, 100, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 130, 100, 100, 100), "" + PlayerScore2);


        if(GUI.Button(new Rect(Screen.width / 2 - 100, 100, 200, 60), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;

            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if(PlayerScore1 == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Winner: Player 1;");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if(PlayerScore2 == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Winner: Player 2;");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
