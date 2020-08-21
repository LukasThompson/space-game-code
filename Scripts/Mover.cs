using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}
