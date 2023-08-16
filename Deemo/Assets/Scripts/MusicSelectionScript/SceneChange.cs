using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public LoadScene loadScene;

    // ó�� Ŭ���� ���콺 ��ġ
    private Vector2 StartMousePosition;

    // ���� ���콺 ��ġ
    private Vector2 MoveMousePosition;

    private bool isPressed = false;
    private bool isPoint = false;

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

        isPressed = true;
    }

    private void OnMouseUp()
    {
        if (isPoint == true)
        {
            loadScene.Run(0.0f, "ResultScene");
        }

        isPressed = false;
    }
}
