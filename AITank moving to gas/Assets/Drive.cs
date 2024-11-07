using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.Mathematics;
using Unity.VisualScripting;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnspeed = 0.1f;
    public float rotationSpeed = 100.0f;
    public GameObject fuel;
    private bool pilot = false;

    void Start()
    {

    }

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        // Rotate around our y-axis
        transform.Rotate(0, 0, -rotation);

        if(Input.GetKeyDown(KeyCode.Space)){
            CalcDistance();
            calcangle();
        }

        if(Input.GetKeyDown(KeyCode.T)){
            pilot = !pilot;
        }
        if (pilot){
            Autopilot();
        }
    }

    void Autopilot(){
        Vector3 tankforeward = transform.up;
        Vector3 fueldir = fuel.transform.position - transform.position;
        Vector3 direction = fuel.transform.position - transform.position;
        if (calcangle() > 5){
            int clockwise = 1;
            if (cross(tankforeward, fueldir).z < 0){
                clockwise = -1;
            } 
            transform.Rotate(0, 0, turnspeed * clockwise * Time.deltaTime)   ;
        }
        else if(direction.magnitude > 2){
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            transform.position = transform.position + velocity;
        }   
    }

    void CalcDistance(){
        float distance = (Mathf.Sqrt(Mathf.Pow(transform.position.x - fuel.transform.position.x, 2) + Mathf.Pow(transform.position.z - fuel.transform.position.z, 2)));
        Vector3 fuelpos = new Vector3(fuel.transform.position.x, 0, fuel.transform.position.z);
        Vector3 tankpos = new Vector3(transform.position.x, 0, transform.position.z);
        float udistance = Vector3.Distance(fuelpos, tankpos);
        Vector3 fueltotank = fuelpos - tankpos;
        //Debug.Log("distance: " + distance);
        //Debug.Log("udistance: " + udistance);
        //Debug.Log("vmag " + fueltotank.magnitude);
        //Debug.Log("sq vmag " + fueltotank.sqrMagnitude);
    }

    float calcangle(){
        Vector3 tankforeward = transform.up;
        Vector3 fueldir = fuel.transform.position - transform.position;
        float dot = (tankforeward.x * fueldir.x) + (tankforeward.y * fueldir.y);
        float len_tank = tankforeward.magnitude;
        float len_fueldir = fueldir.magnitude;
        float angle = Mathf.Acos(dot/(len_tank*len_fueldir));
        //Debug.Log("tankforward: " + len_tank);
        //Debug.Log("tankforward: " + len_fueldir);
        //Debug.Log("Angle: " + angle);
        return angle * Mathf.Rad2Deg; 
        
    }

    Vector3 cross(Vector3 V, Vector3 W){
        return new Vector3(V.y * W.z - V.z * W.y, V.z * W.x - V.x * W.z, V.x * W.y - V.y * W.x); 
    }
}