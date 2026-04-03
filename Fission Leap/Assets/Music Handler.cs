using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Persistance : MonoBehaviour
{
    public AudioClip[] BgmClips;
    public UIbehaviour UIbehaviour;
    public AudioSource audioSource;
    public GameObject UIHandler;
    public bool muted;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (muted == false)
            {
                muted = true;
            } else
            {
                muted = false;
            }
        }
        if (muted)
        {
            audioSource.volume = 0f;
        } else
        {
            audioSource.volume = 0.3f;
        }
        UIHandler = GameObject.Find("UI handler");
        UIbehaviour = UIHandler.GetComponent<UIbehaviour>();
        if (UIbehaviour.activeSceneBuildIndex < 2)
        {
            audioSource.clip = BgmClips[0];
        }
    }
}
