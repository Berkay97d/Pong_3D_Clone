using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI P1ScoreText;
    [SerializeField] private TextMeshProUGUI P2ScoreText;
    [SerializeField] private GameObject[] players;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject p1Win;
    [SerializeField] private GameObject p2Win;
    [SerializeField] private GameObject ball;
    [SerializeField] private BallController ballController;
    [SerializeField] private BallCollision ballCollision;


    void Update()
    {
        CheckGameOver();
        
    }

    public void RestartGame()
    {
        P2ScoreText.text = "0";
        P1ScoreText.text = "0";
        ballCollision.p1Score = 0;
        ballCollision.p2Score = 0;
        endScreen.SetActive(false);
        ballController.StartGame();
        
    }
    
    private void CheckGameOver()
    {
        
        if (Convert.ToInt32(P1ScoreText.text) == 7)
        {
            endScreen.SetActive(true);
            p1Win.SetActive(true);
            p2Win.SetActive(false);
            ball.SetActive(false);
            foreach (var player in players)
            {
                player.SetActive(false);
            }
        }

        if (Convert.ToInt32(P2ScoreText.text) == 7)
        {
            endScreen.SetActive(true);
            p1Win.SetActive(false);
            p2Win.SetActive(true);
            ball.SetActive(false);
            foreach (var player in players)
            {
                player.SetActive(false);
            }
        }
    }
}
