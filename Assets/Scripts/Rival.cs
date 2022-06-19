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

    

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaY = ball.transform.position.y - transform.position.y;

        transform.position += Vector3.up * (deltaY * responseRate);

    }

    public void CheckHardness()
    {
        var level = hardness.text;

        switch (level)
        {
            case "Easy":
                responseRate = 0.010f;
                break;
            case "Medium":
                responseRate = 0.020f;
                break;
            case "Hard":
                responseRate = 0.030f;
                break;
        }
    }
    
    
}
