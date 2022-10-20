using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class LanguageController : MonoBehaviour
{
    //Singleton mode
    public static LanguageController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public Dictionary<string, Language> LanguageLib = new Dictionary<string, Language>();

    private void loadLanguage()
    {
        foreach (var item in Resources.LoadAll("Language"))
        {
            TextAsset t = (TextAsset)item;
            string js = t.text;
            Language Lan = JsonConvert.DeserializeObject<Language>(js);
            LanguageLib.Add(Lan.LanguageType,Lan);
        }
    }
}

public class Language
{
    public string LanguageType;
    public string Author;
    public string Version;
    public Dictionary<string, string> Lib = new Dictionary<string, string>();
}