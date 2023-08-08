using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public Vector2 sizeMin = Vector2.zero;      // �ּ� ũ��
    public Vector2 sizeMax = Vector2.zero;      // �ִ� ũ��
    public float duration = 1.0f;               // �ɸ��� �ð�

    private float timeElapsed = 0.0f;

    private bool isScaling = true;

    //private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        //rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ð� ����� ���� ������ �� ����
        timeElapsed += Time.deltaTime;

        // Lerp ���� 0 ~ 1 ���̷� ��ȯ
        float time = Mathf.Clamp01(timeElapsed / duration);

        // ������ ���� ����Ͽ� ������ ���� ����
        Vector2 newSize = Vector2.Lerp(sizeMin, sizeMax, time);
        transform.localScale = newSize;
        //rectTransform.sizeDelta = newSize;

        // ũ�� ��ȭ �ݺ�
        if (1.0f <= time)
        {
            isScaling = !isScaling;
            timeElapsed = 0.0f;
        }       // if: ũ�Ⱑ �ִ�� Ŀ���� �� ������ �ٲ㼭 �ݺ�
    }
}
