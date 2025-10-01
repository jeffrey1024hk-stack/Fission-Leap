using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Vector2 position;
    [SerializeField]
    float moveSpeed;
    float horizontalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        position = gameObject.transform.position;
        if(horizontalInput != 0)
        {
            position.x += moveSpeed * Time.deltaTime * horizontalInput;
        }
        gameObject.transform.position = position;
    }
}
