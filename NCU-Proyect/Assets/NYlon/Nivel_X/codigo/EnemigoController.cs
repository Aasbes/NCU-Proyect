using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemigoController : MonoBehaviour
{
    [Header("Velocidad")]
    public float maxSpeed = 100f;
    public float speed = 100f;
    private Rigidbody2D rb2d;
    public int Respawn;
    [SerializeField]Transform spawnPoint;
    [Header("Disparo")]
    public GameObject disparo;
    public Transform spawn;
   
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate ()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x,-maxSpeed,maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
       

        if ( rb2d.velocity.x > -0.1f && rb2d.velocity.x < 0.1f){
            speed=-speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            
        }

        if (speed > 0f){
             gameObject.GetComponent<SpriteRenderer>().flipX=false;
        } else if (speed < 0f) {
             gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }
    }
   void OnTriggerEnter2D(Collider2D col) {
        
        if (col.gameObject.tag  == "Player"){
            
            Destroy(gameObject);
            
        }
        
    }
    /*void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.transform.CompareTag("Player"))
        { 
            col.transform.position= spawnPoint.position;
            
        }
    }*/
    
}