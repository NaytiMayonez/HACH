using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCar;
    public GameObject needle;
    public float vehicleSpeed;

    private float _startPosition = 236.0f, _endPosition = -33.0f, _desiredPosition, _temp;
    private CarMovement _speed;

    private void Start()
    {
        _speed = mainCar.GetComponent<CarMovement>();
    }

    private void FixedUpdate()
    {
        vehicleSpeed = _speed.speedVehicle;
        UpdateNeedle();
    }

    private void UpdateNeedle()
    {
        _desiredPosition = _startPosition - _endPosition;
        _temp = vehicleSpeed / 260;
        needle.transform.eulerAngles = new Vector3(0, 0, _startPosition - _temp * _desiredPosition);
    }
}
