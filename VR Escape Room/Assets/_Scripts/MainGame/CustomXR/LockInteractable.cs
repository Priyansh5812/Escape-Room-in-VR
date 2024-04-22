using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public enum BtnType
{ 
    NumUp,
    NumDown,
    ColorUp,
    ColorDown
}

public class LockInteractable : MonoBehaviour
{
    [SerializeField] private int num;
    [SerializeField] private TextMeshProUGUI numText;
    [SerializeField] private List<Color> colors;
    [SerializeField] private int colorInd;
    [SerializeField] private Renderer DoorSignal;
    [SerializeField] private Renderer ColorFace;
    [SerializeField] public bool isLocked;
    [SerializeField] public bool isKeyUsed;
    [SerializeField] private DoorInteractable _doorRef;
    private void Start()
    {
        colors = new List<Color>
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow
        };

        num = Random.Range(0, 10);
        colorInd = Random.Range(0, 4);
        isLocked = true;
        isKeyUsed = false;
    }

    private void Update()
    {   
        UpdateLockParams();
        CheckForValidCom();
    }

    public void ProcessInteractableInput(BtnType args)
    {
        switch (args)
        {
            case BtnType.ColorUp:
                OnColorUpPressed();
                break;
            case BtnType.ColorDown:
                OnColorDownPressed();
                break;
            case BtnType.NumUp:
                OnNumUpPressed();
                break;
            case BtnType.NumDown:
                OnNumDownPressed();
                break;
            default:
                Debug.LogWarning("Invalid Lock Interactable Input, Check <color = red>"+ args + "</color>");
                break;
        }
    }


    private void OnNumUpPressed() => num = (num+1) % 10;

    private void OnNumDownPressed() => num = (num == 0) ? (num = 9) : (num-1);

    private void OnColorUpPressed() => colorInd = (colorInd+1) % colors.Count;

    private void OnColorDownPressed() => colorInd = (colorInd == 0) ? (colorInd = (colors.Count - 1)) : (colorInd-1);


    private void UpdateLockParams()
    { 
        numText.text = num.ToString();
        ColorFace.material.SetColor("_EmissionColor", colors[colorInd]);
    }

    private void CheckForValidCom()
    {
        if (!isLocked)
        {
            return;
        }

        if (colors[colorInd] == Color.red && num == 4 && isKeyUsed)
        {
            isLocked = false;
            DoorSignal.material.SetColor("_EmissionColor", Color.green);
            _doorRef.canOpenDoor = true;
            GameManager.Instance.GetAudioService().PlaySound("Door");
        }
    }

}
