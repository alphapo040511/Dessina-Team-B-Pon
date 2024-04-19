using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BallMoving : MonoBehaviour
{
    public float ballSpeed = 50f;
    public int RLDirection;
    public int UDDirection = -1;
    public bool StartMove = false;
    public Renderer ball;
    public float duration = 2f;
    public GameObject Manager;
    private int mode;



    // Start is called before the first frame update
    void Start()
    {
        int RL = Random.Range(0, 2);
        if (RL == 0) RLDirection = -1;
        if (RL == 1) RLDirection = 1;

        Manager = GameObject.Find("GameManager");

        mode = Manager.GetComponent<GameManagr>().gameMode;

        if(mode == 3)
        {
            Sequence mysquence = DOTween.Sequence();

            mysquence.Append(ball.material.DOFade(0f, 0.5f));

            mysquence.AppendInterval(0.5f);

            mysquence.Append(ball.material.DOFade(1f, 0.5f));

            mysquence.AppendInterval(0.5f);

            mysquence.SetLoops(-1);
        }

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
            RLDirection *= -1;

            if(mode == 1)
            ballSpeed += 3f;            //Player에 닿을 때마다 공의 속도가 3씩 증가함

            if(mode == 4) 
            {
                ballSpeed = Random.Range(10f,30f);
            }
        }

        if (collision.transform.tag == "Wall")
        {
            UDDirection *= -1;
        }
    }

}
