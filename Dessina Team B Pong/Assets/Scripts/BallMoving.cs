using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BallMoving : MonoBehaviour
{
    public float ballSpeed = 50f;
    public float RLDirection;
    public float UDDirection = -1;
    public bool StartMove = false;
    public Renderer ball;
    public float duration = 2f;
    public GameObject Manager;
    private int mode;

    private void Awake()
    {
        Time.fixedDeltaTime = 0.005f;
    }

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
            float temp = Mathf.Sign(RLDirection);
            RLDirection = Random.Range(0.8f, 1.2f);
            RLDirection *= -1 * temp;

            if(mode == 1)
            ballSpeed += 3f;            //Player?? ???? ?????? ???? ?????? 3?? ??????

            if(mode == 4) 
            {
                ballSpeed = Random.Range(10f,30f);
            }
        }

        if (collision.transform.tag == "Wall")
        {
            float temp = Mathf.Sign(UDDirection);
            UDDirection = Random.Range(0.8f, 1.2f);
            UDDirection *= -1 * temp;
        }
    }

}
