using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollTitle : MonoBehaviour
{
    // �ӵ����� �������� ���� �ٸ� ��ũ��Ʈ
    private OnClickEffectBackground onClickEffectBackground;

    // ������Ʈ canvasGroup�� �����ϱ� ���� ����
    private CanvasGroup canvasGroup;

    // ������Ʈ RectTransform �� �ҷ����� ���� ����
    private RectTransform rectTransform;

    // ���� �߽� ��ǥ
    public Vector2 centerPos = Vector2.zero;

    // ���� ������
    private float radius = 5.0f;

    // ����������� ���������� ��ǥ(x)
    private float minDistance = 2.0f;

    // ����������� ������������ ��ǥ(x)
    private float maxDistance;

    // �巡�� �ӵ�
    public float velocity;

    // alphaXpos �� ������ġ x ������ �Ÿ��� �����ϱ� ���� ����
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        onClickEffectBackground = GameObject.Find("Background").GetComponent<OnClickEffectBackground>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        maxDistance = centerPos.x + (radius * 1.5f * Mathf.Cos(velocity * Mathf.Deg2Rad));  
    }

    // Update is called once per frame
    void Update()
    {
        velocity = onClickEffectBackground.currentVelocity * 0.05f;

        transform.position = centerPos + new Vector2(radius * 1.5f * Mathf.Cos(velocity * Mathf.Deg2Rad), radius * Mathf.Sin(velocity * Mathf.Deg2Rad));

        distance = Vector2.Distance(new Vector2(maxDistance, 0), new Vector2(centerPos.x + (radius * 1.5f * Mathf.Cos(velocity * Mathf.Deg2Rad)), 0));

        canvasGroup.alpha = 1.0f - Mathf.Clamp01(distance*2 / Mathf.Abs(maxDistance));

    }
}
