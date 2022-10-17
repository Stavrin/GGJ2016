using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class littleMenController : MonoBehaviour
{
    public Rigidbody2D rb;
    public EdgeCollider2D col;

    public Sprite manBlueSprites;
    public Sprite manRedSprites;

    bool isColWithSlope;
    bool atEndPoint;

    public string direction;
    public string forplayer;
    public string state;

    private int collisionCount;

    public int RedScore;
    public int BlueScore;

    public Text RedTxtScore;
    public Text BlueTxtScore;

    scoreController score;


    Vector2 manVelocity; //TODO: Rename 
    private Vector2 _manVelocityConfiguration = new Vector2(2, 0);


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //direction = "";
        isColWithSlope = false;
        atEndPoint = false;

        if(forplayer == "RED")
            gameObject.GetComponent<SpriteRenderer>().sprite = manRedSprites;
        if(forplayer == "BLUE")
            gameObject.GetComponent<SpriteRenderer>().sprite = manBlueSprites;

        state = "running";

        RedScore = 0;
        BlueScore = 0;
}

    // Update is called once per frame
    void Update()
    {

        RedTxtScore.text = scoreController.GetInstance().RedPlayerScore.ToString(); //display scores in game.

        BlueTxtScore.text = scoreController.GetInstance().BluePlayerScore.ToString();


    }


    void FixedUpdate()
    {
        if (direction == "L" && state == "running")
        {
            
            manVelocity = _manVelocityConfiguration*-1;
            //If man has reached the top of the tower
            if (transform.position.x < 0.1f)
            {
                atEndPoint = true;
            }
            if (atEndPoint == true)
            {
               // state = "raise";
            }
        }

        if (direction == "R" && state == "running")
        {
            manVelocity = _manVelocityConfiguration;
            //If man has reached the top of the tower
            if (transform.position.x > -0.1f)
            {
                atEndPoint = true;
            }
            if (atEndPoint == true)
            {
                //state = "raise";
            }
        }

        /*if (direction == "L")
            manVelocity = new Vector2(-1, 0);
        if (direction == "R")
            manVelocity = new Vector2(1, 0);*/

        if (isColWithSlope == false)
        {
            rb.velocity = manVelocity.normalized;
            //rb.AddForce(new Vector2(-10, 0));
        }


        if(state == "raise")
        {
            //raiseToHeaven();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        collisionCount++;


        if (col.gameObject.name == "slopeEnd")
        {
            isColWithSlope = true;
            
        }

        if (col.gameObject.name == "slope")
        {

            if (direction == "L")
                manVelocity = new Vector2(-1, 1);

            if (direction == "R")
                manVelocity = new Vector2(1, 1);

            isColWithSlope = false;
            rb.velocity = manVelocity.normalized;

            //state = "raise";
            raiseToHeaven();
        }


    }

    void OnCollisionExit2D(Collision2D other)
    {
        collisionCount --;
        if(collisionCount == 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
    }

    void raiseToHeaven()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        transform.position += new Vector3(0, 10, 0) * Time.deltaTime;
        manVelocity = new Vector2(0, 1);
        state = "raise";
        //if (transform.position.y > 5.0f)
        //{
        if (forplayer == "RED")
        {
   


            scoreController.GetInstance().addRedPlayerScore();
            //Destroy(gameObject);
        }
        if (forplayer == "BLUE")
        {
            

            scoreController.GetInstance().addBluePlayerScore();
            //Destroy(gameObject);
        }
        //}
    }
}