using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private BallController ballController;
    [SerializeField] private Transform[] players;
    [SerializeField] private Rigidbody ballRb;
    
    [SerializeField] private TextMeshProUGUI P1ScoreText;
    [SerializeField] private TextMeshProUGUI P2ScoreText;
    [HideInInspector] public int p1Score = 0, p2Score = 0;

    
    
    private void Start()
    {
        ballController = FindObjectOfType<BallController>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SensorP1"))
        {
            p2Score++;
            P2ScoreText.text = p2Score.ToString();
        }
        else if (other.CompareTag("SensorP2"))
        {
            p1Score++;
            P1ScoreText.text = p1Score.ToString();
        }
        
        ResetPlayersPosition();
        RelocateBall();
        StartCoroutine(ballController.ThrowBall());
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerPosition = collision.transform.position.y;
            var ballPosition = transform.position.y;
            var range = (ballPosition - playerPosition) * 15 ;
            var y = (range - ballRb.velocity.y) ;

            ballRb.AddForce(0,y,0,ForceMode.Impulse);
            
        }
    }

    

    private void ResetPlayersPosition()
    {
        foreach (var player in players)
        {
            player.position = new Vector3(player.position.x, 0);
        }
    }

    
    private void RelocateBall()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        ballRb.velocity = Vector3.zero;
    }
}
