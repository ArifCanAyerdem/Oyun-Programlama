using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    [Range(0, 1)] public float time;
    public float startTime;
    public float dayLength;                         //0 - 1 Arası artan float ile gece gunduz sistemi
    private float timeRate;                         //0 : gece 0.5 : oglen 1 : gece
    public Vector3 noon;

    private void Start()
    {
        timeRate = 1 / dayLength;
        time = startTime;
    }

    private void Update()
    {
        time += timeRate * Time.deltaTime;

        if (time >= 1)
            time = 0;

        transform.eulerAngles = noon * ((time - 0.25f) * 4);
    }
}