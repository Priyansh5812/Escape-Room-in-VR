using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class MenuUIManager : MonoBehaviour
{
    public AsyncOperation op;
    public float duration;
    public float timeElapsed;
    public CanvasGroup grp;
    public InputActionManager actionManager;
    void Start()
    {
        op = null;
    }

    public void StartScene(int ind)
    {
        if (op != null)
        {
            return;
        }
        op = SceneManager.LoadSceneAsync(ind);
        op.allowSceneActivation = false;
    }

    public void StartTransition()
    {
        actionManager.DisableInput();
        StartCoroutine(SceneTranslate());
    }


    public void TriggerScene()
    { 
        op.allowSceneActivation = true;
        GameManager.Instance.SetGameOver(false);
    }

    private IEnumerator SceneTranslate()
    {
        while (timeElapsed < duration)
        {
            grp.alpha = Mathf.Lerp(0f, 1f, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        TriggerScene();
        yield return null;
    }

    public void QuitAppliction()
    { 
        Application.Quit();
    }


}
