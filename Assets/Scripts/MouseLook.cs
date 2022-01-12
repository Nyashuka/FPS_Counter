using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSentitivity = 100f;
    [SerializeField] private Transform _playerTransform;
    private float xRotation = 0;

    private void Start()
    {
        transform.Rotate(0,0,0);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSentitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSentitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _playerTransform.Rotate(Vector3.up * mouseX);
    }
}
