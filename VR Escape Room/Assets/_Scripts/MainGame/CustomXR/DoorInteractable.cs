using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorInteractable : XRGrabInteractable
{
    public bool canOpenDoor;

    private void Start()
    {
        canOpenDoor = false;   
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!canOpenDoor)
        {
            return;
        }

        if (Mathf.Floor(this.transform.eulerAngles.y) == 90)
        {
            GameManager.Instance.GetAudioService().PlaySound("UnlockDoor");
        }

        base.OnSelectEntered(args);
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        if (!canOpenDoor)
        {
            GameManager.Instance.GetAudioService().PlaySound("LockedDoor");
            return false;
        }

        return base.IsSelectableBy(interactor);
    }


}
