using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class InputService : MonoBehaviour
{
    private static InputDevice leftDevice, rightDevice;
    private ControllerInfo leftController;
    private ControllerInfo rightController;
    [SerializeField] private InputActionManager _inputActionManager;


    
    public ControllerInfo LeftController
    {
        get
        {
            
            if (leftController == null)
            {
                leftController = new ControllerInfo();
            }
            return leftController;
        }
    }
    public ControllerInfo RightController
    {
        get
        {
            if (rightController == null)
            {
                rightController = new ControllerInfo();
            }
            return rightController;
        }
    }
    private static InputService instance;

    public static InputService Instance
    {

        get
        {

            return instance;

        }
    }

    private void Awake()
    {
        instance = this;
        GameManager.Instance.SetInputActionManager(_inputActionManager);
        GameManager.Instance.SetInputService(this);
    }

    private void Update()
    {
        if (!leftDevice.isValid || !rightDevice.isValid)
        {
            InitDevices();
        }

        if (GameManager.Instance.IsGameOver())
        {   
            
            return;
        }

        HandleLeftController();
        HandleRightController();
    }


    private static void InitDevices()
    {
        var lefthandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, lefthandDevices);
        if (lefthandDevices.Count > 0)
        {
            leftDevice = lefthandDevices[0];
        }


        var righthandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, righthandDevices);
        if (righthandDevices.Count > 0)
        {
            rightDevice = righthandDevices[0];
        }

    }

    private void HandleLeftController()
    {
        leftDevice.TryGetFeatureValue(CommonUsages.triggerButton, out LeftController.Trigger);
        leftDevice.TryGetFeatureValue(CommonUsages.gripButton, out LeftController.Grip);
        leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out LeftController.jStick);
        leftDevice.TryGetFeatureValue(CommonUsages.primaryButton, out LeftController.pBtn);
        leftDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out LeftController.sBtn);
    }
    private void HandleRightController()
    {
        rightDevice.TryGetFeatureValue(CommonUsages.triggerButton, out RightController.Trigger);
        rightDevice.TryGetFeatureValue(CommonUsages.gripButton, out RightController.Grip);
        rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out RightController.jStick);
        rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out RightController.pBtn);
        rightDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out RightController.sBtn);
    }

    public void ResetInputs()
    {
        LeftController.Trigger = LeftController.Grip = LeftController.pBtn = LeftController.sBtn = false;
        LeftController.jStick = Vector2.zero;
        RightController.Trigger = RightController.Grip = RightController.pBtn = RightController.sBtn = false;
        RightController.jStick = Vector2.zero;
    }

}
