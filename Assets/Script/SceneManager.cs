using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public float timer = 10f;
    public string nextScene = "StartGame";

    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ChangeScene();
        }
        
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            ChangeScene();
    }
}
