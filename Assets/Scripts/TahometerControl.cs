using System.Collections;
using System.Collections.Generic;
using VehiclePhysics;
using UnityEngine;

public class TahometerControl : MonoBehaviour
{
    public VPVehicleController vehicleController;
    public GameObject needle;
    [HideInInspector] public float engineRpm;

    private float _startPosition = 0f, _endPosition = -260f, _temp, _desiredPosition;

    private void Update()
    {
        if (vehicleController != null)
        {
            engineRpm = vehicleController.data.Get(Channel.Vehicle, VehicleData.EngineRpm) / 1000.0f;
            UpdateNeedle();
        }
    }

    private void UpdateNeedle()
    {
        _desiredPosition = _startPosition - _endPosition;
        _temp = engineRpm / 8000f;
        needle.transform.eulerAngles = new Vector3(0, 0, _startPosition - _temp * _desiredPosition);
    }
}