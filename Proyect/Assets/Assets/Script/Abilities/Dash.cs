using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Abilities
{

    
    public override void trigger()
    {
        
            GameEvents.PlayerWantsToUseDash.Invoke();
        
       
    }
}
