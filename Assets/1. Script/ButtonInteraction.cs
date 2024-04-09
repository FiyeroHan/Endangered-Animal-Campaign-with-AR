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
        // <Exit Button> 누르면 작동.
        // 어플리케이션 종료 기능. 이 기능은 UnityEditor에서는 작동하지 않는다.
        // 따라서 UnityEditor용 코드 #if UNITY_EDITOR 안에 따로 작성.
        Application.Quit();

        #if UNITY_EDITOR    
        //유니티 에디터에서 Debug 용으로만 작동해야 하는 코드
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
