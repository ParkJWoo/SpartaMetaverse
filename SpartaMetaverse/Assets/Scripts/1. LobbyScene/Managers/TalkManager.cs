using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //  ������Ʈ�� Ŭ���� ��, �����Ǵ� �ؽ�Ʈ ������ ���� ����
    Dictionary<int, string> talkData;

    #region Awake �޼��� �� �ش� �޼��忡�� GenerateData�� ȣ���Ѵ�.
    private void Awake()
    {
        talkData = new Dictionary<int, string>();
        GenerateData();
    }
    #endregion

    #region GenerateData �޼��� �� �� ������Ʈ �� ��ȣ�ۿ� ��, ������ �ؽ�Ʈ �����͸� �����Ѵ�.
    void GenerateData()
    {
        talkData.Add(1000, "���ĸ�Ÿ ��Ÿ������ � �Ͷ�.. �̰����� ���� �� ���� �Ӹ��� ������ ������ ����..");
        talkData.Add(2000, "���� ��� �ƴϴ�! ���� �Ϳ��� �ذ��� ��..");
        talkData.Add(3000,  "���� �ҷ���!! �ҷ����� �ƴ϶��? ���Դ� ������ �ҷ����̾�!");
        talkData.Add(4000, "�� �ʸӿ� �̴ϰ����� �غ�Ǿ� �ִ�! ���� ����!");

        talkData.Add(100,  "����ִ� �����̴�");
    }
    #endregion

    #region GetTalk �޼��� �� GenerateData���� ������ �ؽ�Ʈ �����͵��� �ٸ� ������ ȣ���ϱ� ���� �޼���
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
    #endregion
}
