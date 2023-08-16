////using System.Collections.Generic;
////using UnityEngine;
////using System.IO;

////public class CSVReader : MonoBehaviour
////{
////    #region �̱��� ����
////    private static CSVReader m_instance; // �̱����� �Ҵ�� static ����
////    public static CSVReader instance
////    {
////        get
////        {
////            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
////            if (m_instance == null)
////            {
////                // ������ CSVReader ������Ʈ�� ã�� �Ҵ�
////                m_instance = FindObjectOfType<CSVReader>();
////            }

////            // �̱��� ������Ʈ�� ��ȯ
////            return m_instance;
////        }
////    }
////    #endregion

////    public const char DELIMITER = ','; // CSV ���Ͽ��� ����ϴ� ������ (�⺻���� �޸�)

////    // csv ������ ������ ��� ���� �����Ͽ� ������ ��ųʸ�
////    // ���� Ű ���� �ǰ�, ���� Ű �� ������ ���� �ȴ�.
////    public Dictionary<string, List<string>> dataDictionary = default;

////    // CSV ������ �д� �Լ�
////    // dirPath���� "Assets/Resources/ZombieDatas"�� ���� ���丮 ��θ� �Է��Ѵ�.
////    // csvFileName���� "ZombieSurvivalDatas.csv"�� ���� csv ������ �̸��� �Է��Ѵ�.
////    public Dictionary<string, List<string>> ReadCSVFile()
////    {
////        dataDictionary = new Dictionary<string, List<string>>();
////        string filePath = "Assets/Resources/" + "MusicList.csv";
////        try
////        {
////            using (StreamReader reader = new StreamReader(filePath))
////            {
////                string[] headers = reader.ReadLine().Split(DELIMITER);

////                foreach (string header in headers)
////                {
////                    dataDictionary.Add(header, new List<string>());
////                }

////                while (!reader.EndOfStream)
////                {
////                    string line = reader.ReadLine();
////                    string[] values = line.Split(DELIMITER);

////                    for (int i = 0; i < values.Length; i++)
////                    {
////                        dataDictionary[headers[i]].Add(values[i]);
////                    }
////                }
////            }
////            return dataDictionary;
////        }

////        // csv ���Ͽ� ������ ���� ��� ���� �޽��� ���
////        catch (IOException e)
////        {
////            Debug.LogError("Error reading the CSV file: " + e.Message);
////            return default;
////        }
////    }

////    // ��ȯ�� csv ������ ������ ����� ��ųʸ� ������ ���� ����ϴ� �Լ�.
////    // "��:��1,��2,��3"�� ���� ��µȴ�.
////    // �Ű� ������ ���� ��ųʸ��� ������ <string, List<string>> �̾�� �Ѵ�.
////    public void PrintData(Dictionary<string, List<string>> dictionary)
////    {
////        // ��ųʸ��� �� �׸��� ���
////        foreach (KeyValuePair<string, List<string>> entry in dictionary)
////        {
////            string category = entry.Key;
////            List<string> values = entry.Value;

////            Debug.Log(category + ": " + string.Join(", ", values));
////        }
////    }
////}

//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;

//public class CSVReader : MonoBehaviour
//{
//    #region �̱��� ����
//    private static CSVReader m_instance; // �̱����� �Ҵ�� static ����
//    public static CSVReader instance
//    {
//        get
//        {
//            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
//            if (m_instance == null)
//            {
//                // ������ CSVReader ������Ʈ�� ã�� �Ҵ�
//                m_instance = FindObjectOfType<CSVReader>();
//            }

//            // �̱��� ������Ʈ�� ��ȯ
//            return m_instance;
//        }
//    }
//    #endregion

//    public const char DELIMITER = ','; // CSV ���Ͽ��� ����ϴ� ������ (�⺻���� �޸�)

//    // csv ������ ������ ��� ���� �����Ͽ� ������ ��ųʸ�
//    // ���� Ű ���� �ǰ�, ���� Ű �� ������ ���� �ȴ�.
//    public Dictionary<string, List<string>> dataDictionary = default;

