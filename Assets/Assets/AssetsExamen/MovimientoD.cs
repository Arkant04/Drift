using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovimientoD : MonoBehaviour
{
    [SerializeField] float maxRange;
    [SerializeField] float acceleration = 5;
    [SerializeField] float maxVelocity = 15;
    [SerializeField] ParticleSystem pr;
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
       ///random por velocidad 

        if (transform.position.magnitude > maxRange)
        {
            pr.Stop();
            transform.position = new Vector3 (0, 0, 0);
            pr.Play();
            randompos();
        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        rb.velocity += randomPosition * acceleration * Time.deltaTime;
    }

    void randompos()
    {
        randomPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        transform.up = randomPosition;
        print(randomPosition);

    }


}
