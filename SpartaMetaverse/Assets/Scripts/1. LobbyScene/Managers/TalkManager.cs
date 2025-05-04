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
        talkData.Add(1000, "스파르타 메타버스에 어서 와라.. 이곳에서 터질 것 같은 머리를 차갑게 식히고 가라..");
        talkData.Add(2000, "나는 샌즈가 아니다! 그저 귀여운 해골일 뿐..");
        talkData.Add(3000,  "해피 할로윈!! 할로윈이 아니라고? 내게는 매일이 할로윈이야!");

        talkData.Add(100,  "비어있는 상자이다");
    }

    public string GetTalk(int id, int talkIndex)
    {
        //  해당 id의 대화 데이터가 더이상 존재하지 않을 경우
        if(talkIndex == talkData[id].Length)
        {
            //  데이터가 없으니 null 리턴
            return null;
        }

        else
        {
            return talkData[id];
        }
    }
}
