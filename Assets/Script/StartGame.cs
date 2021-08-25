using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string nextScene = "StartGame";

    public void ChangeScene()
    {
        Debug.Log("Change");
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }

    void OnMouseUp()
    {
        ChangeScene();
    }
}
