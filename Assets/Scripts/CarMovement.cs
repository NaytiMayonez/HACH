using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    [HideInInspector] public float speedVehicle;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _velocity = _rigidbody.velocity;
        speedVehicle = _velocity.magnitude * 3.6f;
    }
}
