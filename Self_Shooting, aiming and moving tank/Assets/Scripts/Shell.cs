using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float speed = 0;
    float yspeed = 0f;
    float mass = 1;
    float force = 2;
    float drag = 1;
    float gravity = -9.8f;
    float gaccl;
    float accelaration;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        accelaration = force/mass;
        speed += accelaration * 1;
        gaccl = gravity/mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {  
        speed *= (1- Time.deltaTime * drag);
        yspeed += gaccl * Time.deltaTime;
        transform.Translate(0, yspeed, Time.deltaTime * speed);
    }
}
