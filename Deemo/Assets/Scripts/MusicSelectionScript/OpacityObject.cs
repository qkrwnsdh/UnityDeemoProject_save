using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityObject : MonoBehaviour
{
    // ����â�� ��� �������� �ڷ�ƾ�� ���߰� �ϱ� ���� ����
    public OnClickSettingBackground onClickSettingBackground;

    // ������Ʈ canvasGroup�� �����ϱ� ���� ����
    private CanvasGroup canvasGroup;

    // ���İ��� �ε巴�� �ϱ� ���� ����
    private float duration = 1.0f;

    // �ð��� ������ ����
    private float timeElapsed;

    // Alpha�� �ִ�, �ּ� ��
    public float maxAlpha;
    public float minAlpha;

    // ȣ���� �������� Ȯ��
    private bool isEnable = false;

    // �ڷ�ƾ ������ �Ϸ� �Ǿ����� Ȯ��
    private bool isCheck = false;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        isEnable = onClickSettingBackground.isEnable;

        // �ð��� �ʱ�ȭ
        timeElapsed = 0.0f;

        // ���İ� �ʱ�ȭ
        canvasGroup.alpha = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnable == true)
        {
            if (isCheck == false)
            {
                // �ð� ����� ���� ���İ� ����
                timeElapsed += Time.deltaTime;

                // Lerp ���� 0 ~ 1 ���̷� ��ȯ
                float time = Mathf.Clamp01(timeElapsed / duration);

                // ������ ���� ����ؼ� ���İ��� ����
                canvasGroup.alpha = Mathf.Lerp(maxAlpha, minAlpha, time);

                if (time >= 1.0f)
                {
                    isCheck = true;

                    timeElapsed = 0.0f;
                }
            }
            else
            {
                timeElapsed += Time.deltaTime;

                float time = Mathf.Clamp01(timeElapsed / duration);

                canvasGroup.alpha = Mathf.Lerp(minAlpha, maxAlpha, time);

                if (time >= 1.0f)
                {
                    isCheck = false;
                    timeElapsed = 0.0f;
                }
            }
        }
    }

    private IEnumerator StartFade()
    {
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

    }
}
