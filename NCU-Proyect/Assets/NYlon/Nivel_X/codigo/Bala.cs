using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{ 
    private Rigidbody2D bulletRB;
    public float bulletSpeed;
    public float bulletLife;
    private GameObject player;
    private Transform playerTrans;
    void Awake() 
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans=player.transform;
    }
    void Start()
    {
        if(playerTrans.position.x>0)
        {
            bulletRB.velocity = new Vector2(bulletSpeed,bulletRB.velocity.y);
        }
        else 
        {
            bulletRB.velocity = new Vector2(-bulletSpeed,bulletRB.velocity.y);
        }
     }
    void Update()
    {
      //Destroy(gameObject,bulletLife);
    }
}
