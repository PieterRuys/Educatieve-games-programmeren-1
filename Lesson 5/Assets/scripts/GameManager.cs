using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI gameover;
    public Button restartbutton;
    public GameObject titlescreen;
    public bool isGameActive = false;
    private float spawnrate = 1.0f;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty){
        Debug.Log("start_game");
        spawnrate /= difficulty;
        titlescreen.SetActive(false);
        isGameActive = true;
        score = 0;
        StartCoroutine(spawntarget());
        UpdateScore(0);
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(){
        gameover.gameObject.SetActive(true);
        restartbutton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoretext.text = "Score: " + score;
    }
    IEnumerator spawntarget(){
        while(isGameActive){
            Debug.Log("spawnobject");
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
