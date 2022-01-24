using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;
    private List<string> scenes;

    private void Start()
    {
        AssetBundle bundle = AssetBundle.LoadFromFile("Assets/BundledAssets/scene");
        scenes = new List<string>(bundle.GetAllScenePaths());

        Debug.Log("length is : " + scenes.Count);
        foreach (string scene in scenes)
        {
            Debug.Log("scene path is : " + scene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            //SceneAsset sceneToLoad = _sceneController.GetSceneByName("TestScene_1");
            //var newScenePath = AssetDatabase.GetAssetPath(sceneToLoad);

            SceneManager.LoadScene(scenes[0], LoadSceneMode.Single);
            
            //SceneManager.LoadScene(newScenePath, LoadSceneMode.Single);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //SceneAsset sceneToLoad = _sceneController.GetSceneByName("TestScene_2");
            //var newScenePath = AssetDatabase.GetAssetPath(sceneToLoad);
            SceneManager.LoadScene(scenes[1], LoadSceneMode.Single);
            //SceneManager.LoadScene(newScenePath, LoadSceneMode.Single);
        }
    }
}
