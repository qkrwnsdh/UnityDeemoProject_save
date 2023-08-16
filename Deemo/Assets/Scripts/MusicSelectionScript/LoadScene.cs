using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Run(float t, string name)
    {
        StartCoroutine(DelayForLoadScene(t, name));
    }

    public void asyncLoadScene(string name)
    {
        // �񵿱� �� �ε� ����
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        asyncLoad.allowSceneActivation = false; // �� �ε� �Ϸ� �� �ڵ� Ȱ��ȭ ����

        // �ε��� �Ϸ�� ������ ���
        StartCoroutine(WaitForSceneLoad(asyncLoad));
    }

    public IEnumerator DelayForLoadScene(float t, string name)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(name);
    }

    private IEnumerator WaitForSceneLoad(AsyncOperation asyncLoad)
    {
        while (!asyncLoad.isDone)
        {
            // �ε� ���� ��Ȳ�� ǥ���ϰų� �߰� �۾� ���� ����
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // 0.9f�� �ε��� 90%���� �Ϸ�Ǿ��ٴ� �ǹ�
            Debug.Log("Loading progress: " + progress * 100 + "%");

            // ������ �����ϸ� �� Ȱ��ȭ
            if (progress >= 1.0f)
            {
                yield return new WaitForSeconds(1.0f);
                asyncLoad.allowSceneActivation = true; // �� Ȱ��ȭ ���
            }

            // ���� �����ӱ��� ���
            yield return null;
        }

        // �ε� �Ϸ� �� �߰� �۾� ���� ����
        Debug.Log("Scene loading complete!");
    }

}
