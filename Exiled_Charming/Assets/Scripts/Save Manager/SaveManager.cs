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

    // When awake load the last saved//
    private void Awake()
    {
        instance = this;
        Load();
    }
    //


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
        // Path where the saved is kept //
        string dataPath = Application.persistentDataPath;
        //

        // creation of the save document//
        var stream = new FileStream(dataPath + "/" + ActiveSave.SaveName + ".save", FileMode.Create);
        //
        // Creation of hte serializer de type of SaveData//
        var serializer = new XmlSerializer(typeof(SaveData));
        //

        //Writing the save into the document //
        serializer.Serialize(stream, ActiveSave);
        stream.Close();
        //
        
        Debug.Log("Saved");
    }

    public void Load()
    {
        // Same path than where is located the save file//
        string dataPath = Application.persistentDataPath;
        //

        // Searching if there is a save//
        if (System.IO.File.Exists(dataPath + "/" + ActiveSave.SaveName + ".save"))
        {
            // if there is the save then load the save//
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + ActiveSave.SaveName + ".save", FileMode.Open);

            ActiveSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            //
            Debug.Log("loaded");
            HasLoaded = true;
            

        }
        //
    }

    public void DeleteSaveData()
    {
        // Same path where the save is located//
        string dataPath = Application.persistentDataPath;
        // if there is a save delete it //
        if (System.IO.File.Exists(dataPath + "/" + ActiveSave.SaveName + ".save"))
        {
            File.Delete(dataPath + "/" + ActiveSave.SaveName + ".save");
            Debug.Log("Deleted");
        }
        //
    }
}

// Class that stock all the data that need to be save and load //
[System.Serializable]
public class SaveData
{
    public string SaveName;

    public Vector3 RespawnPositionSaved;
    
    public int HpSaved;
    public int LevelSaved;

    public float XpSaved;
    public float MaxXpSaved;

    public int DefSaved;
    public int ADSaved;





}
//