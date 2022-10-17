using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    public int RedPlayerScore;
    public int BluePlayerScore;

    public Text RedTxtScore;
    public Text BlueTxtScore;

    // Use this for initialization
    void Start()
    {
        RedPlayerScore = 0;
        BluePlayerScore = 0;



        LogScores();
    }

    // Update is called once per frame
    void Update()
    {
       // RedPlayerScore.ToString(); //display scores in game.
       // BluePlayerScore.ToString();

    }

    public void LogScores()
    {

        //Debug.Log("Red: " + RedPlayerScore);
        //Debug.Log("Blue: " + BluePlayerScore);

        

    }

    public void addRedPlayerScore()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            RedPlayerScore++;
            LogScores();
        }
    }
    public void addBluePlayerScore()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            BluePlayerScore++;
            LogScores();
        }
    }

    public static scoreController instance;
    public static scoreController GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
