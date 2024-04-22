using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private float timeElapsed;
    [SerializeField] private float duration;
    [SerializeField] private AsyncOperation op;


    private void Awake()
    { 
        GameManager.Instance.SetPlayerView(this);
    }



    public void TranslateViewPitch()
    {
        op = SceneManager.LoadSceneAsync(2);
        op.allowSceneActivation = false;
        StartCoroutine(ViewRoutine());
    }


    private IEnumerator ViewRoutine()
    {
        while (timeElapsed < duration)
        {
            canvas.alpha = Mathf.Lerp(0, 1,timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        op.allowSceneActivation = true;
    }
}
