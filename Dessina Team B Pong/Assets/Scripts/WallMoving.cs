using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float topY = 10f;
    public float bottomY = -10f;

    public float checkTimer = 3.0f;

    private int moveDirection = 1;


    //public BallManager ballManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkTimer -= Time.deltaTime;

        if (checkTimer <= 0)
        {

            transform.Translate(Vector2.up * moveSpeed * moveDirection * Time.deltaTime);

            if (transform.position.y >= topY)
            {
                moveDirection = -1;
            }

            else if (transform.position.y <= bottomY)
            {
                moveDirection = 1;
            }


        }


    }
}
