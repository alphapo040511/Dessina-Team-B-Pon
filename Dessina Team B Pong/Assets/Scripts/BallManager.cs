using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject rightP;
    public GameObject leftP;
    public GameObject ball;
    public Text countUI;
    private bool isStart = false;
    public GameObject Wall;

    //WallMoving 에서 사용할 수 있도록 public으로 변수 선언
    public float checkTime = 0;         // 카운트다운을 체크하는 시간 변수 선언

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (gameManager.GetComponent<GameManagr>().gameStart == true && isStart == false)
        {
            isStart = true;
            rightP.SetActive(true);
            leftP.SetActive(true);
            if (gameManager.GetComponent<GameManagr>().gameMode == 2)
            {
                Wall.SetActive(true);
            }
            Spawn();
            //StartCoroutine(StartBall());
        }

    }

    public void Spawn()
    {
        if (gameManager.GetComponent<GameManagr>().gameStart == true)
        {
            // 공 프리팹을 리소스에서 로드합니다.
            ball = Resources.Load<GameObject>("Prefabs/Ball");
            // 로드한 프리팹을 복제하여 실제 게임 오브젝트를 생성합니다.
            ball = Instantiate(ball);
            // 생성된 공의 초기 위치를 설정합니다.
            ball.transform.position = new Vector2(0, 10);
            // 카운트다운 코루틴을 시작합니다.
            StartCoroutine(StartBall());
        }
    }

    private IEnumerator StartBall()
    {
        // 카운트다운 UI를 활성화합니다.
        countUI.enabled = true;
        // 초기 카운트 값 설정
        int count = 3;
        countUI.text = count.ToString();
        checkTime = 0;

        while (checkTime <= 3)  // 3초 동안 반복 (checkTime <= 3인 동안 반복실행)
        {
            // 체크 시간에 따라 카운트 값 변경
            if (checkTime >= 2)
            {
                count = 1;
                countUI.text = count.ToString();
            }
            else if (checkTime >= 1)
            {
                count = 2;
                countUI.text = count.ToString();
            }

            // 시간을 업데이트합니다.
            checkTime += Time.deltaTime;
            yield return null;  // 한 프레임을 기다립니다. (yield return null;이 실행되면 while문 안쪽의 실행문을 다음 프레임에 다시 반복한다는 의미)
        }
        // 카운트다운이 종료되면 UI를 비활성화하고 공의 이동을 시작합니다.
        countUI.enabled = false;
        ball.GetComponent<BallMoving>().StartMove = true; // BallMoving 스크립트의 StartMove를 활성화합니다.
        yield break; // 코루틴을 종료합니다.
    }

}

