using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAndFade : MonoBehaviour
{
    // ���� ���������� �ϱ� ���� ����
    private CanvasGroup canvasGroup;

    // �̹��� ũ�� ������ ���� ����
    public Vector2 zeroScale = Vector2.zero;
    public Vector2 maxScale = Vector2.zero;

    // ���İ�, ũ�� ������ �ε巴�� �ϱ� ���� ����
    private float duration = 2.0f;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        // ���İ�, ũ�� �ʱ�ȭ
        canvasGroup.alpha = 1.0f;
        transform.localScale = zeroScale;

        StartCoroutine(StartMaxScale());
    }
    
    private IEnumerator StartMaxScale()
    {
        float timeElapsed = 0.0f;
        
        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ���İ�, ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����ؼ� ������ ��, ���� ���� ����
            transform.localScale = Vector2.Lerp(zeroScale, maxScale, time);
            canvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, time);

            yield return null;
        }
    }
}
