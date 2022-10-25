using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float SceneLoadDelay=2f;
    ScoreKeeper ScoreKeeper;
    void Awake(){
        ScoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame(){
        ScoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");

    }
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad("GameOver",SceneLoadDelay));
    }
    public void Quit(){
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string Scenename,float delay){
yield return new WaitForSeconds(delay);
SceneManager.LoadScene(Scenename);
    }
}
