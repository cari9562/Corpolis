using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField] private bool _nonInteractableOnFadeOut = true;
    [SerializeField] private bool _isFadeOutStart = true;

    private CanvasGroup _canvasGroup;
    private bool _isFadeStart = false;
    private float _timeSpent = 0f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_isFadeOutStart)
        {
            FadeOut(3);
        }
    }

    public void FadeIn(float duration)
    {
        _isFadeStart = true;
        _timeSpent = 0f;
        StopAllCoroutines();
        StartCoroutine(FadeWithDuration(duration, true));
    }

    public void FadeOut(float duration)
    {
        _isFadeStart = true;
        _timeSpent = 0f;
        StopAllCoroutines();
        StartCoroutine(FadeWithDuration(duration, false));
    }

    private IEnumerator FadeWithDuration(float duration, bool isFadeIn)
    {
        if (!_isFadeStart) yield break;

        if (_nonInteractableOnFadeOut)
        {
            if (isFadeIn)
            {
                _canvasGroup.interactable = true;
            }
            else
            {
                _canvasGroup.interactable = false;
            }
        }

        while (_timeSpent < duration)
        {
            _timeSpent += Time.deltaTime;
            // fade in
            if (isFadeIn)
            {
                if (_canvasGroup.alpha >= 1) yield break;

                _canvasGroup.alpha += Time.deltaTime;
            }

            // fade out
            if (!isFadeIn)
            {
                if (_canvasGroup.alpha <= 0) yield break;
                _canvasGroup.alpha -= Time.deltaTime;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }

        _isFadeStart = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FadeIn(1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            FadeOut(1);
        }
    }
}
