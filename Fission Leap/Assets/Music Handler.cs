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
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UIHandler = GameObject.Find("UI handler");
        UIbehaviour = UIHandler.GetComponent<UIbehaviour>();
        if (UIbehaviour.activeSceneBuildIndex < 2)
        {
            audioSource.volume = 0.3f;
            audioSource.clip = BgmClips[0];
        }
    }
}
