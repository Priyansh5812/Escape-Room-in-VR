using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockBtnInteractable : XRBaseInteractable
{
    [SerializeField] private BtnType _btnArgs;


    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {   
        base.OnHoverEntered(args);

        if (this.transform.GetComponentInParent<LockInteractable>().isLocked == false)
        {
            return;
        }

        GameManager.Instance.GetAudioService().PlaySound("Lock");
        this.transform.GetComponentInParent<LockInteractable>().ProcessInteractableInput(_btnArgs);
    }

}
