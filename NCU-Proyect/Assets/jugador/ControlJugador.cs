using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using UnityEngine;
//control del personaje
public class ControlJugador : MonoBehaviour
{
    
    //movimiento personaje
    public Transform pos;
    public float speed = 0.5f;
    public Rigidbody2D rbd;
    public float salto = 2f;
    public bool puedeSaltar = false;

    //sprites animacion
    public SpriteRenderer sprit;
    //public SpriteRenderer sprit2;
    public Animator anim;

    //disparo
    public Transform DisparoDerecha;
    public Transform DisparoIzquierda;
    public GameObject balaPrefab;
    //vida y daño
    public GameObject barraVidaPersonaje;
    /*
    public static ControlJugador instance;  
    void Awake()
    {
        
        
        if (instance == null  )
        {
            
            instance = this;
            DontDestroyOnLoad(gameObject);
            

        }
        else if (instance != this)
        {
            Destroy(gameObject);
           
        }
        
        
    }
    */
    void Start()
    {
        
        anim.SetBool("saltar", true);
    }
    // Update is called once per frame
    void Update()
    {

        
        //avance a la derecha
        if (Input.GetKey(KeyCode.D))
        {
            
            pos.position += new Vector3(1f, 0, 0) * speed * Time.deltaTime;
            sprit.flipX = false;
            anim.SetBool("velocidad", true);
            //sprit2.flipY = false;

            

        }
        else
        {   //avance a la izquierda
            if (Input.GetKey(KeyCode.A))
            {
                
                pos.position += new Vector3(-1f, 0, 0) * speed * Time.deltaTime;
                sprit.flipX = true;
                anim.SetBool("velocidad", true);
                //sprit2.flipY= true;
                
                
            }

            else
            {
                anim.SetBool("velocidad", false);

            }
        }
        //salto
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar == true)
        {
            rbd.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            //puedeSaltar = false;
            //anim.SetBool("saltar", true);

            
        }
        //verifica la direccion para disparar
        ladoDisparo(sprit);



    }

    
    //verifica lo que toca el jugador
    public void OnCollisionEnter2D(Collision2D tocando)
    {
        if (tocando.gameObject.tag == "suelo")
        {
            puedeSaltar = true;
            anim.SetBool("saltar", false);
        }
        //daño recibido
        if (tocando.gameObject.tag == "enemigo" )
        {

            Color color = new Color(255 / 255f, 106 / 255f, 0 / 255f);
            sprit.color = color;

            barraVidaPersonaje.SendMessage("dañoRecibido", 15);


        }
        if (tocando.gameObject.tag == "eliminacion")
        {
            pos.position = new Vector3(0, 0, 0);
            barraVidaPersonaje.SendMessage("dañoRecibido", 25);
        }

        if (tocando.gameObject.tag == "recolectable")
        {
            Destroy(tocando.gameObject);

        }
        if (tocando.gameObject.tag == "reinicioPosicion")
        {
            pos.position = new Vector3(0, 0, 0);
        }



    }
    

    
    
    public void OnCollisionExit2D(Collision2D tocando)
     {
        if (tocando.gameObject.tag == "suelo" )
        {
            puedeSaltar = false;
            anim.SetBool("saltar", true);
        }
        if (tocando.gameObject.tag == "enemigo")
        {
            sprit.color = Color.white;
        }

    }



    //disparo
    public void PlayerShooting(Transform origen)
    {
        //if (Input.GetButtonDown("Fire1"))
        if    (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(balaPrefab, origen.position,origen.rotation);
            
        }



    }
    //verifica la direccion para disparar
    public void ladoDisparo(SpriteRenderer sprit)
    {
        if(sprit.flipX == false)
        {
            PlayerShooting(DisparoDerecha);
        }
        else
        {
            PlayerShooting(DisparoIzquierda);
        }
    }


   



}





