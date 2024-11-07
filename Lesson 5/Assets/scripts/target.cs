using System;
using System.Transactions;
using UnityEngine;
using UnityEngine.Rendering;

public class target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxspeed = 16;
    private float maxtorque = 2;
    private float xRange = 4;
    private float ySpawnpos = -6;
    private GameManager gameManager;
    public int pointvalue;
    public ParticleSystem explosionParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = randomspawn();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {    
    
    }

    private void OnMouseDown(){
        if(gameManager.isGameActive){
            Destroy(gameObject);
            gameManager.UpdateScore(pointvalue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad")){gameManager.GameOver();}
    }

    Vector3 RandomForce(){
        return Vector3.up * UnityEngine.Random.Range(minSpeed, maxspeed);
    }
    
    float randomTorque(){
        return UnityEngine.Random.Range(-maxtorque, maxtorque);
    }

    Vector3 randomspawn(){
        return new Vector3(UnityEngine.Random.Range(-xRange, xRange), ySpawnpos);
    }
}
