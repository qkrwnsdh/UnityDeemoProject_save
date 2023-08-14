using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityObjectOne : MonoBehaviour
{
    public GameObject targetObject;

    private CanvasGroup canvasGroup;

    public float duration = 0.0f;

    public float alphaStart, alphaEnd;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        StartCoroutine(Opacity());
    }

    private IEnumerator Opacity()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ���İ� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����ؼ� moveStart���� moveEnd�� �̵�
            canvasGroup.alpha = Mathf.Lerp(alphaStart, alphaEnd, time);

            yield return null;
        }

        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
