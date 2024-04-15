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
        // �� �������� ���ҽ����� �ε��մϴ�.
        ball = Resources.Load<GameObject>("Prefabs/Ball");
        // �ε��� �������� �����Ͽ� ���� ���� ������Ʈ�� �����մϴ�.
        ball = Instantiate(ball);
        // ������ ���� �ʱ� ��ġ�� �����մϴ�.
        ball.transform.position = new Vector2(0, 10);
        // ī��Ʈ�ٿ� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(StartBall());
    }

    private IEnumerator StartBall()
    {
        // ī��Ʈ�ٿ� UI�� Ȱ��ȭ�մϴ�.
        countUI.enabled = true;
        // �ʱ� ī��Ʈ �� ����
        int count = 3;
        countUI.text = count.ToString();
        float checkTime = 0; // ī��Ʈ�ٿ��� üũ�ϴ� �ð� ���� �ʱ�ȭ
        while (checkTime <= 3) // 3�� ���� �ݺ�
        {
            // üũ �ð��� ���� ī��Ʈ �� ����
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

            // �ð��� ������Ʈ�մϴ�.
            checkTime += Time.deltaTime;
            yield return null; // �� �������� ��ٸ��ϴ�.
        }
        // ī��Ʈ�ٿ��� ����Ǹ� UI�� ��Ȱ��ȭ�ϰ� ���� �̵��� �����մϴ�.
        countUI.enabled = false;
        ball.GetComponent<BallMoving>().StartMove = true; // BallMoving ��ũ��Ʈ�� StartMove�� Ȱ��ȭ�մϴ�.
        yield break; // �ڷ�ƾ�� �����մϴ�.
    }

}
