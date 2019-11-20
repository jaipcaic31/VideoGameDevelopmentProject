using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;


    private Rigidbody2D rb2D;
    private Animator anim;
    private bool jump;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));//assing Velocity
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) 
        {

            jump = true;

        }

    }

    void FixedUpdate() {

        {//Añadir Fricción al tocar suelo

            Vector3 friction = rb2D.velocity;
            friction.x *= 0.75f;

            if (grounded) { //Si toca Suelo 

                rb2D.velocity = friction; //Disminuimos la velocidad por 0.75

            }
        
        }

        float h = Input.GetAxis("Horizontal");
        rb2D.AddForce(Vector2.right * speed * h);

        if (h > 0.01f) {

            transform.localScale = new Vector3(1f,1f,1f);
        
        }

        else if (h < -0.01f)
        {

            transform.localScale = new Vector3(-1f, 1f, 1f);

        }

        { //Para no pasarme el limite de la velocidad en x

            float limitedVelocity = Mathf.Clamp(rb2D.velocity.x,-maxSpeed,maxSpeed);
            rb2D.velocity = new Vector2(limitedVelocity, rb2D.velocity.y);

        }

        if (jump)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x,0);
            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;

        }
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-3, 0, 0); //Si nos salimos de la escena, ir a esa position
    }

}
