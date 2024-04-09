using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public MultipleImageTracker multipleImagerTracker;

    public void ResetARObject()
    {
        multipleImagerTracker.DestroyARObjects();
        multipleImagerTracker.ResetARObjectSpawn();
    }

    public void ExitGame()
    {
        // <Exit Button> ������ �۵�.
        // ���ø����̼� ���� ���. �� ����� UnityEditor������ �۵����� �ʴ´�.
        // ���� UnityEditor�� �ڵ� #if UNITY_EDITOR �ȿ� ���� �ۼ�.
        Application.Quit();

        #if UNITY_EDITOR    
        //����Ƽ �����Ϳ��� Debug �����θ� �۵��ؾ� �ϴ� �ڵ�
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
