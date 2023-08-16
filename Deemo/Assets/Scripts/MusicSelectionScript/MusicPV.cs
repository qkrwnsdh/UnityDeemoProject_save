using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPV : MonoBehaviour
{
    private AudioSource audioSource;

    private Coroutine coroutine;

    private float titleCount;

    private int currentIndex = -1;

    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        titleCount = GameManager.instance.musicInformation["Title"].Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < titleCount; i++)
        {
            if (GameManager.instance.musicInformation["Title"][i] == GameManager.instance.title)
            {
                if (i != currentIndex)
                {
                    StartCoroutine(MusicDown(i));
                }
            }
        }
    }

    private IEnumerator MusicDown(int i)
    {
        currentIndex = i;

        float timeElapsed = 0.0f;
        if (audioSource.clip != null)
        {
            while (timeElapsed < duration)
            {
                timeElapsed += Time.deltaTime;

                float time = Mathf.Clamp01(timeElapsed / duration);

                audioSource.volume = Mathf.Lerp(1.0f, 0.0f, time);

                yield return null;
            }
        }

        audioSource.volume = 1.0f;
        audioSource.clip = Resources.Load<AudioClip>(GameManager.instance.path + "MusicPVFileName/" + GameManager.instance.musicInformation["MusicPvFileName"][i]);

        audioSource.Play();
    }
}
