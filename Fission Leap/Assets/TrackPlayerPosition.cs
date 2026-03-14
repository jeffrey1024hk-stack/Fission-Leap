using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackPlayerPosition : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    public Vector3 cameraPos;
    public float cameraPosY;
    GameObject nextLevel;
    Scene CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        CurrentScene = SceneManager.GetActiveScene();
    }
    void LateUpdate()
    {
        nextLevel = GameObject.FindWithTag("Next Level");
        cameraPos = Player.transform.position;

        if (cameraPos.y < 2.29)
        {
            cameraPos.y = 2.29f;
        }
        if (cameraPos.x < -9.7)
        {
            cameraPos.x = -9.7f;
        }
        
        if (CurrentScene.buildIndex == 0)
        {
            if (cameraPos.x > -1.36f)
            {
                cameraPos.x = -1.36f;
                transform.position = cameraPos;
            }
        } else if (CurrentScene.buildIndex == 1)
        {
            if (cameraPos.x > -1.24)
            {
                cameraPos.x = -1.24f;
                transform.position = cameraPos;
            }
        }

            cameraPos = new Vector3(cameraPos.x, cameraPos.y, (float)-10);
        transform.position = cameraPos;
    }
    
}
