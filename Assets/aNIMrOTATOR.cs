using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aNIMrOTATOR : MonoBehaviour
{
    public float speed = 50;
    bool anim;
    public void Activ(bool anim)
    {
        this.anim = anim;
    }
    void Update()
    {
        if (anim)
        {
            this.transform.Rotate(0, speed, 0);
        }
    }
}
