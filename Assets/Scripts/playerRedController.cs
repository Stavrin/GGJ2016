using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityStandardAssets.CrossPlatformInput;

public class playerRedController : MonoBehaviour
{

    public int speed;
    public GameObject redTopArrow;
    public GameObject redSideArrow;
    public GameObject ball;
	public AudioClip Canon1;
	public AudioClip Canon2;
    // Use this for initialization
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            if (Input.GetKey(KeyCode.J))
            {
                redTopArrow.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.L))
            {
                redTopArrow.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.I))
            {
                redSideArrow.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
                if (redSideArrow.transform.position.y > 1.8f)
                {
                    redSideArrow.transform.position = new Vector2(redSideArrow.transform.position.x, 1.79f);
                }
            }
            if (Input.GetKey(KeyCode.K))
            {
                redSideArrow.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
                if (redSideArrow.transform.position.y < -1.05f)
                {
                    redSideArrow.transform.position = new Vector2(redSideArrow.transform.position.x, -1.04f);
                }
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (!BallRepository.IsRedPlayerBallsMax)
                {
                    GameObject go = (GameObject)Instantiate(ball, transform.position, new Quaternion());
                    createBall ScriptReference = go.GetComponent<createBall>();
                    ScriptReference.Initialize("LEFT");
                    BallRepository.ConsumeRedBall();
					//fire sound
					Completed.SoundManager.instance.RandomizeSfx (Canon1,Canon2);
                }
            }
        }
    }
}
