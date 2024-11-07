using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty(){
        gameManager.StartGame(difficulty);
        Debug.Log(gameObject.name + " was clicked");
    }
}
