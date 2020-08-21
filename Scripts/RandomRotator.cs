using UnityEngine;
using System.Collections;
using System;

public class RandomRotator : MonoBehaviour
{
    public float minRotation;
    public float maxRotation;
    private float tumble;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tumble = UnityEngine.Random.Range(minRotation, maxRotation);
    }

    void Start()
    {
        rb.angularVelocity = UnityEngine.Random.insideUnitSphere * tumble;
    }
}
