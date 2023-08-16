using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickEffectDifficulty : MonoBehaviour
{
    // �������� ȣ��Ǵ� ��ġ
    public GameObject prefabSave;

    // Ŭ���� ���ÿ� ȣ���� ������
    public GameObject prefab;

    // Ŭ���� ���ÿ� ������ ������Ʈ
    public GameObject namebar;
    public GameObject scorebar;

    // �̹����� �ٲ� ����� �̹���
    public Image targetDifficulty;
    public Image targetBar;

    // Easy, Normal, Hard �̹��� ����
    public Sprite newDifficultyEasy;
    public Sprite newDifficultyNormal;
    public Sprite newDifficultyHard;
    public Sprite newBarEasy;
    public Sprite newBarNormal;
    public Sprite newBarHard;

    // �ʱ� �̹����� ���� ���̵� �̹����� ����
    private Sprite currentDifficulty;
    private Sprite currentBar;

    // ���� ���� �ڷ�ƾ �����ϱ�
    private Coroutine startOverScale;
    private Coroutine startOrignalScale;
    private Coroutine startBarScaleFirst;
    private Coroutine startBarScaleSecound;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(Camera)
    public Camera mainCamera;

    // ȣ���� �������� �����ϱ� ���� ����
    private List<GameObject> prefabList = new List<GameObject>();

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(LayerMask)
    public LayerMask targetLayer;

    // �̹��� ũ�� ������ ���� ����
    private Vector2 orignalScale;
    private Vector2 pressedScale;
    private Vector2 overScale;

    // �ٸ� ������Ʈ �ʱ� ũ�Ⱚ ����
    private Vector2 namebarScale;
    private Vector2 scorebarScale;

    // ũ�� ������ �ε巴�� �ϱ� ���� ����
    private float durationFirst = 0.2f;
    private float durationSecound = 0.1f;
    private float durationBar = 0.15f;

    // ��ư�� ������ �ִ��� Ȯ��
    private bool isPressed = false;

    // ���콺 �����Ͱ� ������Ʈ �ȿ� �ִ��� Ȯ��
    private bool isPoint = false;

    private void Start()
    {
        // ���� �� �̹����� ���� ���̵� �̹����� �����մϴ�.
        currentDifficulty = newDifficultyEasy;
        targetDifficulty.sprite = currentDifficulty;
        currentBar = newBarEasy;
        targetBar.sprite = currentBar;

        // �̹��� ũ�� ����
        orignalScale = targetDifficulty.transform.localScale;
        pressedScale = orignalScale * 0.9f;
        overScale = orignalScale * 1.05f;

        // �� ��ġ ����
        namebarScale = namebar.transform.localScale;
        scorebarScale = scorebar.transform.localScale;
    }

    private void Update()
    {
        if (isPressed == true)
        {
            targetDifficulty.transform.localScale = pressedScale;
        }

        if (currentDifficulty == newDifficultyEasy) { GameManager.instance.Difficulty(0); }
        else if (currentDifficulty == newDifficultyNormal) { GameManager.instance.Difficulty(1); }
        else if (currentDifficulty == newDifficultyHard) { GameManager.instance.Difficulty(2); }
    }

    private void OnMouseDown()
    {
        // �ڷ�ƾ�� �����ϰ� ���ο� �ڷ�ƾ�� ����
        if (startOverScale != null) { StopCoroutine(startOverScale); }
        if (startOrignalScale != null) { StopCoroutine(startOrignalScale); }

        if (startBarScaleFirst != null) { StopCoroutine(startBarScaleFirst); }
        if (startBarScaleSecound != null) { StopCoroutine(startBarScaleSecound); }

        isPressed = true;
    }

    private void OnMouseUp()
    {
        if (isPoint == true)
        {
            for (int i = 0; i <= prefabList.Count; i++)
            {
                if (prefabList.Count == i)
                {
                    prefabList.Add(Instantiate(prefab, transform.position, Quaternion.identity, prefabSave.transform));

                    StartCoroutine(AddPrefab(i));

                    break;
                }
                else
                {
                    if (prefabList[i].activeSelf)
                    {
                        continue;
                    }
                    else
                    {
                        StartCoroutine(RecyclePrefab(i));

                        break;
                    }

                }
            }

            // ��ư�� ���� �� ���̵��� ���� �̹����� �����մϴ�.
            if (currentDifficulty == newDifficultyEasy) { currentDifficulty = newDifficultyNormal; }
            else if (currentDifficulty == newDifficultyNormal) { currentDifficulty = newDifficultyHard; }
            else if (currentDifficulty == newDifficultyHard) { currentDifficulty = newDifficultyEasy; }

            if (currentBar == newBarEasy) { currentBar = newBarNormal; }
            else if (currentBar == newBarNormal) { currentBar = newBarHard; }
            else if (currentBar == newBarHard) { currentBar = newBarEasy; }

            // ����� �̹����� targetImage�� �����մϴ�.
            targetDifficulty.sprite = currentDifficulty;
            targetBar.sprite = currentBar;

            startOverScale = StartCoroutine(StartOverScale());
            startBarScaleFirst = StartCoroutine(StartBarScaleFirst());

            isPressed = false;
        }
    }

    private void OnMouseDrag()
    {
        // ���콺 ������ ��ġ�� ī�޶� ��ũ�� ��ǥ�� ��ȯ
        Vector3 mousePosition = Input.mousePosition;

        // ī�޶� ��ũ�� ��ǥ�� ���̷� ��ȯ
        Vector2 rayOrigin = mainCamera.ScreenToWorldPoint(mousePosition);

        // ����ĳ��Ʈ�� 2D ������Ʈ���� �浹 �˻�
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 0f, targetLayer);

        if (hit.collider != null)
        {
            isPoint = true;
        }
        else
        {
            StartCoroutine(StartOverScale());

            isPressed = false;
            isPoint = false;
        }
    }

    private IEnumerator StartOverScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationFirst)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationFirst);

            // ������ ���� ����Ͽ� ������ ���� ����
            targetDifficulty.transform.localScale = Vector2.Lerp(pressedScale, overScale, time);

            yield return null;
        }

        startOrignalScale = StartCoroutine(StartOrignalScale());
    }

    private IEnumerator StartOrignalScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationSecound)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationSecound);

            // ������ ���� ����Ͽ� ������ ���� ����
            targetDifficulty.transform.localScale = Vector2.Lerp(overScale, orignalScale, time);

            yield return null;
        }
    }

    private IEnumerator StartBarScaleFirst()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationBar)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationBar);

            // ������ ���� ����Ͽ� ������ ���� ����
            float newXScale = Mathf.Lerp(namebarScale.x, namebarScale.x * 0.8f, time);

            namebar.transform.localScale = new Vector2(newXScale, namebarScale.y);
            scorebar.transform.localScale = new Vector2(newXScale, namebarScale.y);

            yield return null;
        }

        startBarScaleSecound = StartCoroutine(StartBarScaleSecound());
    }

    private IEnumerator StartBarScaleSecound()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationBar)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationBar);

            // ������ ���� ����Ͽ� ������ ���� ����
            float newXScale = Mathf.Lerp(namebarScale.x * 0.8f, namebarScale.x, time);

            namebar.transform.localScale = new Vector2(newXScale, namebarScale.y);
            scorebar.transform.localScale = new Vector2(newXScale, namebarScale.y);

            yield return null;
        }
    }

    private IEnumerator AddPrefab(int i)
    {
        yield return new WaitForSeconds(2.0f);

        prefabList[i].SetActive(false);

    }

    private IEnumerator RecyclePrefab(int i)
    {
        prefabList[i].SetActive(true);

        yield return new WaitForSeconds(2.0f);

        prefabList[i].SetActive(false);
    }
}
