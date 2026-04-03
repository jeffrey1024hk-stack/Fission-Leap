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
    public RotateToMouseRelativeToPlayer RotateToMouseRelativeToPlayer;
    [SerializeField]
    public Vector2 bulletDirection;
    public GameObject hitMarker;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        RotateToMouseRelativeToPlayer = Player.GetComponent<RotateToMouseRelativeToPlayer>();
        bulletDirection = RotateToMouseRelativeToPlayer.direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //bulletRb.AddForce(Vector2.right, ForceMode2D.Impulse);
        if (RotateToMouseRelativeToPlayer.direction == Vector2.zero)
        {
            Debug.Log("wtf");
        }
        bulletRb.AddForce(bulletDirection, ForceMode2D.Impulse);
    }

    public void bulletMarkerFromRecoilGun()
    {
        Instantiate(hitMarker);
        hitMarker.transform.position = gameObject.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Bullet collided with wall");
            bulletMarkerFromRecoilGun();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Next Level"))
        {
            Debug.Log("Bullet collided with wall");
            bulletMarkerFromRecoilGun();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Bullet collided with wall");
            bulletMarkerFromRecoilGun();
            Destroy(gameObject);
        }
    }
    
}
