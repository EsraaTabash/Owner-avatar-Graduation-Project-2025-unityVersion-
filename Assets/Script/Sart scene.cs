using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenuContlorer : MonoBehaviour
{
    public int score = 123;
    public void OnStartClick()
    {
        SceneManager.LoadScene("gameSene");
    }
    public void OnExitClick()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        try
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call("sendScoreAndFinish", score);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error sending score to Android: " + e.Message);
        }
#else
        Application.Quit();
#endif
    }
public void OnBackToMenuClick()
{
    //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    SceneManager.LoadScene("Main");
}

}