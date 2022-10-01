using UnityEngine;
using System.Collections;

public class scoreController : MonoBehaviour
{
    public static int RedPlayerScore { get; private set; }
    public static int BluePlayerScore { get; private set; }

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
    }

    private static void LogScores()
    {
        Debug.Log("Red: " + RedPlayerScore);
        Debug.Log("Blue: " + BluePlayerScore);
    }

    public static void addRedPlayerScore()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            RedPlayerScore++;
            LogScores();
        }
    }
    public static void addBluePlayerScore()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            BluePlayerScore++;
            LogScores();
        }
    }
}
