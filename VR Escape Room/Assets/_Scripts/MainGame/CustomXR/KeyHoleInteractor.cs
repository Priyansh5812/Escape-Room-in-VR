using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyHoleInteractor : XRSocketInteractor
{
    protected override bool StartSocketSnapping(XRGrabInteractable grabInteractable)
    {
        this.GetComponentInParent<LockInteractable>().isKeyUsed = true;
        GameManager.Instance.GetAudioService().PlaySound("Key");
        return base.StartSocketSnapping(grabInteractable);
    }

}
