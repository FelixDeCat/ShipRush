using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo esto es una hermosa negreda

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] int life = 100;

    private void Start()
    {
        
        var col = GetComponent<Collider>();
        if (col == null) { this.gameObject.AddComponent<BoxCollider>(); }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            OnDeath();
        }
        else
        {
            FeedbackTakeDamage();
        }
    }

    public abstract void FeedbackTakeDamage();
    public abstract void OnDeath(); 
}
