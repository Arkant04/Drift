using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Abilities
{

    
    public override void trigger(MonoBehaviour pruebaCourutine, ParticleSystem dashParticle)
    {
        if (elapseCooldown == 0)
        {
            pruebaCourutine.StartCoroutine(DashCooldown());
            GameEvents.PlayerWantsToUseDash.Invoke();
            dashParticle.Play();
        }
        
        else if (elapseCooldown >= cooldown)
        {
            
            elapseCooldown = 0;
        }
       
    }
}
