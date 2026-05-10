using UnityEngine;

public static class SaveManager
{
    public static void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public static int LoadInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key,  defaultValue);
    }

    public static void SaveLong(string key, long value)
    {
        PlayerPrefs.SetString(key, value.ToString());
        PlayerPrefs.Save();
    }

    public static long LoadLong(string key, long defaultValue = 0)
    {
        string loadedString = PlayerPrefs.GetString(key);
        return long.Parse(loadedString);
    }
    
    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}
