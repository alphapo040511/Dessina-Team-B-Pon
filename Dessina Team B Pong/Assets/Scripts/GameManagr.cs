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
    public int gameMode;
    public float checkTime;
    public bool input = false;
    public Text gamemodetext;
    public Image gamemodeImage;
    public Image gamemodeImage2;
    public bool gameStart = false;
    public GameObject rightWin;
    public GameObject leftWin;
    private int stopNumber;
    public int stopMode;

    public Sprite speedUp_Image;
    public Sprite wall_Image;
    public Sprite invisibleBall_Image;
    public Sprite randomSpeed_Image;

    private bool stopRoutine = false;
    bool stop = false;

    private Image thisImage;

    // Start is called before the first frame update
    void Start()
    {
        thisImage = gamemodeImage2.GetComponent<Image>();
        StartCoroutine(RouletteTimer());
        stopNumber = Random.Range(1000, 1200);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (stopMode >= stopNumber)
        {
            Roulette = false;


            if (stopRoutine == false)
            {
                Debug.Log("start");
                stopRoutine = true;
                //StartCoroutine(UIBlink());
            }
            Invoke("GameStart", 1.5f);
        }

        if(checkTime >= 0.1f)
        {
            thisImage.sprite = speedUp_Image;
            gamemodeImage2.gameObject.SetActive(true);
            gameMode = 1;
            stopMode++;
            gamemodetext.text = "SpeedUp";
        }
        if (checkTime >= 0.2f)
        {
            thisImage.sprite = wall_Image;
            gameMode = 2;
            stopMode++;
            gamemodetext.text = "Wall";
        }
        if (checkTime >= 0.3f)
        {
            thisImage.sprite = invisibleBall_Image;
            gameMode = 3;
            stopMode++;
            gamemodetext.text = "InvisibleBall";
        }
        if (checkTime >= 0.4f)
        {
            thisImage.sprite = randomSpeed_Image;
            gameMode = 4;
            stopMode++;
            gamemodetext.text = "RandomSpeed";
            checkTime = 0;
        }
    }

/*    private IEnumerator UIBlink()
    {


        float checkTime2 = 0;
        float time = 0.3f;

        while (checkTime2 <= time)
        {
            checkTime2 += Time.deltaTime;
            yield return null;
        }
        gamemodetext.gameObject.SetActive(false);
        gamemodeImage2.gameObject.SetActive(false);

        checkTime2 = 0;

        while (checkTime2 <= time)
        {
            checkTime2 += Time.deltaTime;
            yield return null;
        }
        gamemodetext.gameObject.SetActive(true);
        gamemodeImage2.gameObject.SetActive(true);

        Debug.Log("while");

        if (stop == false)
        StartCoroutine(UIBlink());
    }*/

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
        gamemodeImage.DOFade(0f, 2f).OnComplete(() => gameStart = true);
    }

    void GameEnd()
    {
        SceneManager.LoadScene("MainScene");
    }
}
