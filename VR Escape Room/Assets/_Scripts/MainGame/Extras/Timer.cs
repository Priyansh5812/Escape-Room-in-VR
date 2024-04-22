using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI _timertext;
    [SerializeField] private LockInteractable _lock;
    [SerializeField]private int mins;
    [SerializeField] private int secs;
    [SerializeField] private Coroutine routine;
    private void Start()
    {
        _timertext = this.GetComponentInChildren<TextMeshProUGUI>();
        secs = 0;
        routine = StartCoroutine(TimeRoutine());
        
    }

    private void Update()
    {
        if (!_lock.isLocked)
        {
            _timertext.text = "SOLVED!";
            _timertext.color = Color.green;
            if (routine != null)
            {
                StopCoroutine(routine);
                routine = null;
            }
            return;
        }
        _timertext.text = ((mins < 10) ? ("0" + mins.ToString()) : (mins.ToString())) + " : " +( (secs < 10) ? ("0" + secs.ToString()) : (secs.ToString()));
    }

    private IEnumerator TimeRoutine()
    {
        while (mins != 0 || secs != 0)
        {
            yield return new WaitForSeconds(1);
            if (secs == 0)
            {
                mins--;
                secs = 59;
            }
            else 
            {
                secs--;
            }     
        }
        _timertext.text = "Game Over";
        GameManager.Instance.SetGameOver(true);
        GameManager.Instance.GetInputActionManager().DisableInput();
        GameManager.Instance.GetInputService().ResetInputs();

    }


}
