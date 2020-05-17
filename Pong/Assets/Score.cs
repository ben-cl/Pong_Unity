using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.collider.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            col.collider.SendMessage("RestartGame", 1, SendMessageOptions.RequireReceiver);



        }
    }
}
