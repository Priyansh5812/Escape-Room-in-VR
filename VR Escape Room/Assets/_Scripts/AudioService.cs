using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private AudioSource src;
    [SerializeField]private AudioClip 
    clueSelected, ballSelected, batSelected, 
    bookSelected, switchFlicked, canSelected, 
    LockBtnPushed, DoorUnlock, lockedDoor, unlockDoor,KeyUsed;
    private bool canPlay;
    void Awake()
    {
        canPlay = false;
        //src = this.GetComponent<AudioSource>();
        //Initializing the Manager
        GameManager.Instance.SetAudioService(this);
    }

    // Update is called once per frame

    public void PlaySound(string type)
    {

        AudioClip clip = null;
        switch (type)
        {
            case "Clue":
                clip = clueSelected;
                break;
            case "Ball":
                clip = ballSelected;
                break;
            case "Bat":
                clip = batSelected;
                break;
            case "Book":
                clip = bookSelected;
                break;
            case "Switch":
                clip = switchFlicked;
                break;
            case "Can":
                clip = canSelected;
                break;
            case "Lock":
                clip = LockBtnPushed;
                break;
            case "Door":
                clip = DoorUnlock;
                break;
            case "UnlockDoor":
                clip = unlockDoor;
                break;
            case "LockedDoor":
                clip = lockedDoor;
                break;
            case "Key":
                clip = KeyUsed;
                break;
            default:
                Debug.Log("Illegal Parameter passing, Check: " + type);
                return;
        }
        src.PlayOneShot(clip);
    }

}
