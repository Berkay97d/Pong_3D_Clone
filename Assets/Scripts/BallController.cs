using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private Rival rival;
    
    [SerializeField] private GameObject[] players;
    
    private int verticalSpeed = 1;
    private int horizontalSpeed = 10;


    private void Start()
    {
        startScreen.SetActive(true);
        gameObject.SetActive(false);
        
        foreach (var player in players)
        {
            player.SetActive(false);
        }
    }

    
    public void StartGame()
    {
        startScreen.SetActive(false);
        rival.CheckHardness();
        ballRb.gameObject.SetActive(true);
        foreach (var player in players)
        {
            player.SetActive(true);
        }
        gameObject.SetActive(true);
        StartCoroutine(ThrowBall());
    }
    
    

    
    public IEnumerator ThrowBall()
    {
        yield return new WaitForSeconds(2f);
        ballRb.AddForce(RandomForce(),ForceMode.Impulse);
    }

    
    private Vector3 RandomForce()
    {
        var temp = Random.Range(0, 2);

        if (temp == 1)
        {
            var xForce = horizontalSpeed;
            var yForce = verticalSpeed;
            return new Vector3(horizontalSpeed, verticalSpeed, 0);
        }

        return new Vector3(-horizontalSpeed, verticalSpeed, 0);

    }

    
    

    
}
