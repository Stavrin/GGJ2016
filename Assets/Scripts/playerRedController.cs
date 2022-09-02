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

    private bool m_Horizontal;
    private bool m_Vertical;
    private float m_HorizontalSpeed;
    private float m_VerticalSpeed;


    // Use this for initialization
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        float v = CrossPlatformInputManager.GetAxis("P2 Vertical");
        float h = CrossPlatformInputManager.GetAxis("P2 Horizontal");

        if (!TimeControllerScript.IsGameOver)
        {

            if (!m_Horizontal)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_HorizontalSpeed = CrossPlatformInputManager.GetAxis("P2 Horizontal");

            }

            if (!m_Vertical)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_VerticalSpeed = CrossPlatformInputManager.GetAxis("P2 Vertical");
            }

                redTopArrow.transform.position += new Vector3(h-speed, 0, 0) * Time.deltaTime;


                redTopArrow.transform.position += new Vector3(h+speed, 0, 0) * Time.deltaTime;


                redSideArrow.transform.position += new Vector3(0, v+speed, 0) * Time.deltaTime;
                if (redSideArrow.transform.position.y > 1.8f)
                {
                    redSideArrow.transform.position = new Vector2(redSideArrow.transform.position.x, 1.79f);
                }

                redSideArrow.transform.position += new Vector3(0, v-speed, 0) * Time.deltaTime;
                if (redSideArrow.transform.position.y < -1.05f)
                {
                    redSideArrow.transform.position = new Vector2(redSideArrow.transform.position.x, -1.04f);
                }

            if (CrossPlatformInputManager.GetButtonDown("P2 B"))
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
