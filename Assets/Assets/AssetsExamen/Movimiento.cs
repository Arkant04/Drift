using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] float maxRange;
    [SerializeField] float acceleration = 5;
    [SerializeField] float maxVelocity = 15;
    [SerializeField] ParticleSystem pr;
    [SerializeField] Transform target;
    Vector3 dc = new Vector3 (0, 0, 0);
    Vector3 randomPosition;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randompos();
        pr.Play();
    }

    void FixedUpdate()
    {
        //if (transform.position.magnitude > maxRange)
        //{
        //    pr.Stop();

        //    pr.Play();
        //    randompos();
        //}

        

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) * maxVelocity;
        }
        dc = (target.position - transform.position).normalized;
        transform.up = target.position - transform.position;
        rb.velocity += dc * acceleration * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("A"))
        {
            pr.Stop();
            transform.position = new Vector3(0, 0, 0);
            pr.Play();
            randompos();
        }

        
    }
    
    void randompos()
    {
        randomPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        print(randomPosition);

    }


}
