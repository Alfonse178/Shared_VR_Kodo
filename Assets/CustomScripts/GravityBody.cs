using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        rb.useGravity = false;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        
    }

    private void FixedUpdate()
    {
        planet.Attract(transform);
    }

    private void Update()
    {
        //planet.Attract(rb);
    }
}
