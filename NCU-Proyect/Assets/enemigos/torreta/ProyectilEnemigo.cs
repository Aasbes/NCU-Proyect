using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    
    public Transform pos;
    private Rigidbody2D rbd;
    public float velocidad;
    public float duracion;//duracion objeto en pantalla

    // Start is called before the first frame update

    void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();



        





    }

    void Start()
    {
        //rbd.velocity = new Vector3(velocidad, rbd.velocity.y,0);
        
        if (torreta.direccion)
        {
            rbd.velocity = new Vector3(velocidad, rbd.velocity.y, 0);
        }
        else
        {
            rbd.velocity = new Vector2(-velocidad, rbd.velocity.y);
        }








    }

    // Update is called once per frame
    void Update()
    {
       
        Destroy(gameObject, duracion);
    }

    //sistema de particulas al colisionar
    void OnTriggerEnter2D(Collider2D tocando)
    {
        if (tocando.gameObject.tag != "enemigo")
        {
            
            
            //se activan particulas al colisionar
            //GetComponent<ParticleSystem>().Play();

            //se desactivan para evitar otras coliciones
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
        




    }
}
