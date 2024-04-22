using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerControl : MonoBehaviour
{
    public GameObject ballManager;
    public float moveSpeed = 20f;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        moveDir = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {if (ballManager.GetComponent<BallManager>().PlayerFreeze == false)
        {
            moveDir = new Vector2(Input.GetAxisRaw("RightPlayerHorizontal") * moveSpeed * Time.deltaTime, Input.GetAxisRaw("RightPlayerVertical") * moveSpeed * Time.deltaTime);
            transform.Translate(moveDir);

            if (gameObject.transform.position.x > 25.5)
            {
                transform.position = new Vector2(25.5f, transform.position.y);
            }

            if (gameObject.transform.position.x < 1.5)
            {
                transform.position = new Vector2(1.5f, transform.position.y);
            }

            if (gameObject.transform.position.y < -10.5)
            {
                transform.position = new Vector2(transform.position.x, -10.5f);
            }

            if (gameObject.transform.position.y > 10.5)
            {
                transform.position = new Vector2(transform.position.x, 10.5f);
            }
        }
    }
}
