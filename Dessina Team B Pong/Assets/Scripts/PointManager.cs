using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public GameObject ballManager;
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
            Invoke("Respawn", 1);
            point++;
            pointUI.text = point.ToString();
        }
    }

    private void Respawn()
    {if(point <3)
        ballManager.GetComponent<BallManager>().Spawn();
    }
}
