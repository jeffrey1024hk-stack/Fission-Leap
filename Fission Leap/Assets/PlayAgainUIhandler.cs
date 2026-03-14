using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayAgainUIhandler : MonoBehaviour
{
    public GameObject playAgainCanvas;
    public UIbehaviour UIbehaviour;
    public PlayerMovement playerMovement;
    public TextMeshProUGUI Score;
    // Start is called before the first frame update
    void Start()
    {
        playAgainCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMovement.TriggerPlayAgain)
        {
            playAgainCanvas.SetActive(true);
            Score.text = UIbehaviour.scoreText.text;
        }
    }
    public void playAgain()
    {
        playAgainCanvas.SetActive(false);
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(SceneManager.sceneCountInBuildSettings - 1);
        UIbehaviour.score = 0;
    }
}
