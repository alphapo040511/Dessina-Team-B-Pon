using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenParticle : MonoBehaviour
{
    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.transform.tag == "Ball")
        {
            ContactPoint2D cp = col.contacts[0];
            Quaternion way = Quaternion.LookRotation(- cp.normal);
            var temp =Instantiate(Particle, cp.point, way);
            Destroy(temp, 1.0f);
        }
    }
}
