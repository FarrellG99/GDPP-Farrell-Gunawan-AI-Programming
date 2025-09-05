using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movementDirection =  new Vector3(horizontal, 0, vertical);
        _rigidbody.linearVelocity  =   movementDirection * (speed * Time.fixedDeltaTime);
    }
}