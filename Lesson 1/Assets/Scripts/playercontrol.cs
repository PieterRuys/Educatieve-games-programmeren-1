using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private float speed = 20.0f;
    private float turn_speed = 45.0f;
    private float horizontal_input;
    private float foreward_input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontal_input = Input.GetAxis("Horizontal");
        foreward_input = Input.GetAxis("Vertical");
        //move vehicle foreward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * foreward_input);
        //rotates car based on horizontal input
        transform.Rotate(Vector3.up, turn_speed * horizontal_input * Time.deltaTime);
    }
}
