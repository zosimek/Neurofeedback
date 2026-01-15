using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static string sceneName;
    public void LoadScene(string name)
    {
        if(sceneName != name)
        {
            sceneName = name;
            if (sceneName == "Main")
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
        }
        
    }

}