//    // CSV ������ �д� �Լ�
//    // dirPath���� "Assets/Resources/ZombieDatas"�� ���� ���丮 ��θ� �Է��Ѵ�.
//    // csvFileName���� "ZombieSurvivalDatas.csv"�� ���� csv ������ �̸��� �Է��Ѵ�.
//    public Dictionary<string, List<string>> ReadCSVFile()
//    {
//        dataDictionary = new Dictionary<string, List<string>>();
//        string filePath = "Assets/Resources/" + "MusicList.csv";
//        try
//        {
//            using (StreamReader reader = new StreamReader(filePath))
//            {
//                string[] headers = reader.ReadLine().Split(DELIMITER);

//                foreach (string header in headers)
//                {
//                    dataDictionary.Add(header, new List<string>());
//                }

//                while (!reader.EndOfStream)
//                {
//                    string line = reader.ReadLine();
//                    string[] values = line.Split(DELIMITER);

//                    for (int i = 0; i < values.Length; i++)
//                    {
//                        dataDictionary[headers[i]].Add(values[i]);
//                    }
//                }
//            }
//            return dataDictionary;
//        }

//        // csv ���Ͽ� ������ ���� ��� ���� �޽��� ���
//        catch (IOException e)
//        {
//            Debug.LogError("Error reading the CSV file: " + e.Message);
//            return default;
//        }
//    }

//    // ��ȯ�� csv ������ ������ ����� ��ųʸ� ������ ���� ����ϴ� �Լ�.
//    // "��:��1,��2,��3"�� ���� ��µȴ�.
//    // �Ű� ������ ���� ��ųʸ��� ������ <string, List<string>> �̾�� �Ѵ�.
//    public void PrintData(Dictionary<string, List<string>> dictionary)
//    {
//        // ��ųʸ��� �� �׸��� ���
//        foreach (KeyValuePair<string, List<string>> entry in dictionary)
//        {
//            string category = entry.Key;
//            List<string> values = entry.Value;

//            Debug.Log(category + ": " + string.Join(", ", values));
//        }
//    }
//}

using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    #region �̱��� ����
    private static CSVReader m_instance; // �̱����� �Ҵ�� static ����
    public static CSVReader instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ CSVReader ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<CSVReader>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }
    #endregion
    
    public const char DELIMITER = ','; // CSV ���Ͽ��� ����ϴ� ������ (�⺻���� �޸�)

    // csv ������ ������ ��� ���� �����Ͽ� ������ ��ųʸ�
    // ���� Ű ���� �ǰ�, ���� Ű �� ������ ���� �ȴ�.
    public Dictionary<string, List<string>> dataDictionary = default;

    // CSV ������ �д� �Լ�
    // csvFileName���� "MusicList"�� ���� ������ �̸��� �Է��Ѵ�. (Ȯ���� ����)
    public Dictionary<string, List<string>> ReadCSVFile(string csvFileName)
    {
        dataDictionary = new Dictionary<string, List<string>>();

        TextAsset csvTextAsset = Resources.Load<TextAsset>(csvFileName);

        if (csvTextAsset != null)
        {

            string[] lines = csvTextAsset.text.Split('\n');

            if (lines.Length > 0)
            {
                string[] headers = lines[0].Split(DELIMITER);

                foreach (string header in headers)
                {
                    dataDictionary.Add(header, new List<string>());
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] values = line.Split(DELIMITER);

                    for (int j = 0; j < values.Length; j++)
                    {
                        dataDictionary[headers[j]].Add(values[j]);
                    }
                }
            }
            else
            {
                Debug.LogError("CSV file is empty.");
            }
        }
        else
        {
            Debug.LogError("CSV file not found: " + csvFileName);
        }

        return dataDictionary;
    }

    // ��ȯ�� csv ������ ������ ����� ��ųʸ� ������ ���� ����ϴ� �Լ�.
    // "��:��1,��2,��3"�� ���� ��µȴ�.
    // �Ű� ������ ���� ��ųʸ��� ������ <string, List<string>> �̾�� �Ѵ�.
    public void PrintData(Dictionary<string, List<string>> dictionary)
    {
        // ��ųʸ��� �� �׸��� ���
        foreach (KeyValuePair<string, List<string>> entry in dictionary)
        {
            string category = entry.Key;
            List<string> values = entry.Value;

            Debug.Log(category + ": " + string.Join(", ", values));
        }
    }
}