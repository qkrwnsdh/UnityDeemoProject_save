using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject activeObject;

    public GameObject targetObject;

    // ó�� Ŭ���� ���콺 ��ġ
    private Vector2 StartMousePosition;

    // ��ư Ŭ���� Ȯ��
    private bool isPoint = false;

    void Start()
    {
        targetObject.SetActive(true);
    }

    private void Update()
    {
        if (StartMousePosition != (Vector2)Input.mousePosition)
        {
            isPoint = false;
        }
    }

    private void OnMouseDown()
    {
        StartMousePosition = Input.mousePosition;

        isPoint = true;
    }

    private void OnMouseUp()
    {
        if (isPoint == true)
        {
            activeObject.SetActive(true);
            activeObject.SetActive(false);
            activeObject.SetActive(true);
        }
    }
}
