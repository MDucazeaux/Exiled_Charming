using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData ActiveSave;

    public bool HasLoaded;

    private void Awake()
    {
        instance = this;
        Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            DeleteSaveData();
        }
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        

        var stream = new FileStream(dataPath + "/" + ActiveSave.SaveName + ".save", FileMode.Create);
        var serializer = new XmlSerializer(typeof(SaveData));

        serializer.Serialize(stream, ActiveSave);
        stream.Close();
        
        Debug.Log("Saved");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + ActiveSave.SaveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + ActiveSave.SaveName + ".save", FileMode.Open);

            ActiveSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("loaded");
            HasLoaded = true;
            

        }

    }

    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + ActiveSave.SaveName + ".save"))
        {
            File.Delete(dataPath + "/" + ActiveSave.SaveName + ".save");
            Debug.Log("Deleted");
        }
    }
}


[System.Serializable]
public class SaveData
{
    public string SaveName;

    public Vector3 RespawnPositionSaved;
    
    public int HpSaved;

    
}