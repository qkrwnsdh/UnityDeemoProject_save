using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public Vector2 initialPosition = Vector2.zero;      // ���� ����
    public Vector2 targetPosition = Vector2.zero;       // ��ǥ ����
    public float duration = 1.0f;                       // �ɸ��� �ð�

    private float timeElapsed = 0.0f;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ð� ����� ���� �Ÿ� �� ����
        timeElapsed += Time.deltaTime;

        // Lerp ���� 0 ~ 1 ���̷� ����
        float time = Mathf.Clamp01(timeElapsed / duration);

        // ������ ���� ����Ͽ� ������ ���� ����
        Vector2 newPos = Vector2.Lerp(initialPosition, targetPosition, time);
        rectTransform.anchoredPosition = newPos;
    }
}
