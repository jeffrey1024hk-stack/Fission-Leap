using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bulletlogic : MonoBehaviour
{
    public Vector2 bulletPos;
    public float bulletSpeed;
    public Rigidbody2D bulletRb;
    public PlayerMovement PlayerMovement;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = gameObject.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(PlayerMovement.bulletDirection, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //bulletRb.AddForce(Vector2.right, ForceMode2D.Impulse);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Bullet collided with wall");
            Destroy(gameObject);
        }
    }
}
