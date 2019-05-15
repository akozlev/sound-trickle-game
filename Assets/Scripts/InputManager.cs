using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float speed = 5;
    private Animator anim;
    private Rigidbody2D rb;

    public float maxSpeed = 6.5f;
    public bool grounded;
    public float jumpHeight = 200;
    private bool jumpAvailable = true;
    public GameObject circle;
    public GameObject triangle;
    public GameObject square;
    private bool circleAvailable = true;
    private bool triangleAvailable = true;
    private bool squareAvailable = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circle = transform.GetChild(0).gameObject;
        triangle = transform.GetChild(1).gameObject;
        square = transform.GetChild(2).gameObject;

        circleAvailable = !circle.activeSelf;
        triangleAvailable = !triangle.activeSelf;
        squareAvailable = !square.activeSelf;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if ( Input.GetAxisRaw("J1Horizontal") == 1 || Input.GetAxisRaw("P1Horizontal") == 1 )
        {
            //rb.velocity = Vector2.right * Time.deltaTime * speed;
            rb.AddForce(Vector2.right*Time.deltaTime*speed);
        }
        else if ( Input.GetAxisRaw("J1Horizontal") == -1 || Input.GetAxisRaw("P1Horizontal") == -1 )
        {
            //rb.velocity = Vector2.left * Time.deltaTime * speed;
            rb.AddForce(Vector2.left * Time.deltaTime * speed);
        }
        else if ( rb.velocity.x > maxSpeed )
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }


        if ( Input.GetAxisRaw("J1Move") == 1 && grounded && jumpAvailable)
        {
            rb.AddForce(Vector2.up*jumpHeight);
            grounded = false;
            jumpAvailable = false; 
        }
        else if ( Input.GetAxisRaw("J1Move") == 0 && !jumpAvailable)
        {
            jumpAvailable = true;
        }

        if ( Input.GetAxisRaw("J1Circle") == 1 && circleAvailable)
        {
            anim.SetTrigger("Circle");
            triangle.SetActive(false);
            square.SetActive(false);
            circle.SetActive(true);

            circleAvailable = !circle.activeSelf;
            triangleAvailable = !triangle.activeSelf;
            squareAvailable = !square.activeSelf;
        }
        if ( Input.GetAxisRaw("J1Triangle") == 1 && triangleAvailable)
        {
            anim.SetTrigger("Triangle");
            triangle.SetActive(true);
            square.SetActive(false);
            circle.SetActive(false);

            circleAvailable = !circle.activeSelf;
            triangleAvailable = !triangle.activeSelf;
            squareAvailable = !square.activeSelf;
        }
        if ( Input.GetAxisRaw("J1Square") == 1 && squareAvailable)
        {
            anim.SetTrigger("Square");

            triangle.SetActive(false);
            square.SetActive(true);
            circle.SetActive(false);

            circleAvailable = !circle.activeSelf;
            triangleAvailable = !triangle.activeSelf;
            squareAvailable = !square.activeSelf;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Ground" )
        {
            grounded = true;
        }
    }
    
}
