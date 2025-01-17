using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speedMove = 10.0f;
    [SerializeField] private float rotationSmoothness = 5.0f;
    [SerializeField] private float velocityThreshold = 0.1f;
    [SerializeField] private Vector3 lookAtOffset = new Vector3(0, 2, 0);

    public Transform cameraPointRear, cameraPointFront, lookAt;
    public Rigidbody carRigidbody;

    private Transform currentTargetPoint;

    private void Start()
    {
        currentTargetPoint = cameraPointRear;
    }

    private void FixedUpdate()
    {
        UpdateCameraDirection();
    }

    private void UpdateCameraDirection()
    {
        //Car speed
        Vector3 velocity = carRigidbody.velocity;
        float speed = velocity.magnitude;

        //Check is moveing?
        if (speed > velocityThreshold)
        {
            //Back or forward
            bool isReversing = Vector3.Dot(carRigidbody.transform.forward, velocity) < 0;

            //Change camera point
            currentTargetPoint = isReversing ? cameraPointFront : cameraPointRear;
        }

        //Follow car
        transform.position = Vector3.Lerp(transform.position, currentTargetPoint.position, speedMove * Time.deltaTime);

        //LookAt rot
        Vector3 offsetPosition = lookAt.TransformPoint(lookAtOffset);
        Quaternion targetRotation = Quaternion.LookRotation(offsetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
    }
}