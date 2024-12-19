using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [Header("AbilitiesConfig")]
    [SerializeField] List<Abilities> AbilitieHolder;
    [SerializeField] Rigidbody rb;
    Controles controls;
    void Start()
    {
        controls = new Controles();
        controls.Enable();
        controls.Movement.Enable();
        rb = GetComponent<Rigidbody>();
        print("aaaaaa");
    }

    void Update()
    {
        
        
        if (controls.Movement.Dash.IsPressed())
        {
            AbilitieHolder[0].trigger();
            print("AAAAAAAA");
        }

        if (controls.Movement.Jump.IsPressed())
        {
            AbilitieHolder[1].trigger();
            print("Que floto");
        }
        
    }
    void usingDash()
    {

    }
}
