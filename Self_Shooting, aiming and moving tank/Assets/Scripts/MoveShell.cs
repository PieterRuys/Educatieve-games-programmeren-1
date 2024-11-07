using UnityEngine;

public class MoveShell : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Time.deltaTime * 0.5f, Time.deltaTime);
    }
}
