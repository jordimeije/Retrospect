﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircularGravity : MonoBehaviour
{

    public Transform target; // Big object
    public List<Transform> Targets;
    public int Current;
    Vector3 targetDirection;

    public int radius = 5;
    public int forceAmount = 100;
    public float gravity = 0;
    private Rigidbody rb;

    private float distance;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        targetDirection = target.position - transform.position; // Save direction
        distance = targetDirection.magnitude; // Find distance between this object and target object
        targetDirection = targetDirection.normalized; // Normalize target direction vector

        if (distance < radius)
        {
            rb.AddForce(targetDirection * forceAmount * Time.deltaTime);
        }
    }

    public void OnPickup()
    {
        Current += Random.Range(0, Targets.Count);//(Current + 1) % Targets.Count;
        target = Targets[Current];
    }
}