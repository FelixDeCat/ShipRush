using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        CharacterShip character = other.GetComponent<CharacterShip>();

        if (character != null)
        {
            PickUp(character);
            Destroy(this.gameObject);
        }
    }
    public abstract void PickUp(CharacterShip character);
}
