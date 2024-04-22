using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController cc;
    [Range(0f , 30f)]
    [SerializeField] private float moveSpeed, rotateSpeed;
    [SerializeField] private Transform orientation;
    [SerializeField] private float groundRayLen;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Vector3 gravDir;
    [SerializeField]private bool isgrounded;
    private float YRotation = 0f;
    public bool canMove;
    void Start()
    {
        canMove = true;
        cc = this.GetComponent<CharacterController>();
        orientation = this.transform.Find("orientation").GetComponent<Transform>();
        gravDir = Vector3.down;
    }

    
    void Update()
    {
        if (orientation == null)
        {
            Debug.LogWarning("No orientation allocated for rotation");
            return;
        }
        try
        {
            orientation.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            GroundCheck();
            ApplyGravity();
            if (canMove)
            {
                OnMove();
                OnRotate();
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }

    }

    private void ApplyGravity()
    {   

        if (isgrounded)
        {
            gravDir.y = -1;
        }
        else 
        {   
            gravDir.y += Physics.gravity.y/1.5f * Time.deltaTime;
        }

        cc.Move(gravDir * Time.deltaTime);
    }

    private Vector3 GetDirection()
    {


        return (orientation.forward * InputService.Instance.LeftController.jStick.y + orientation.right * InputService.Instance.LeftController.jStick.x).normalized;
    }

    private void OnMove()
    {
        cc.Move(GetDirection() * moveSpeed * Time.deltaTime);
    }

    private void OnRotate()
    {
        YRotation += InputService.Instance.RightController.jStick.x * rotateSpeed * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x, YRotation, this.transform.eulerAngles.z);
    }
    private void GroundCheck()
    {
        Debug.DrawRay(orientation.position, Vector3.down * groundRayLen, Color.red);
        isgrounded = Physics.Raycast(orientation.position, Vector3.down, groundRayLen, groundLayerMask);
    }

    


}
