using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
   
    private Scene _newScene;
    private string _sceneName;

    void Start()
    {
        
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void SwitchToSpecificScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
