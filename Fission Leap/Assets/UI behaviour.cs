using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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
    public int activeSceneBuildIndex;
    public int nextSceneBuildIndex;
    public static int score { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + PlayerMovement.health.ToString();
        scoreText.text = "Score: " + score.ToString();
        activeScene = SceneManager.GetActiveScene();
        activeSceneBuildIndex = activeScene.buildIndex;
        try
        {
            nextSceneBuildIndex = activeSceneBuildIndex + 1;
            //nextScene = SceneManager.GetSceneByBuildIndex(nextSceneBuildIndex);
        }
        catch
        {
            Debug.Log("On last level");
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
        score = 0;
        player.transform.position = PlayerMovement.SpawnPoint.transform.position;
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(nextSceneBuildIndex);
        player.transform.position = PlayerMovement.SpawnPoint.transform.position;

        //SceneManager.UnloadSceneAsync(activeSceneBuildIndex - 1);
    }
    public void previousLevel()
    {
        if (lastScene.buildIndex > -1)
        {
            SceneManager.LoadScene(activeScene.buildIndex - 1);
        }
    }
}
