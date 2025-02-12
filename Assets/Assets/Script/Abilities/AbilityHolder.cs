using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [Header("AbilitiesConfig")]
    [SerializeField] List<Abilities> AbilitieHolder;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject Car;
    [SerializeField] GameObject Ball;
    Controles controls;


    [Header("ParticlesConfig")]
    [SerializeField] ParticleSystem dashParticle;
 

    void Start()
    {
        controls = new Controles();
        controls.Enable();
        controls.Movement.Enable();
        rb = GetComponent<Rigidbody>();
        dashParticle.Stop();
        print("aaaaaa");
    }

    void Update()
    {
        
        
        if (controls.Movement.Dash.IsPressed())
        {
            AbilitieHolder[0].trigger(this, dashParticle);
            print("AAAAAAAA");
        }

        //if (controls.Movement.ChangeModelCar.IsPressed())
        //{
        //    Ball.SetActive(false);
        //    Car.SetActive(true);
        //}

        //if (controls.Movement.ChangeModelBall.IsPressed())
        //{
        //    Ball.SetActive(true);
        //    Car.SetActive(false);
        //}
        

    }
    
}
