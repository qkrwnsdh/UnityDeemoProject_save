using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScoreBar : MonoBehaviour
{
    private Image image;

    public float duration = 0.0f;

    public float moveStart, moveEnd;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ���İ� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����ؼ� moveStart���� moveEnd�� �̵�
            image.fillAmount = Mathf.Lerp(0.0f, 0.5f, time * time);

            yield return null;
        }

        StartCoroutine(MoveDown());
    }

    private IEnumerator MoveDown()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            float time = 1.0f - Mathf.Pow(1.0f - Mathf.Clamp01(timeElapsed / duration), 2);

            image.fillAmount = Mathf.Lerp(0.5f, 1.0f, time);

            yield return null;
        }
    }
}
