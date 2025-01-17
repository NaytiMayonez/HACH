using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPointMove : MonoBehaviour
{
    [SerializeField] private float _speedSmooth = 5.0f, _speedSmoothRotation = 5.0f;
    private float _positionY;
    private Vector3 _rotationPoint;

    public Transform cameraPoint;

    private void FixedUpdate()
    {
        MovementPoint();
        RotatePoint();
    }

    private void RotatePoint()
    {
        _rotationPoint.y = Mathf.Lerp(transform.eulerAngles.y, cameraPoint.eulerAngles.y, _speedSmoothRotation * Time.deltaTime);
        transform.rotation = Quaternion.Euler(_rotationPoint);
    }

    private void MovementPoint()
    {
        _positionY = Mathf.Lerp(transform.position.y, cameraPoint.position.y, _speedSmooth * Time.deltaTime);
        transform.position = new Vector3(cameraPoint.position.x, _positionY, cameraPoint.position.z);
    }
}
