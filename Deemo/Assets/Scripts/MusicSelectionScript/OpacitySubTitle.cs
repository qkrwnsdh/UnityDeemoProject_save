using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacitySubTitle : MonoBehaviour
{
    // ������Ʈ canvasGroup�� �����ϱ� ���� ����
    private CanvasGroup canvasGroup;

    // ������Ʈ RectTransform �� �ҷ����� ���� ����
    private RectTransform rectTransform;

    // ����������� ���������� ��ǥ(y)
    private float alphaDistance = 280.0f;

    // ���� ��ǥ(y)
    private float distance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = alphaDistance - Mathf.Abs(rectTransform.anchoredPosition.y);

        canvasGroup.alpha = Mathf.Clamp01(distance / alphaDistance);
    }
}
