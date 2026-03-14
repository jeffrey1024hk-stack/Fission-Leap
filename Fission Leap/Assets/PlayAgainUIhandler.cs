using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class PlayAgainUIhandler : MonoBehaviour
{
    public GameObject playAgainCanvas;
    public UIbehaviour UIbehaviour;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerMovement.TriggerPlayAgain)
        {
            playAgainCanvas.SetActive(true);
        }
    }
    public void playAgain()
    {
        playAgainCanvas.SetActive(false);
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(SceneManager.sceneCountInBuildSettings - 1);
    }
}
