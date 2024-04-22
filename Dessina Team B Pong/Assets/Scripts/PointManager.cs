using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public GameObject ballManager;
    public GameObject gameManager;
    public GameObject subWin;
    public GameObject wall;
    public int point;
    public Text pointUI;

    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        pointUI.text = point.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ball")
        {
            Destroy(collision.gameObject);
            point++;
            pointUI.text = point.ToString();
            if (point < 3)
            {
                subWin.SetActive(true);
                Invoke("SubWinTrun", 3f);
            }
        }
    }

    private void Respawn()
    {if(point <3)
        gameManager.GetComponent<GameManagr>().reStart = true;
    }

    private void SubWinTrun()
    {
        Invoke("Respawn", 1);
        subWin.SetActive(false);
        wall.gameObject.SetActive(false);
    }
}
