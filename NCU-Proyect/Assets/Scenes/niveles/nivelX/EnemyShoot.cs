using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player_pos;
    public float speed;
    public float distancia_activacion;
    public float distancia_minima;
    public float distancia_frenado;
    public SpriteRenderer sprit;
    public GameObject balaPrefab;
    //public Transform derecha;
    //public Transform izquierda;
   
    private float tiempo;
    /*
    public Transform bulletSpawner;
    public GameObject bullet;
    */
    void Start()
    {
        player_pos = GameObject.Find("Jugador1").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        //MOVIMIENTO DEL ENEMIGO
        #region 
        if( Vector2.Distance(transform.position,player_pos.position)<distancia_activacion)
        {
            if( Vector2.Distance(transform.position,player_pos.position)>distancia_frenado)
            {
                transform.position=Vector2.MoveTowards(transform.position,player_pos.position, speed*Time.deltaTime);
            }
            if( Vector2.Distance(transform.position,player_pos.position)<distancia_minima)
            {
                transform.position=Vector2.MoveTowards(transform.position,player_pos.position, -speed*Time.deltaTime);
            }
        }
        #endregion
        //Flip del enemigo
        #region 
        if(player_pos.position.x>this.transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX=false;
            
        }
        if(player_pos.position.x<this.transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX=true;
            
        }
        #endregion
        //DISPARO
        #region 
        
        #endregion
    }
    public void Update() {
        /*
        tiempo+=Time.deltaTime;
        if(tiempo>=1)
        {
        //Instantiate(bullet,bulletSpawner.position, bulletSpawner.rotation);
            tiempo=0;
            direccion = sprit.flipX;
            
            if (direccion)
            {
                Instantiate(balaPrefab, derecha.position, derecha.rotation);
            }
            else
            {
                Instantiate(balaPrefab, izquierda.position, izquierda.rotation);
            }
        }   
        
        */
        //torreta.direccion = sprit.flipX;
        /*
        if (torreta.direccion)
        {
            rbd.velocity = new Vector3(velocidad, rbd.velocity.y, 0);
        }
        else
        {
            rbd.velocity = new Vector2(-velocidad, rbd.velocity.y);
        }*/
    }
    
}
