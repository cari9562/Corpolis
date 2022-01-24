using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "SceneController", menuName = "SceneObj")]
public class SceneController : ScriptableObject
{
//#if UNITY_EDITOR
//    [SerializeField] private List<SceneAsset> _scenes;
//    private Dictionary<string, SceneAsset> _sceneDic = new Dictionary<string, SceneAsset>();
//#endif

//    private void OnEnable()
//    {
//        foreach (SceneAsset scene in _scenes)
//        {   
//            _sceneDic.Add(scene.name, scene);
//            Debug.Log("scene name: " + scene.name + "\n" + "scene: " + scene);
//        }
//    }

//    public SceneAsset GetSceneByName(string sceneName)
//    {
//        return _sceneDic[sceneName];
//    }
}

