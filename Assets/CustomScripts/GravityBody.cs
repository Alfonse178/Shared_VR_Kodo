using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;
    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
            //dont think this is needed.
    }

    private void Update()
    {
        //need to fix this
        //planet.Attract(rb);
    }
}
