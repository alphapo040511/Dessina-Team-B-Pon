using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagr : MonoBehaviour
{
    public bool Roulette = true;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject wall;
    public GameObject rightP;
    public GameObject leftP;
    public int gameMode;
    public float checkTime;
    public bool input = false;
    public TMP_Text gamemodetext;
    public Image gamemodeImage;
    public Image gamemodeImage2;
    public Image gamemodeImage3;
    public bool gameStart = false;
    public GameObject rightWin;
    public GameObject leftWin;
    private int stopNumber;
    public float stopTime;

    public Sprite speedUp_Image;
    public Sprite wall_Image;
    public Sprite invisibleBall_Image;
    public Sprite randomSpeed_Image;

    private bool first = true;

    bool stop = false;
    public bool reStart = true;

    private Image thisImage;

    // Start is called before the first frame update
    void Start()
    {
        thisImage = gamemodeImage2.GetComponent<Image>();
        reStart = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (reStart)
        {
            gamemodetext.text = "";
            reStart = false;
            checkTime = 0;
            stopTime = 0;
            stopNumber = Random.Range(1, 5);
            Roulette = true;
            if (first == true)
            {
                
                first = false;
                StartCoroutine(RouletteTimer());
            }
            else if(first == false)
            {
                rightP.gameObject.SetActive(false);
                leftP.gameObject.SetActive(false);
                wall.gameObject.SetActive(false);
           
                gamemodetext.DOFade(1f, 1f);
                gamemodeImage2.DOFade(1f, 1f);
                gamemodeImage3.DOFade(1f, 1f);
                gamemodeImage.DOFade(1f, 1f).OnComplete(() => StartCoroutine(RouletteTimer()));
            }
 
        }
       if(rightPoint.GetComponent<PointManager>().point == 3)
        {
            gameStart = false;
            leftWin.SetActive(true);
            Invoke("GameEnd", 3);
        }

        if (leftPoint.GetComponent<PointManager>().point == 3)
        {
            gameStart = false;
            rightWin.SetActive(true);
            Invoke("GameEnd", 3);
        }

        if (stopTime >= 2.5f && gameMode == stopNumber && Roulette == true)
        {
            Roulette = false;
            if (gameMode == 1)
            {
                gamemodetext.text = "[소방차는멈추지않아BRO]\r\n공이 부딪힐때마다 속도가 빨라집니다!";
                thisImage.sprite = speedUp_Image;
            }
            if (gameMode == 2)
            {
                gamemodetext.text = "[넌 못찌나간다아아아아ㅏ]\r\n스테이지 중앙에 움직이는 벽이생깁니다!";
                thisImage.sprite = wall_Image;
            }
            if (gameMode == 3)
            {
                gamemodetext.text = "[어뭐야 이거왜 투명해져]\r\n공이 중간중간 투명해집니다!";
                thisImage.sprite = invisibleBall_Image;
            }
            if (gameMode == 4)
            {
                gamemodetext.text = "[왜 빨라졌다 이러냐이거]\r\n공이 부딪힐때마다 속도가 바뀝니다!";
                thisImage.sprite = randomSpeed_Image;
            }


                Invoke("GameStart", 2f);
        }

        if(checkTime >= 0.1f)
        {
            thisImage.sprite = speedUp_Image;
            gamemodeImage2.gameObject.SetActive(true);
            gameMode = 1;
            stopTime += Time.deltaTime;
        }
        if (checkTime >= 0.2f)
        {
            thisImage.sprite = wall_Image;
            gameMode = 2;
            stopTime += Time.deltaTime;
        }
        if (checkTime >= 0.3f)
        {
            thisImage.sprite = invisibleBall_Image;
            gameMode = 3;
            stopTime += Time.deltaTime;
        }
        if (checkTime >= 0.4f)
        {
            thisImage.sprite = randomSpeed_Image;
            gameMode = 4;
            stopTime += Time.deltaTime;
            checkTime = 0;
        }
    }

    private IEnumerator RouletteTimer()
    {
        checkTime = 0;
        while (Roulette == true)
        {
            checkTime += Time.deltaTime;
            yield return null;
        }
    }

    private void GameStart()
    {
        stop = true;
        

        gamemodetext.DOFade(0f, 2f);
        gamemodeImage2.DOFade(0f, 2f);
        gamemodeImage3.DOFade(0f, 2f);
        gamemodeImage.DOFade(0f, 2f).OnComplete(() => gameStart = true);
    }

    void GameEnd()
    {
        SceneManager.LoadScene("MainScene");
    }
}
