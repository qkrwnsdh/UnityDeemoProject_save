using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHandle : MonoBehaviour
{
    private RectTransform rectTransform;

    Vector3 targetLocalPosition = Vector3.zero;

    private float MaxPos = 400.0f;
    private float MinPos = -400.0f;

    private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {


            //rectTransform.localPosition = new Vector3()
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
    }
}
