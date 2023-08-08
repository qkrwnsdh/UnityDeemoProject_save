using UnityEngine;

[System.Serializable]
public class SongData
{
    // �뷡 ����
    public string title;

    // �뷡 ��Ƽ��Ʈ
    public string artist;

    // �뷡 ���̵�
    public int difficulty;

    // �뷡 �ְ� ����
    public float bestScore;

    // �뷡 �̹���
    public Sprite backgroundImg;

    public SongData(string title_, string artist_, int difficulty_, float bestScore_, Sprite backgroundImg_)
    {
        this.title = title_;
        this.artist = artist_;
        this.difficulty = difficulty_;
        this.bestScore = bestScore_;
        this.backgroundImg = backgroundImg_;
    }
}
