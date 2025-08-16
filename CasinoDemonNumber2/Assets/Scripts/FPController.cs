using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPController : MonoBehaviour
{
    [SerializeField] Transform View = null;
    [SerializeField] float smoothness = 4f;
    float cameraRotation = 0f;
    CharacterController controls = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        UpdatecameraRotation();
    }
    void UpdatecameraRotation() { //camera
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraRotation -= mouseDelta.y * smoothness;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseDelta.x);
    }
    void movements() { //movement
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 velocity = (transform.forward * input.y + transform.right * input.x);
        controls.Move(Time.deltaTime * velocity);
    }
}
