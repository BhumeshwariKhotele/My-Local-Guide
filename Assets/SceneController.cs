using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static string keyword;
   

    public void Start()
    {
        // Debug.Log(keyword);

      
    }


    public void Quit()
    {
        Application.Quit();
    }


    public void  ChangeTheScene( string scaneName)
    {
        SceneManager.LoadSceneAsync(scaneName);
    }


    public void AskGoogle(string keyName)
    {
        keyword = keyName;
        Debug.Log(keyword);
    }

  
}
