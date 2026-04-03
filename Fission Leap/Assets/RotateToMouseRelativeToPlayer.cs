using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouseRelativeToPlayer : MonoBehaviour
{
    public float angle;
    public Vector3 mousePos;
    public GameObject player;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        direction = new Vector2((mousePos.x - player.transform.position.x) * 100, (mousePos.y - player.transform.position.y) * 100).normalized;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (direction == Vector2.zero)
        {
            Debug.Log("wtf2");
        }

        if (gameObject.name == "Recoil gun")
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
