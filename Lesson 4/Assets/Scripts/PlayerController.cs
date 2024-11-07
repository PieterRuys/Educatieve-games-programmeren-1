using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody PlayerRB;
    private GameObject focalPoint;
    private float powerupstrenght = 15.0f;
    public float speed = 5.0f;
    public bool hasPowerUp;
    public GameObject powerupindicator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        PlayerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupindicator.transform.position = transform.position + new Vector3(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PowerUp")) {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(Powerupcountdownroutine());
            powerupindicator.gameObject.SetActive(true);
        }
    }
    
    IEnumerator Powerupcountdownroutine(){
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupindicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp){
            Rigidbody enemyridigbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromplayer = (collision.gameObject.transform.position - transform.position);

            enemyridigbody.AddForce(awayfromplayer * powerupstrenght, ForceMode.Impulse);
        }
    }
}
