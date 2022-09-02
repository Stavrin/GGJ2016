using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityStandardAssets.CrossPlatformInput;

public class blockController : MonoBehaviour
{
    public GameObject block;
    public GameObject bluePlayerTop;
    public GameObject redPlayerTop;
    public int redPlayerBlockCount;
    public int bluePlayerBlockCount;
    public int blockCount;
    private float _lastBlockRefreshTime;
	public AudioClip Create1;
	public AudioClip Create2;
	public AudioClip Create3;
	public AudioClip Thud1;
	public AudioClip Thud2;
	public AudioClip Squash1;
	public AudioClip Squash2;
	public AudioClip Scream1;
	public AudioClip Scream2;

    public int getRedPlayerBlockCount
    {
        get
        {
            return redPlayerBlockCount;
        }
    }
    public int getBluePlayerBlockCount
    {
        get
        {
            return bluePlayerBlockCount;
        }
    }
    public int getBlockCount
    {
        get
        {
            return blockCount;
        }
    }
    // Use this for initialization
    void Start()
    {
        blockCount = Configuration.InitialBlockCount;
        redPlayerBlockCount = 0;
        bluePlayerBlockCount = 0;
        _lastBlockRefreshTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshBlocks();

        if (CrossPlatformInputManager.GetButtonDown("P1 A"))
        {
            if (bluePlayerBlockCount < blockCount)
            {
                if (!(bluePlayerTop.transform.position.x > -0.70f && bluePlayerTop.transform.position.x < 0.70f))
                {
                    Debug.Log(string.Format("Blue player block count used {0}", ++bluePlayerBlockCount));
                    GameObject go = Instantiate(block, new Vector2(bluePlayerTop.GetComponent<Renderer>().transform.position.x, bluePlayerTop.GetComponent<Renderer>().transform.position.y - 0.5f), new Quaternion()) as GameObject;
                    PlayBlockSound();
                }
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("P2 A"))
        {
            if (redPlayerBlockCount < blockCount)
            {
                if (!(redPlayerTop.transform.position.x > -0.70f && redPlayerTop.transform.position.x < 0.70f))
                {
                    Debug.Log(string.Format("Red player block count used {0}", ++redPlayerBlockCount));
                    GameObject go = Instantiate(block, new Vector2(redPlayerTop.GetComponent<Renderer>().transform.position.x, bluePlayerTop.GetComponent<Renderer>().transform.position.y - 0.5f), new Quaternion()) as GameObject;
                    PlayBlockSound();
                }
            }
        }
    }

    private void RefreshBlocks()
    {
        if (Time.time - _lastBlockRefreshTime >= Configuration.BlockRegenerationPerSecond)
        {
            Debug.Log(string.Format("Block count incrementing from {0} to {1}", blockCount, ++blockCount));
            _lastBlockRefreshTime = Time.time;
        }
    }

	private void PlayBlockSound()
	{
		Completed.SoundManager.instance.RandomizeSfx (Create1, Create2, Create3);

	}
}
