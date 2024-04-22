using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
    public Text gamemodetext;
    public Image gamemodeImage;
    public Image gamemodeImage2;
    public Image gamemodeImage3;
    public bool gameStart = false;
    public GameObject rightWin;
    public GameObject leftWin;
    private int stopNumber;
    public int stopMode;

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
            stopMode = 0;
            stopNumber = Random.Range(1000, 1200);
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

        if (stopMode >= stopNumber && Roulette == true)
        {
            Roulette = false;
            if (gameMode == 1)
                gamemodetext.text = "[?????????BRO]\r\n?? ?????? ??? ?????!";
            if (gameMode == 2)
                gamemodetext.text = "[? ??????????]\r\n???? ??? ???? ??????!";
            if (gameMode == 3)
                gamemodetext.text = "[??? ??? ????]\r\n?? ???? ??????!";
            if (gameMode == 4)
                gamemodetext.text = "[? ???? ?????]\r\n?? ?????? ??? ????!";


            Invoke("GameStart", 2f);
        }

        if(checkTime >= 0.1f)
        {
            thisImage.sprite = speedUp_Image;
            gamemodeImage2.gameObject.SetActive(true);
            gameMode = 1;
            stopMode++;
           
        }
        if (checkTime >= 0.2f)
        {
            thisImage.sprite = wall_Image;
            gameMode = 2;
            stopMode++;
            
        }
        if (checkTime >= 0.3f)
        {
            thisImage.sprite = invisibleBall_Image;
            gameMode = 3;
            stopMode++;
            
        }
        if (checkTime >= 0.4f)
        {
            thisImage.sprite = randomSpeed_Image;
            gameMode = 4;
            stopMode++;
            
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
