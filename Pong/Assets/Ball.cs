using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float speed = 30;

    private Vector2 vel;
    private Rigidbody2D rb2d;
   
    


    void Start() {
        // Initial Velocity
        //GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        rb2d = GetComponent<Rigidbody2D>();
        Invoke("ReleaseBall", 1);
    }


    void ReleaseBall()
    {

        if(Random.Range(0,2) < 1)
        {
            rb2d.velocity = new Vector2(1 * speed, Random.Range(-50, 50));
        }
        else
        {
            rb2d.velocity = new Vector2(-1 * speed, Random.Range(-50, 50));

        }

    }

    void ResetBall()
    {
        vel = new Vector2(0, 0);
        rb2d.velocity = vel;
        transform.position = Vector2.zero;

    }

    void RestartGame()
    {
        ResetBall();
        Invoke("ReleaseBall", 1);


    }



    


    void OnCollisionEnter2D(Collision2D col) {


        GetComponent<AudioSource>().Play();

        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft") {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight") {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }


    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
