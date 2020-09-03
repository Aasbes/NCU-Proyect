using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    bool canJump;
    bool doubleJump;
    public Transform bulletSpawner;
    public GameObject bullet;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f* Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moviendose", true);
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }

        if(Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f* Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moviendose", true);
            gameObject.GetComponent<SpriteRenderer>().flipX=false;
        }
        

        if(!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("moviendose", false);
        }
        
        if(Input.GetKeyDown("up") && canJump)
        {
            
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 550f));
            canJump = false;
        }

        PlayerShooting();   
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "piso1"){
            canJump = true;
        }
    }
    public void PlayerShooting()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet,bulletSpawner.position,bulletSpawner.rotation);
        }
    }
   
    


}
