using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInstancer : MonoBehaviour
{
    public static ParticleInstancer instance;
    private void Awake()
    {
        instance = this;
    }

    public ParticleSystem model_Asteroid_Destruction;
    public ParticleSystem model_Asteroid_Tiny_Destruction;
    public ParticleSystem sparks;
    public ParticleSystem nitropart;

    public void Instace_AsteroidDestruction(Vector3 position)
    {
        var part = GameObject.Instantiate(model_Asteroid_Destruction,position, Quaternion.identity);
        part.Play();
    }
    public void Instace_AsteroidTINYDestruction(Vector3 position)
    {
        var part = GameObject.Instantiate(model_Asteroid_Tiny_Destruction, position, Quaternion.identity);
        part.Play();
    }
    public void Instace_Sparks(Vector3 position)
    {
        var part = GameObject.Instantiate(sparks, position, Quaternion.identity);
        part.Play();
    }
    public void Instace_Nitro(Vector3 position)
    {
        var part = GameObject.Instantiate(nitropart, position, Quaternion.identity);
        part.Play();
    }
}
