using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBracket : MonoBehaviour {


    public float speed = 30;
    public string axis = "Vertical" ; 


    // Use this for initialization
    void Start() {

        


    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate()
    {
        float y = Input.GetAxisRaw(axis);

    GetComponent<Rigidbody2D>().velocity = new Vector2(0, y) * speed;
    }
    
        
     
}
