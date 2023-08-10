using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnClickSettingUi : MonoBehaviour
{
    public OnClickSettingBackground onClickSettingBackground;

    // �ڷ�ƾ�� �����ϱ� ���� ����
    private Coroutine startAlpha;
    private Coroutine stopAlpha;

    // ���� ������������ �ϱ� ���� ����
    private CanvasGroup canvasGroup;

    // ���İ��� �����ϱ� ���� ����
    private float duration = 0.5f;

    // �ڷ�ƾ�� ���������� Ȯ��
    public bool isCoroutine = false;

    // ȣ���� �������� Ȯ��
    public bool isEnable = false;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onClickSettingBackground.isCheck == true)
        {
            stopAlpha = StartCoroutine(StopAlpha());

            onClickSettingBackground.isCheck = false;
        }
    }

    private void OnEnable()
    {
        // ���İ� �ʱ�ȭ
        canvasGroup.alpha = 0.0f;

        // ȣ�� �Ǿ���
        isEnable = true;

        startAlpha = StartCoroutine(StartAlpha());
    }
    // Update is called once per frame

    private IEnumerator StartAlpha()
    {
        isCoroutine = true;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ���İ� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����ؼ� ���İ��� ����
            canvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, time);

            yield return null;
        }

        isCoroutine = false;
    }

    private IEnumerator StopAlpha()
    {
        isCoroutine = true;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ���İ� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����ؼ� ���İ��� ����
            canvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, time);

            yield return null;
        }

        isCoroutine = false;

        // ȣ���� ������
        isEnable = false;

        gameObject.SetActive(false);
    }
}
