using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D bulletRB;
    public float bulletSpeed;
    public float bulletLife;
    public Transform player_pos;
    private float distancia_activacion=26f;
    public Transform enemigoTrans;
    void Awake() 
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if( Vector2.Distance(transform.position,player_pos.position)<distancia_activacion)
        {
        bulletRB.velocity = new Vector2(-bulletSpeed,bulletRB.velocity.y);
        }
    }

 
}
