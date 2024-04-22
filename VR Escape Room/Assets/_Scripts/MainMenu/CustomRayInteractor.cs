using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class CustomRayInteractor : XRRayInteractor
{
    [SerializeField] private float lineWidth;
    protected override void Start()
    {
        
        lineWidth = this.GetComponent<XRInteractorLineVisual>().lineWidth;
    }

    public override void ProcessInteractor(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {

        if (IsOverUIGameObject())
        {
            
            this.GetComponent<XRInteractorLineVisual>().lineWidth = lineWidth;
        }
        else 
        {
           
            this.GetComponent<XRInteractorLineVisual>().lineWidth = 0f;
        }

        base.ProcessInteractor(updatePhase);
    }


}
