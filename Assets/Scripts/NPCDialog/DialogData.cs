using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogData : MonoBehaviour
{
    private int dialogStep = 0; // 대화 단계 
    public string[] dialogs; // 단계별 대화를 저장하는 문자열 배열

    public string GetDialogue() // 대화 반환
    {
        if (dialogs.Length <= dialogStep)
        {
            return ".....";
        }

        return dialogs[dialogStep++];
    }

    public void ResetDialogue() // 대화 단계 초기화
    {
        dialogStep = 0;
    }

    public bool DialogueComplete() // 대화가 끝났는 지 반환
    {
        return dialogs.Length <= dialogStep;
    }
}