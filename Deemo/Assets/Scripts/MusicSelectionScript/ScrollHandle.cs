using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollHandle : MonoBehaviour
{
    public OnClickSettingLeft OnClickSettingLeft;
    public OnClickSettingCenter OnClickSettingCenter;
    public OnClickSettingRight OnClickSettingRight;

    public Coroutine coroutine = null;

    private RectTransform rectTransform;

    public float xPos;

    private float MaxPos = 400.0f;
    private float MinPos = -400.0f;

    private float duration = 1.0f;

    private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.coroutineCheck == true)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            GameManager.instance.HandleCoroutine(false);
        }

        if (isPressed == true)
        {
            // 1. ���콺 �������� ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            mousePosition.y = rectTransform.position.y;

            // 2. ���콺 �����Ϳ� Ÿ���� �Ÿ��� üũ�Ͽ� Ÿ�� �ȿ� �ִ��� Ȯ��
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);

            rectTransform.position = new Vector2(Mathf.Clamp(hit.point.x, -5.5f, 5.5f), hit.point.y);
        }

        xPos = (int)(rectTransform.anchoredPosition.x + 400 + 25) / 50;
    }

    private void OnMouseDown()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        isPressed = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;

        //����� ����
        int nodeCount = 16;

        //��� ���� �Ÿ�
        float rectNodeDistance = (MaxPos - MinPos) / nodeCount;

        //����� �ε���
        //Debug.Log((int)((rectTransform.anchoredPosition.x + 400 + 25) / 50));

        //���� anchoredPosition.x
        //Debug.Log(((int)((rectTransform.anchoredPosition.x + 400 + (rectNodeDistance / 2)) / rectNodeDistance) - 400 / rectNodeDistance) * rectNodeDistance);
        //                *            ������ ����                 *  *  ��尣�� �Ÿ� �ݰ�   *  
        //�ڷ�ƾ ����
        coroutine = StartCoroutine(StartScroll(((int)((rectTransform.anchoredPosition.x + 425) / 50) - 8) * 50));
    }

    private IEnumerator StartScroll(float XPos)
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����Ͽ� ������ ���� ����
            rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(rectTransform.anchoredPosition.x, XPos, time), rectTransform.anchoredPosition.y);

            yield return null;
        }
    }
}
