using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotationBeam : MonoBehaviour
{
    public RectTransform scrollContent;

    // ������Ʈ RectTransform �� �ҷ����� ���� ����
    private RectTransform rectTransform;

    private float radius = 300.0f;

    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = (scrollContent.anchoredPosition.y - scrollContent.childCount * 360.0f) / 720.0f * 15.0f;

        rectTransform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, radius * (15.0f - speed)* Mathf.Deg2Rad));
    }
}
