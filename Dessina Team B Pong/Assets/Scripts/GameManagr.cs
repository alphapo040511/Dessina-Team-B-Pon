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


    // Start is called before the first frame update
    void Start()
    {
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
            Invoke("GameStart", 1.5f);
        }

        if(checkTime >= 0.1f)
        {
            gameMode = 1;
            stopMode++;
            gamemodetext.text = "SpeedUp";
        }
        if (checkTime >= 0.2f)
        {
            gameMode = 2;
            stopMode++;
            gamemodetext.text = "Wall";
        }
        if (checkTime >= 0.3f)
        {
            gameMode = 3;
            stopMode++;
            gamemodetext.text = "InvisibleBall";
        }
        if (checkTime >= 0.4f)
        {
            gameMode = 4;
            stopMode++;
            gamemodetext.text = "RandomSpeed";
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
        gamemodetext.DOFade(0f, 2f);
        gamemodeImage2.DOFade(0f, 2f);
        gamemodeImage.DOFade(0f, 2f).OnComplete(() => gameStart = true);
    }

    void GameEnd()
    {
        SceneManager.LoadScene("MainScene");
    }
}
