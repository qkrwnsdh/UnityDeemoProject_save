using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjectLoop : MonoBehaviour
{
    private RectTransform rectTransform;

    public Vector2 scaleStart = Vector2.zero;
    public Vector2 scaleEnd = Vector2.zero;

    public float duration = 0.0f;

    // �ڷ�ƾ ������ �Ϸ� �Ǿ����� Ȯ��
    private bool isCheck = false;

    // �ð��� ������ ����
    private float timeElapsed;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        // �ð��� �ʱ�ȭ
        timeElapsed = 0.0f;
    }

    private void Update()
    {
        if (isCheck == false)
        {
            timeElapsed += Time.deltaTime;

            float time = Mathf.Clamp01(timeElapsed / duration);

            rectTransform.localScale = new Vector2(
                Mathf.Lerp(scaleEnd.x, scaleStart.x, time),
                Mathf.Lerp(scaleEnd.y, scaleStart.y, time)
                );

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

            rectTransform.localScale = new Vector2(
                Mathf.Lerp(scaleStart.x, scaleEnd.x, time),
                Mathf.Lerp(scaleStart.y, scaleEnd.y, time)
                );

            if (time >= 1.0f)
            {
                isCheck = false;

                timeElapsed = 0.0f;
            }
        }
    }
}
