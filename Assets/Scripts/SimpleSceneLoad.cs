using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneLoad : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update
    public void loadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
