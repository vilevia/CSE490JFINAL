using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add this component to objects that should be detected by shooting gallery targets 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
