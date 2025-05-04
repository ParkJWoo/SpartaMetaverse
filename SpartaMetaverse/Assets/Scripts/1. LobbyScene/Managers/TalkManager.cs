using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, "���ĸ�Ÿ ��Ÿ������ � �Ͷ�.. �̰����� ���� �� ���� �Ӹ��� ������ ������ ����..");
        talkData.Add(2000, "���� ��� �ƴϴ�! ���� �Ϳ��� �ذ��� ��..");
        talkData.Add(3000,  "���� �ҷ���!! �ҷ����� �ƴ϶��? ���Դ� ������ �ҷ����̾�!");

        talkData.Add(100,  "����ִ� �����̴�");
    }

    public string GetTalk(int id, int talkIndex)
    {
        //  �ش� id�� ��ȭ �����Ͱ� ���̻� �������� ���� ���
        if(talkIndex == talkData[id].Length)
        {
            //  �����Ͱ� ������ null ����
            return null;
        }

        else
        {
            return talkData[id];
        }
    }
}
