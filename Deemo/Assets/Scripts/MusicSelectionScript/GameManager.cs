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

    public List<string> mainTitle = new List<string>();
    public List<string> composer = new List<string>();

    public bool coroutineCheck = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainTitle.Add("3piece-JazzParty!");
        mainTitle.Add("no Man's Land");
        mainTitle.Add("Sanctity");
        mainTitle.Add("imp");
        mainTitle.Add("Yawning Lion");
        mainTitle.Add("Leviathan");
        mainTitle.Add("OBLIVION");
        mainTitle.Add("Heart of Witch");
        mainTitle.Add("Ever After Story");
        mainTitle.Add("Queen on Ice");

        composer.Add("Mihile");
        composer.Add("Sherwin");
        composer.Add("Rabpit");
        composer.Add("sakuzyo");
        composer.Add("V.K");
        composer.Add("NeLiME");
        composer.Add("ESTi (Piano: Ayatsugu_Otowa)");
        composer.Add("Rex (Piano: Ayatsugu_Otowa)");
        composer.Add("Capchii");
        composer.Add("Ayatsugu_Otowa");


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
