using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SwitchInteractble : XRBaseInteractable
{
    [SerializeField] private bool allowLight;
    [SerializeField] private Light[] lights;
    [SerializeField] private Renderer emmisivemat;
    [SerializeField] private Color emColor;
    [SerializeField] private Transform _switch;


    private void Start()
    {
        foreach (var i in lights)
        {
            i.enabled = allowLight;
        }

        emmisivemat.material.SetColor("_EmissionColor", (!allowLight) ? (Color.black):(emColor * 3.5f));
    }


    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        
        ToggleLights();

    }

    

    private void ToggleLights()
    {
        PlaySwitchSound();
        foreach (var i in lights)
        { 
            i.enabled = !i.enabled;
        }
        if (!allowLight)
        {
            emmisivemat.material.SetColor("_EmissionColor", emColor * 3.5f);
            
        }
        else
        {
            emmisivemat.material.SetColor("_EmissionColor", Color.black);
        }
        SetSwitch();
        allowLight = !allowLight;
    }

    private void PlaySwitchSound()
    {
        GameManager.Instance.GetAudioService().PlaySound("Switch");
    }

    private void SetSwitch()
    { 
        _switch.rotation = Quaternion.Inverse(_switch.rotation);
    }
    
}
