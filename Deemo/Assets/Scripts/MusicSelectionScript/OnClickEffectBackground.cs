using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OnClickEffectBackground : MonoBehaviour
{
    // ���� â�� Ȱ��ȭ �ǰ� �ϱ� ���� ����
    public GameObject settingUi;

    // �뷡 ������ ȣ��Ǵ� ��ġ
    public GameObject titleSave;

    // �뷡 ���� ������
    public GameObject title;

    // �뷡�� ������ ������ ����Ʈ
    List<GameObject> titleList = new List<GameObject>();

    // ���� �߽� ��ǥ
    public Vector2 centerPos = Vector2.zero;

    // ó�� Ŭ���� ���콺 ��ġ
    private Vector2 StartMousePosition;

    // ���� ���콺 ��ġ
    private Vector2 MoveMousePosition;

    // ���� �巡�� �ӵ�
    public float currentVelocity;

    // ���� ������
    private float radius = 5f;

    // ���� �������� �ð�
    private float lastFrameTime;

    // ��ư�� ������ �ִ��� Ȯ��
    private bool isPressed = false;

    // ��ư Ŭ���� Ȯ��
    private bool isPoint = false;

    // ó�� SettingUi ȣ�� üũ
    private bool isCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        settingUi.SetActive(false);

        //Instantiate(titleList[0], centerPos + new Vector2(radius* 1.5f * Mathf.Cos(0.0f * Mathf.Deg2Rad), radius * Mathf.Sin(0.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[1], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-12.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-12.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[2], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-24.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-24.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[3], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-36.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-36.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
        //Instantiate(titleList[4], centerPos + new Vector2(radius * 1.5f * Mathf.Cos(-48.0f * Mathf.Deg2Rad), radius * Mathf.Sin(-48.0f * Mathf.Deg2Rad)), Quaternion.identity, titleSave.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {
            MoveMousePosition = Input.mousePosition;

            currentVelocity = StartMousePosition.y - MoveMousePosition.y;
        }

        if (StartMousePosition != (Vector2)Input.mousePosition)
        {
            isPoint = false;
        }

        //Vector2 currentMousePosition = Input.mousePosition;
        //float currentTime = Time.time;

        //// ������ ���� �ð� ������ ���
        //float deltaTime = currentTime - lastFrameTime;

        //// ������ ���� ��ġ ��ȭ�� ���
        //Vector2 deltaPosition = currentMousePosition - lastMousePosition;

        //// ���Ʒ� �巡�� �ӵ� ���
        //currentVelocity = deltaPosition.y / deltaTime;

        //// ���� �ӵ��� Ȱ���Ͽ� ���ϴ� ���� ����
        //// ��: ������Ʈ �̵�, �Ķ���� ���� ��

        //// �̹� �������� ������ ���� �����ӿ� ����ϱ� ���� ����
        //lastMousePosition = currentMousePosition;
        //lastFrameTime = currentTime;

        //// ���Ʒ� �巡�� �ӵ��� ����� �α׷� ���
        //Debug.Log("Vertical Drag Speed: " + verticalVelocity);
    }

    private void OnMouseDown()
    {
        StartMousePosition = Input.mousePosition;

        isPoint = true;

        isPressed = true;
    }

    private void OnMouseUp()
    {
        if (isPoint == true)
        {
            if (isCheck == false)
            {
                settingUi.SetActive(true);
                settingUi.SetActive(false);
                settingUi.SetActive(true);

                isCheck = true;
            }
            else
            {
                settingUi.SetActive(true);
            }
        }

        isPressed = false;
    }

    //private IEnumerator Frame()
    //{
    //    settingUi.SetActive(true);

    //    yield return null;

    //    settingUi.SetActive(false);
    //    settingUi.SetActive(true);
    //}
}
