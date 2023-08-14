using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject targetObject;

    private RectTransform rectTransform;

    public float duration = 0.0f;

    public float moveStart, moveEnd;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    { 
        StartCoroutine(Move());
    }
    
    private IEnumerator Move()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ���İ� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����ؼ� moveStart���� moveEnd�� �̵�
            rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(moveStart, moveEnd, time),rectTransform.anchoredPosition.y);

            yield return null;
        }

        targetObject.SetActive(true);
    }
}
