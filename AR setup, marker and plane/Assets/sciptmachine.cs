using UnityEngine;
using UnityEngine.UI;

public class sciptmachine : MonoBehaviour
{
    public Button ButtonRotateLeft;
    public Button ButtonRotateRight;
    public Button ButtonInfo;
    public Button ButtonAudio;
    public Canvas canvasInfo;
    public Transform Model;
    public AudioSource audiosource;
    private bool info = false;
    private bool audio = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ButtonRotateLeft.onClick.AddListener(rotateLeft);
        ButtonRotateRight.onClick.AddListener(rotateRight);
        ButtonInfo.onClick.AddListener(hideCanvas);
        ButtonAudio.onClick.AddListener(ToggleAudio);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Model == null)
            Model = GameObject.FindGameObjectWithTag("ModelObject").GetComponent<Transform>();
            canvasInfo = GameObject.FindGameObjectWithTag("ModelObject").GetComponentInChildren<Canvas>();
            audiosource  = GameObject.FindGameObjectWithTag("ModelObject").GetComponentInChildren<AudioSource>();

            canvasInfo.enabled = info;
            audiosource.enabled = audio;
    }

    void rotateLeft(){
        Debug.Log("Going Left");
        Model.Rotate(0, 15, 0);
    }
    void rotateRight(){
        Debug.Log("Going Right");
        Model.Rotate(0, -15, 0);
    }

    void hideCanvas(){
        info =! info;
        canvasInfo.enabled = info;
    }

    void ToggleAudio(){
        audio =! audio;
        audiosource.enabled = audio;


    }
}
