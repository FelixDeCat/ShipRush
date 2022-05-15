using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Ring next;

    private void OnTriggerEnter(Collider other)
    {
        CharacterShip character = other.GetComponent<CharacterShip>();
        if (character)
        {
            RingManager.instance.SetRing(next);
        }
    }

    private void OnDrawGizmos()
    {
        if (next == null) return;
        Gizmos.DrawLine(this.transform.position, next.transform.position);
    }
}
