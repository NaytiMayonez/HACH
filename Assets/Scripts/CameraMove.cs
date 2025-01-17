using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _speedMove = 10.0f; 

    public Transform cameraPointRear, cameraPointFront, lookAt;

    private void FixedUpdate()
    {
        CameraDirection();
    }

    private void CameraDirection()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPointRear.position, _speedMove * Time.deltaTime);
        transform.LookAt(lookAt);
    }
}
