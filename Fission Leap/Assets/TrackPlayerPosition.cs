using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerPosition : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    public Vector3 cameraPos;
    public float cameraPosY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPosY = Player.transform.position.y;
        if (cameraPosY < 0)
        {
            cameraPosY = 0;
        }
        cameraPos = new Vector3 (Player.transform.position.x, cameraPosY, (float)-10);
        transform.position = cameraPos;
    }
}
