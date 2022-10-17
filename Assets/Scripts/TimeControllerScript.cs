using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeControllerScript : MonoBehaviour
{

    private static readonly int _gameLengthSeconds = Configuration.GameLengthInSeconds;

    public static float timeRemaining = _gameLengthSeconds;

    public static bool IsGameOver { get { return timeRemaining <= 0.0f; } }

    private Text _textElement;
    public static float _startGameTime;

    public Text Winner;


    void Start()
    {
        _startGameTime = Time.time;
        _textElement = GetComponent<Text>();
    }

    void Update()
    {
        timeRemaining = _gameLengthSeconds - (Time.time - _startGameTime);

        if (!IsGameOver)
        {
            _textElement.text = Math.Max(timeRemaining, 0f).ToString("00");
        }
        else
        {
            string winText = "";
            if (scoreController.GetInstance().BluePlayerScore > scoreController.GetInstance().RedPlayerScore)
            {
                winText = "BLUE WINS!";
            }
            if (scoreController.GetInstance().RedPlayerScore > scoreController.GetInstance().BluePlayerScore)
            {
                winText = "RED WINS!";
            }
            if (scoreController.GetInstance().RedPlayerScore == scoreController.GetInstance().BluePlayerScore)
            {
                winText = "DRAW!";
            }
            Winner.text = winText;


            // // doesn't do anything
            foreach (var go in GameObject.FindGameObjectsWithTag("LittleMen"))
            {
                var component = go.GetComponent<Rigidbody2D>();
                component.isKinematic = true;
            }
        }
    }
}
