using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;


public static class FileLoader
{
    public static string ModPath = $"{Application.streamingAssetsPath}/Default";


    public static T LoadJson<T>(string file)
    {
        try
        {
            var data = System.IO.File.ReadAllText(file);

            return JsonUtility.FromJson<T>(data);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            throw;
        }
    }

    public static void SaveAsJson(string file, object data)
    {
        try
        {
            var json = JsonUtility.ToJson(data);
            System.IO.File.WriteAllText(file, json);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}

