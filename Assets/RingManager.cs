using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public static RingManager instance;

    public Ring currentRing;
    public void SetRing(Ring ring) => currentRing = ring;

    public void Awake()
    {
        instance = this;
    }
}
