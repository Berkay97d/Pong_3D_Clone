using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody ballRb;
    
    private const float Range = 3.85f;
    
    
    
    void Update()
    {
        IsMovable();
        MovePlayer();
    }

    
    private void MovePlayer()
    {
        if (!IsMovable()) return;
        
        var playerPosition = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            if (playerPosition.y <= Range)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.up);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (playerPosition.y >= -Range)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.down);
            }
        }

    }

    
    private bool IsMovable()
    {
        return ballRb.velocity != Vector3.zero;
    }
    
}
