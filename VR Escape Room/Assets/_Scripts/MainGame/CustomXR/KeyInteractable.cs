using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class KeyInteractable : XRGrabInteractable
{
    public bool canInteractWithPlayer = true;

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        if (interactor is XRSocketInteractor)
        {
            canInteractWithPlayer = false;
        }

        if (interactor is XRDirectInteractor && !canInteractWithPlayer)
        {
            return false;
        }


        return base.IsSelectableBy(interactor);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
           
           GameManager.Instance.GetAudioService().PlaySound("Key");
            
        }
        base.OnSelectEntered(args);
    }
}

