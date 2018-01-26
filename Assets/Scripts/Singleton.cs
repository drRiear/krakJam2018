﻿using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _Instance;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = (T)FindObjectOfType(typeof(T));

                if (FindObjectsOfType(typeof(T)).Length > 1)
                Debug.LogError("There needs to have only one active CharacterManager script on a GameObject in your scene.");


                if (_Instance == null)
                {
                    GameObject singleton = new GameObject { name = "Singleton <" + typeof(T).ToString() + ">" };
                    singleton.AddComponent<T>();
                }

            }
            return _Instance;
        }
    }
}