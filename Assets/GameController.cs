using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 moveVector;
    public GameObject trainA;
    public GameObject trainB;
    Rigidbody2D rigidBody;
    public ParticleSystem explosionParticle;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveVector = new Vector3(0, 1, 0);
    }

    void Update()
    {
        MoveTrain();
    }
    public void MoveTrain()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriggerB")
        {
            trainA.transform.Rotate(0, 0, -180);
            Debug.Log("Triggered");
        }
        if (collision.gameObject.tag == "TriggerA")
        {
            trainB.transform.Rotate(0, 0, -180);
            Debug.Log("Triggered");
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Train")
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
}
