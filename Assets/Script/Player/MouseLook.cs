using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _playerBode;
    [SerializeField] private float _mouseSensetivity = 100f;
    [SerializeField] private float _xRotation = 0f;

    private Vector3 _directionVector => new Vector3(Input.GetAxis("Mouse X") * _mouseSensetivity, Input.GetAxis("Mouse Y") * _mouseSensetivity, 0);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _xRotation -= _directionVector.y * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBode.Rotate(Vector3.up * _directionVector.x * Time.deltaTime, Space.Self);
    }
}
