using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObj : MonoBehaviour
{
    private static SingletonObj _instance;

    public static SingletonObj Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
