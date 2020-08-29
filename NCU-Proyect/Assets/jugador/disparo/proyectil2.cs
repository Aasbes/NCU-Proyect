using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil2 : MonoBehaviour
{
    public GameObject player;


    private Rigidbody2D rbd;
    public float velocidad;
    public float duracion;//duracion objeto en pantalla

    // Start is called before the first frame update

    void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("jugador2");








    }

    void Start()
    {

        if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            //disparo izquierda
            rbd.velocity = new Vector2(-velocidad, rbd.velocity.y);
        }
        else
        {
            //disparo derecha
            rbd.velocity = new Vector2(velocidad, rbd.velocity.y);
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
        if (tocando.tag != "jugador2")
        {
            //se activan particulas al colisionar
            GetComponent<ParticleSystem>().Play();

            //se desactivan para evitar otras coliciones
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

        }

    }
}
