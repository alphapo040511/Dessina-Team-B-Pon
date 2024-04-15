using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    public float ballSpeed = 50f;
    public int RLDirection = 1;
    public int UDDirection = -1;
    public bool StartMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartMove == true)
        {
            transform.Translate(new Vector2(ballSpeed * RLDirection * Time.deltaTime, ballSpeed * UDDirection * Time.deltaTime));
        }
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            RLDirection *= -1;
         
            ballSpeed += 3f;            //Player에 닿을 때마다 공의 속도가 3씩 증가함
        }

        if (collision.transform.tag == "Wall")
        {
            UDDirection *= -1;
        }
    }

}
