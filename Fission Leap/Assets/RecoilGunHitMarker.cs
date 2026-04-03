using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class RecoilGunHitMarker : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement PlayerMovement;
    public Vector2 recoilDirection;
    public float distanceFromPlayer;
    public float recoilGunForce;
    public Vector2 normalisedRecoilDirection;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerMovement = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerMovement.touchingFloor)
        {
            recoilDirection = Player.transform.position - gameObject.transform.position;
            distanceFromPlayer = recoilDirection.magnitude;
            if (distanceFromPlayer == 0)
            {
                distanceFromPlayer = 1;
            }
            normalisedRecoilDirection = recoilDirection.normalized;
            float recoilStrength = recoilGunForce / distanceFromPlayer;
            normalisedRecoilDirection.x = normalisedRecoilDirection.x * 5;
            PlayerMovement.rb.AddForce(normalisedRecoilDirection * recoilStrength, ForceMode2D.Impulse);
            Debug.Log("bounced");
            Destroy(gameObject);
        }
        if (PlayerMovement.touchingFloor)
        {
            normalisedRecoilDirection = Vector2.zero;
            Destroy(gameObject);
        }
    }
}
