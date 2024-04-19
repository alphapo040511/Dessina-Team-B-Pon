using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManagr : MonoBehaviour
{
    public bool Roulette = true;
    public GameManagr leftPoint;
    public GameManagr rightPoint;
    public int gameMode;
    public float checkTime;
    public bool input = false;
    public Text gamemodetext;
    public Image gamemodeImage;
    public Image gamemodeImage2;
    public bool gameStart = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RouletteTimer());
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && input == true)
        {
            Roulette = false;
            Invoke("GameStart", 1.5f);
        }

        if(checkTime >= 0.1f)
        {
            gameMode = 1;
            gamemodetext.text = "SpeedUp";
            input = true;
        }
        if (checkTime >= 0.2f)
        {
            gameMode = 2;
            gamemodetext.text = "Wall";
        }
        if (checkTime >= 0.3f)
        {
            gameMode = 3;
            gamemodetext.text = "InvisibleBall";
        }
        if (checkTime >= 0.4f)
        {
            gameMode = 4;
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
}
