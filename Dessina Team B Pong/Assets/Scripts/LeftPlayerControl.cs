using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerControl : MonoBehaviour
{
    public float moveSpeed = 10f;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        moveDir = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector2(Input.GetAxisRaw("LeftPlayerHorizontal") * moveSpeed * Time.deltaTime, Input.GetAxisRaw("LeftPlayerVertical") * moveSpeed * Time.deltaTime);
        transform.Translate(moveDir);
        
    }
}
