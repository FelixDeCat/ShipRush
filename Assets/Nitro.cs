using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : PowerUp
{
    public override void PickUp(CharacterShip character)
    {
        character.GetNitro();
        ParticleInstancer.instance.Instace_Nitro(this.transform.position);
    }
}
