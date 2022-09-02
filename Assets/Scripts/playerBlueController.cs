using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityStandardAssets.CrossPlatformInput;

public class playerBlueController : MonoBehaviour {
    public int speed;

    public GameObject blueTopArrow;
    public GameObject blueSideArrow;
    public GameObject ball;
	public AudioClip Canon1;
	public AudioClip Canon2;

	private bool m_Horizontal;
	private bool m_Vertical;
    private float m_HorizontalSpeed;
    private float m_VerticalSpeed;

	public static Vector3 poistionTop;

    // Use this for initialization
    void Start () {
        speed = 5;
	}
	
	// Update is called once per frame
	void Update () {

        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");

        if (!TimeControllerScript.IsGameOver)
	    {

            if (!m_Horizontal)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_HorizontalSpeed = CrossPlatformInputManager.GetAxis("Horizontal");

            }

            if (!m_Vertical)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_VerticalSpeed = CrossPlatformInputManager.GetAxis("Vertical");
            }


	           blueTopArrow.transform.position += new Vector3(h-speed, 0, 0)*Time.deltaTime;
	        
	      
	        
	           blueTopArrow.transform.position += new Vector3(h+speed, 0, 0)*Time.deltaTime;
	        

	            blueSideArrow.transform.position += new Vector3(0, v+speed, 0)*Time.deltaTime;
                if (blueSideArrow.transform.position.y > 1.8f)
                {
                    blueSideArrow.transform.position = new Vector2(blueSideArrow.transform.position.x, 1.79f);
                }

                blueSideArrow.transform.position += new Vector3(0, v-speed, 0)*Time.deltaTime;
                if (blueSideArrow.transform.position.y < -1.05f)
                {
                    blueSideArrow.transform.position = new Vector2(blueSideArrow.transform.position.x, -1.04f);
                }

	        if (CrossPlatformInputManager.GetButtonDown("P1 B"))
	        {
	            if (!BallRepository.IsBluePlayerBallsMax)
	            {
                    GameObject go = (GameObject)Instantiate(ball, transform.position, new Quaternion());
                    createBall ScriptReference = go.GetComponent<createBall>();
                    ScriptReference.Initialize("RIGHT");
                    BallRepository.ConsumeBlueBall();
                    Completed.SoundManager.instance.RandomizeSfx(Canon1);
	            }
	            
	        }
	    }
    }

    private void FixedUpdate()
    {
        // Read the inputs.
       // float v = CrossPlatformInputManager.GetAxis("Vertical");
       // float h = CrossPlatformInputManager.GetAxis("Horizontal");
    }
}
