using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEffectSetting : MonoBehaviour
{
    // ���� ���� �ڷ�ƾ �����ϱ�
    private Coroutine startOverScale;
    private Coroutine startOrignalScale;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(Camera)
    public Camera mainCamera;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(LayerMask)
    public LayerMask targetLayer;

    // �̹��� ũ�� ������ ���� ����
    private Vector2 orignalScale;
    private Vector2 pressedScale;
    private Vector2 overScale;

    // ũ�� ������ �ε巴�� �ϱ� ���� ����
    private float durationFirst = 0.2f;
    private float durationSecound = 0.1f;

    // ��ư�� ������ �ִ��� Ȯ��
    private bool isPressed = false;

    // ���콺 �����Ͱ� ������Ʈ �ȿ� �ִ��� Ȯ��
    private bool isPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        // �̹��� ũ�� ����
        orignalScale = transform.localScale;
        pressedScale = orignalScale * 0.9f;
        overScale = orignalScale * 1.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {
            transform.localScale = pressedScale;
        }
    }

    private void OnMouseDown()
    {
        // �ڷ�ƾ�� �����ϰ� ���ο� �ڷ�ƾ�� ����
        if (startOverScale != null) { StopCoroutine(startOverScale); }
        if (startOrignalScale != null) { StopCoroutine(startOrignalScale); }

        isPressed = true;
    }

    private void OnMouseUp()
    {
        if (isPoint == true)
        {
            startOverScale = StartCoroutine(StartOverScale());

            // ***********************************
            // Ŭ�������� �̺�Ʈ �ۼ�
            // ***********************************

            isPressed = false;
        }
    }

    private void OnMouseDrag()
    {
        // ���콺 ������ ��ġ�� ī�޶� ��ũ�� ��ǥ�� ��ȯ
        Vector3 mousePosition = Input.mousePosition;

        // ī�޶� ��ũ�� ��ǥ�� ���̷� ��ȯ
        Vector2 rayOrigin = mainCamera.ScreenToWorldPoint(mousePosition);

        // ����ĳ��Ʈ�� 2D ������Ʈ���� �浹 �˻�
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 0f, targetLayer);

        if (hit.collider != null)
        {
            isPoint = true;
        }
        else
        {
            StartCoroutine(StartOverScale());

            isPressed = false;
            isPoint = false;
        }
    }

    private IEnumerator StartOverScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationFirst)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationFirst);

            // ������ ���� ����Ͽ� ������ ���� ����
            transform.localScale = Vector2.Lerp(pressedScale, overScale, time);

            yield return null;
        }

        startOrignalScale = StartCoroutine(StartOrignalScale());
    }

    private IEnumerator StartOrignalScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationSecound)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationSecound);

            // ������ ���� ����Ͽ� ������ ���� ����
            transform.localScale = Vector2.Lerp(overScale, orignalScale, time);

            yield return null;
        }
    }
}
