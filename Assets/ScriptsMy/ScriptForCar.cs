using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForCar : MonoBehaviour
{
    [SerializeField] private Transform _transformFL;
    [SerializeField] private Transform _transformFR;
    [SerializeField] private Transform _transformBL;
    [SerializeField] private Transform _transformBR;

    [SerializeField] private WheelCollider _colliderFL;
    [SerializeField] private WheelCollider _colliderFR;
    [SerializeField] private WheelCollider _colliderBL;
    [SerializeField] private WheelCollider _colliderBR;

    [SerializeField] private float _maxForce = 100f;
    [SerializeField] private float _accelerationTime = 2.0f;

    private float _currentTorque = 0f;
    public bool _isMoving = true;

    private void Start()
    {
        _currentTorque = 0f;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _currentTorque = Mathf.Lerp(_currentTorque, _maxForce, Time.fixedDeltaTime / _accelerationTime);

            _colliderFL.motorTorque = _currentTorque;
            _colliderFR.motorTorque = _currentTorque;
        }
        else
        {
            _colliderFL.motorTorque = 0f;
            _colliderFR.motorTorque = 0f;
        }

        RotateWheel(_colliderFL, _transformFL);
        RotateWheel(_colliderFR, _transformFR);
        RotateWheel(_colliderBL, _transformBL);
        RotateWheel(_colliderBR, _transformBR);
    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }
}
