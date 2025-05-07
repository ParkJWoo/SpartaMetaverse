using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //  오브젝트를 클릭할 시, 생성되는 텍스트 데이터 변수 선언
    Dictionary<int, string> talkData;

    #region Awake 메서드 → 해당 메서드에서 GenerateData를 호출한다.
    private void Awake()
    {
        talkData = new Dictionary<int, string>();
        GenerateData();
    }
    #endregion

    #region GenerateData 메서드 → 각 오브젝트 별 상호작용 시, 생성될 텍스트 데이터를 관리한다.
    void GenerateData()
    {
        talkData.Add(1000, "스파르타 메타버스에 어서 와라.. 이곳에서 터질 것 같은 머리를 차갑게 식히고 가라..");
        talkData.Add(2000, "나는 샌즈가 아니다! 그저 귀여운 해골일 뿐..");
        talkData.Add(3000,  "해피 할로윈!! 할로윈이 아니라고? 내게는 매일이 할로윈이야!");
        talkData.Add(4000, "이 너머에 미니게임이 준비되어 있다! 즐기고 가라!");

        talkData.Add(100,  "비어있는 상자이다");
    }
    #endregion

    #region GetTalk 메서드 → GenerateData에서 생성한 텍스트 데이터들을 다른 곳에서 호출하기 위한 메서드
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
    #endregion
}
