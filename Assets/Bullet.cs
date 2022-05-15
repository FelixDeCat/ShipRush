using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;
    public void Initialize(Vector3 position, Vector3 direction)
    {
        this.transform.position = position;
        this.transform.up = direction;
        Destroy(this.gameObject, 3f);
    }

    private void Update()
    {
        this.transform.position += this.transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            ParticleInstancer.instance.Instace_Sparks(this.transform.position);
        }

        
        Destroy(this.gameObject);
    }
}
