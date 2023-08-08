using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBeam : MonoBehaviour
{
    // 속도값을 가져오기 위한 다른 스크립트
    private OnClickEffectBackground onClickEffectBackground;

    // 오브젝트 RectTransform 를 불러오기 위한 변수
    private RectTransform rectTransform;

    // 드래그 속도
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
