using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogData : MonoBehaviour
{
    private int dialogStep = 0; // ��ȭ �ܰ� 
    public string[] dialogs; // �ܰ躰 ��ȭ�� �����ϴ� ���ڿ� �迭

    public string GetDialogue() // ��ȭ ��ȯ
    {
        if (dialogs.Length <= dialogStep)
        {
            return ".....";
        }

        return dialogs[dialogStep++];
    }

    public void ResetDialogue() // ��ȭ �ܰ� �ʱ�ȭ
    {
        dialogStep = 0;
    }

    public bool DialogueComplete() // ��ȭ�� ������ �� ��ȯ
    {
        return dialogs.Length <= dialogStep;
    }
}