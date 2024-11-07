using Unity.Mathematics;
using UnityEngine;

public class FireSHell : MonoBehaviour
{
    public GameObject turret;
    public GameObject enemy;
    public GameObject bullet;
    public Transform turretbase;
    public float rotspeed = 5;
    float speed_bullet = 15;
    float movespeed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (enemy.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotspeed);
        float? angle = rotateturret();
        if(angle != null){
            createbullet();
        }
        else{
            transform.Translate(0, 0, Time.deltaTime * movespeed);
        }
    }


    float? rotateturret(){
        float? angle = calcangle(false);
        if(angle != null){
            turretbase.localEulerAngles = new Vector3(360f - (float)angle, 0f,0f);
        }
        return angle;
    }
    float? calcangle(bool low){
        Vector3 targetdir = enemy.transform.position - transform.position;
        float y = targetdir.y;
        targetdir.y = 0f;
        float x = targetdir.magnitude - 1;
        float gravity = 9.8f;
        float ssqr = speed_bullet *speed_bullet;
        float underthesqrroot = ssqr* ssqr - gravity * (gravity* x *x + 2 *y * ssqr);
        if (underthesqrroot >= 0f){
            float root = Mathf.Sqrt(underthesqrroot);
            float highAngle = ssqr + root;
            float lowangle = ssqr - root;

            if(low){
                return Mathf.Atan2(lowangle, gravity*x) * Mathf.Rad2Deg;
            }
            return Mathf.Atan2(highAngle, gravity*x) * Mathf.Rad2Deg;
        }
        return null;
    } 
    void createbullet(){
        GameObject shell = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        shell.GetComponent<Rigidbody>().linearVelocity = speed_bullet * turretbase.forward;
    }
}
