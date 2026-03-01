using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIbehaviour : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public PlayerMovement PlayerMovement;
    public Button Retry;
    public GameObject gameOverCanvas;
    public GameObject player;
    public Scene activeScene;
    public Scene nextScene;
    public Scene lastScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + PlayerMovement.health.ToString();
        scoreText.text = "Score: " + PlayerMovement.score.ToString();
        activeScene = SceneManager.GetActiveScene();
        try
        {
            nextScene = SceneManager.GetSceneByBuildIndex(activeScene.buildIndex + 1);
        }
        catch
        {
            //Debug.Log("On last level");
        }
        try
        {
            lastScene = SceneManager.GetSceneByBuildIndex(activeScene.buildIndex - 1);
        }
        catch
        {
            //Debug.Log("On first level");
        }
    }
    public void retry()
    {
        gameOverCanvas.SetActive(false);
        PlayerMovement.health = PlayerMovement.maxHealth;
        PlayerMovement.score = 0;
        player.transform.position = PlayerMovement.SpawnPoint.transform.position;
    }
    public void nextLevel()
    {
        if (SceneManager.GetSceneByBuildIndex(nextScene.buildIndex) != null)
        {
            SceneManager.LoadScene(nextScene.buildIndex);
        }
    }
    public void previousLevel()
    {
        if (lastScene.buildIndex > -1)
        {
            SceneManager.LoadScene(activeScene.buildIndex - 1);
        }
    }
}
