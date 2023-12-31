using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickSettingLeft : MonoBehaviour
{
    // 핸들의 좌표를 초기화 시켜주기 위한 변수
    public GameObject scrollHandleObject;

    // 핸들의 위치를 가져오기 위한 변수
    public ScrollHandle scrollHandle;

    // 비활성화 시키기 위한 변수
    public GameObject center;
    public GameObject right;

    // 콜라이더 저장 공간
    private Collider2D collider;

    // 숫자 변경
    public TMP_Text bgmText;

    // 버튼이 눌리고 있는지 확인
    private bool isPressed = false;

    // 실행 되었는지 확인
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
            bgmText.text = string.Format("{0:F1}", (scrollHandle.xPos * 0.5f) + 1.0f);

            GameManager.instance.Bgm((scrollHandle.xPos * 0.5f) + 1.0f);
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
            // 마우스 포지션을 월드 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition.z = 0; // 2D 공간에서는 z 좌표를 0으로 설정

            // 마우스 포지션이 콜라이더 안에 있는지 체크
            if (collider.OverlapPoint(mousePosition) == true)
            {
                GameManager.instance.HandleCoroutine(true);

                scrollHandleObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(((GameManager.instance.bgm - 1) * 100.0f) - 400.0f, scrollHandleObject.GetComponent<RectTransform>().anchoredPosition.y);
                
                center.GetComponent<OpacityObject>().enabled = false;
                center.GetComponent<OnClickSettingCenter>().isCheck = false;
                center.GetComponent<CanvasGroup>().alpha = 0.0f;

                right.GetComponent<OpacityObject>().enabled = false;
                right.GetComponent<OnClickSettingRight>().isCheck = false;
                right.GetComponent<CanvasGroup>().alpha = 0.0f;

                GetComponent<CanvasGroup>().alpha = 0.0f;
                GetComponent<OpacityObject>().enabled = true;
                isCheck = true;
            }

            isPressed = false;
        }
    }
}
