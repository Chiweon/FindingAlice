﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container{
        get{
            return _container;
        }
    }
    static DataController _intance;
    public static DataController Instance{
        get{
            if(!_intance){
                _container = new GameObject();
                _container.name = "DataController";
                _intance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _intance;
        }
    }
    public string GameDataFileName = "FindingAlliceData.json";

    public GameData _gameData;
    public GameData gameData{
        get{
            if(_gameData == null){
                _gameData = LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start(){
        _gameData = LoadGameData();
        SaveGameData();
    }

    public GameData LoadGameData(){
#if UNITY_ANDROID
        string filePath = Path.Combine(Application.persistentDataPath, GameDataFileName);
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            Debug.Log("Load Succes");
            string FromJsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("Create New File");
            return new GameData();
        }
#elif UNITY_EDITOR
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;
        if(File.Exists(filePath)){
            Debug.Log("Load Succes");
            string FromJsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else{
            Debug.Log("Create New File");
            return new GameData();
        }
#endif

    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
#if UNITY_ANDROID
        string filePath = Path.Combine(Application.persistentDataPath, GameDataFileName);
#elif UNITY_EDITOR
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;
#endif

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("Save Succes");
    }
    private void OnApplicationQuit() {
        SaveGameData();    
    }
}