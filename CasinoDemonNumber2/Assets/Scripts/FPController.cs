using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class FPController : MonoBehaviour
{
    [SerializeField] Transform View = null;
    [SerializeField] float smoothness = 4f;
    [SerializeField] float walkingSpeed = 1f;
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
        Updatemovements();
    }
    void UpdatecameraRotation() { //camera
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraRotation -= mouseDelta.y * smoothness;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseDelta.x);
        
    }
    void Updatemovements() { //movement
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 velocity = (transform.forward * input.y + transform.right * input.x)*walkingSpeed;
        controls.Move(Time.deltaTime * velocity);
    }
}
