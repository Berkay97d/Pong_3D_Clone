using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rival : MonoBehaviour
{
    [SerializeField,Range(0f,1f)] private float responseRate;
    [SerializeField] private GameObject ball;
    [SerializeField] private TextMeshProUGUI hardness;
    
    private const float Range = 3.85f;
    

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaY = ball.transform.position.y - transform.position.y;

        if (!(transform.position.y > Range) && !(transform.position.y < -Range))
        {
            transform.position += Vector3.up * (deltaY * responseRate);    
        }

        if ((transform.position.y > Range))
        {
            transform.position = new Vector3(transform.position.x, Range);
        }
        
        if ((transform.position.y < -Range))
        {
            transform.position = new Vector3(transform.position.x, -Range);
        }
    }

    public void CheckHardness()
    {
        var level = hardness.text;

        switch (level)
        {
            case "Easy":
                responseRate = 0.030f;
                break;
            case "Medium":
                responseRate = 0.045f;
                break;
            case "Hard":
                responseRate = 0.060f;
                break;
        }
    }
    
    
}
