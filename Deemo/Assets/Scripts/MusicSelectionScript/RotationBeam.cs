using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBeam : MonoBehaviour
{
    // �ӵ����� �������� ���� �ٸ� ��ũ��Ʈ
    private OnClickEffectBackground onClickEffectBackground;

    // ������Ʈ RectTransform �� �ҷ����� ���� ����
    private RectTransform rectTransform;

    // �巡�� �ӵ�
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        onClickEffectBackground = GameObject.Find("Background").GetComponent<OnClickEffectBackground>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = onClickEffectBackground.currentVelocity * 0.05f;

        rectTransform.localEulerAngles = new Vector3(0, 0, velocity * Mathf.Rad2Deg/32);

        
    }
}
