using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float bgm;
    public float speed;
    public float key;

    public bool coroutineCheck = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bgm = 5.0f;
        speed = 5.0f;
        key = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Bgm(float bgm_)
    {
        bgm = bgm_;
    }

    public void Speed(float speed_)
    {
        speed = speed_;
    }

    public void Key(float key_)
    {
        key = key_;
    }

    public void HandleCoroutine(bool coroutineCheck_)
    {
        coroutineCheck = coroutineCheck_;
    }
}
