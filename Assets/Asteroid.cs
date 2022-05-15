using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Damageable
{
    Vector3 dir;
    Vector3 rotation;
    float speed;
    private void Start()
    {
        speed = Random.Range(0, 0.1f);
        dir = (Random.insideUnitSphere - transform.position).normalized;
        rotation = Random.insideUnitSphere;
    }

    public override void FeedbackTakeDamage()
    {
        ParticleInstancer.instance.Instace_AsteroidTINYDestruction(this.transform.position);
    }

    public void ApplyForce(Vector3 direction)
    {

    }

    public override void OnDeath()
    {
        ParticleInstancer.instance.Instace_AsteroidDestruction(this.transform.position);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        //transform.position += transform.forward + dir * speed * Time.deltaTime;
        transform.Rotate(rotation * 0.1f);
    }
}
