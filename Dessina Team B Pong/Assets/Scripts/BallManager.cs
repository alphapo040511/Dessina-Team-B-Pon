using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public GameObject ball;
    public Text countUI;

    // Start is called before the first frame update
    void Start()
    {
        ball = Resources.Load<GameObject>("Prefabs/Ball");
        ball = Instantiate(ball);
        ball.transform.position = new Vector2(0, 10);
        StartCoroutine(StartBall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        ball = Resources.Load<GameObject>("Prefabs/Ball");
        ball = Instantiate(ball);
        ball.transform.position = new Vector2(0, 10);
        StartCoroutine(StartBall());
    }

    private IEnumerator StartBall()
    {
        countUI.enabled = true;
        int count = 3;
        countUI.text = count.ToString();
        float checkTime = 0;
        while (checkTime <= 3)
        {
            if (checkTime >= 2)
            {
                count = 1;
                countUI.text = count.ToString();
            }
            else if (checkTime >=1)
            {
                count = 2;
                countUI.text = count.ToString();
            }
            
            checkTime += Time.deltaTime;
            yield return null;
        }
        countUI.enabled = false;
        ball.GetComponent<BallMoving>().StartMove = true;
        yield break;
    }
}
