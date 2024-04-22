using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExBallMove : MonoBehaviour
{
    public Rigidbody2D rid;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        rid.GetComponent<Rigidbody2D>();
        rid.velocity = new Vector2(speed, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
