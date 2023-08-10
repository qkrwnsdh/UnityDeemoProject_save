using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickSettingRight : MonoBehaviour
{
    // �ڵ��� ��ǥ�� �ʱ�ȭ �����ֱ� ���� ����
    public GameObject scrollHandleObject;

    // �ڵ��� ��ġ�� �������� ���� ����
    public ScrollHandle scrollHandle;

    // ��Ȱ��ȭ ��Ű�� ���� �Լ�
    public GameObject left;
    public GameObject center;

    // �ݶ��̴� ���� ����
    private Collider2D collider;

    // ���� ����
    public TMP_Text keyText;

    // ��ư�� ������ �ִ��� Ȯ��
    private bool isPressed = false;

    // ���� �Ǿ����� Ȯ��
    public bool isCheck = false;

    private void Awake()
    {
        GetComponent<CanvasGroup>().alpha = 0.0f;
        GetComponent<OpacityObject>().enabled = false;
        isCheck = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 0.0f;
        GetComponent<OpacityObject>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheck == true)
        {
            keyText.text = string.Format("{0:F1}", scrollHandle.xPos / 2.0f + 1.0f);

            GameManager.instance.Key((scrollHandle.xPos * 0.5f) + 1.0f);
        }
    }

    private void OnMouseDown()
    {
        if (GetComponent<OpacityObject>().enabled == false)
        {
            isPressed = true;
        }
    }

    private void OnMouseUp()
    {
        if (isPressed == true)
        {
            // ���콺 �������� ���� ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition.z = 0; // 2D ���������� z ��ǥ�� 0���� ����

            // ���콺 �������� �ݶ��̴� �ȿ� �ִ��� üũ
            if (collider.OverlapPoint(mousePosition) == true)
            {
                GameManager.instance.HandleCoroutine(true); 
                
                scrollHandleObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(((GameManager.instance.key - 1.0f) * 100.0f) - 400.0f, scrollHandleObject.GetComponent<RectTransform>().anchoredPosition.y);

                left.GetComponent<OpacityObject>().enabled = false;
                left.GetComponent<OnClickSettingLeft>().isCheck = false;
                left.GetComponent<CanvasGroup>().alpha = 0.0f;

                center.GetComponent<OpacityObject>().enabled = false;
                center.GetComponent<OnClickSettingCenter>().isCheck = false;
                center.GetComponent<CanvasGroup>().alpha = 0.0f;

                GetComponent<CanvasGroup>().alpha = 0.0f;
                GetComponent<OpacityObject>().enabled = true;
                isCheck = true;
            }

            isPressed = false;
        }
    }
}
