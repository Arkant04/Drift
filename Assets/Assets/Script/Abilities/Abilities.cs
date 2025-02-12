using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public abstract class Abilities : ScriptableObject
{
    public float elapseCooldown;
    public float cooldown = 2f;

    public abstract void trigger(MonoBehaviour pruebaCourutine, ParticleSystem dashParticle);

    public IEnumerator DashCooldown()
    {
        while (elapseCooldown <= cooldown)
        {
            elapseCooldown ++;
            yield return null;
        }
    }
}
