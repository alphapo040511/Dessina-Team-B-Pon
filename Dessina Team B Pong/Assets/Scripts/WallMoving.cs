using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float topY = 10f;
    public float bottomY = -10f;

    public GameObject gameManager;
    public GameObject ballManager; //BallManager 게임 오브젝트를 선언 (인스펙터창에서 직접 넣어주는 방식)

    public float timer; //BallManager에서 불러온 checkTime 값을 저장할 변수 선언

    private int moveDirection = 1;


    //public BallManager ballManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = ballManager.GetComponent<BallManager>().checkTime; //변수 ballManager에 저장해놓은 BallManager오브젝트의 BallMangaer 스크립트에서 checkTime의 값을 받아온다.
        //받아온 변수를 저장할 공간 = 데이터를 받아올 오브젝트.GetComponent<데이터를 받아올 스크립트 이름>().스크립트속 변수 이름;




        if (timer >= 3) //카운트 다운 3초가 끝나면 벽 움직임 시작 
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
