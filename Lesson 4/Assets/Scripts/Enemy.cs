using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 lookdirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookdirection * speed);
        if(transform.position.y < -10){Destroy(gameObject);}
    }
}
