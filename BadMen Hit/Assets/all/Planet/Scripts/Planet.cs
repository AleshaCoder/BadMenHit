using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Vector3 Position { get; private set; }
    public float Radius { get; private set; }

    private void Start()
    {
        Position = transform.position;
        Radius = transform.localScale.y*6;
    }
}
