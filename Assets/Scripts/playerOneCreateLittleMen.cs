﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class playerOneCreateLittleMen : MonoBehaviour
{
    public GameObject men;
    public Sprite manRedSprites;
    public RuntimeAnimatorController manRedAnimation;

    float lastFired;
    // Use this for initialization
    void Start()
    {
        lastFired = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            if ((Time.time > lastFired + (1f/Configuration.PeoplePerSecond)))
            {
                GameObject go = (GameObject) Instantiate(men, new Vector2(10f, -1.4f), new Quaternion());
                littleMenController ScriptReference = go.GetComponent<littleMenController>();

                ScriptReference.direction = "L";
                ScriptReference.forplayer = "RED";
                ScriptReference.GetComponent<Animator>().runtimeAnimatorController = manRedAnimation;
                lastFired = Time.time;
            }
        }
    }
}
