using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallMoving : MonoBehaviour
{
    public float ballSpeed = 50f;
    public int RLDirection = 1;
    public int UDDirection = -1;
    public bool StartMove = false;
    public Renderer ball;
    public float duration = 2f;


    // Start is called before the first frame update
    void Start()
    {
        //ball.material.DOFade(0f, duration).SetLoops(-1, LoopType.Yoyo);
        Sequence mysquence = DOTween.Sequence();

        mysquence.Append(ball.material.DOFade(0f, 0.5f));
      
        mysquence.AppendInterval(1.0f);

        mysquence.Append(ball.material.DOFade(0.35f, 0.5f));
        mysquence.SetLoops(-1, LoopType.Yoyo);

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
        if (collision.transform.tag == "Player")
        {
            RLDirection = -1;

            ballSpeed += 3f;            //Player에 닿을 때마다 공의 속도가 3씩 증가함
        }

        if (collision.transform.tag == "Wall")
        {
            UDDirection = -1;
        }
    }

}
