using ShooterGame.Data;
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
        string loadedString = PlayerPrefs.GetString(key, "");
        if (loadedString == "")
            return defaultValue;
        return long.Parse(loadedString);
    }

    public static void SaveUpgradeData(UpgradeData upgradeData)
    {
        PlayerPrefs.SetInt("Damage "+ upgradeData.m_UpgradeName, upgradeData.m_Damage);
        PlayerPrefs.SetInt("Level "+ upgradeData.m_UpgradeName, upgradeData.m_Level);
        SaveLong("Cost "+ upgradeData.m_UpgradeName, upgradeData.m_Cost);
        
        PlayerPrefs.Save();
    }

    public static UpgradeData LoadUpgradeData (UpgradeData upgradeData)
    {
        UpgradeData data = ScriptableObject.CreateInstance<UpgradeData>();
        data.m_Damage = LoadInt("Damage " + upgradeData.m_UpgradeName, upgradeData.DefaultDamage);
        data.m_Level = LoadInt("Level " + upgradeData.m_UpgradeName, 1);
        data.m_Cost = LoadLong("Cost " + upgradeData.m_UpgradeName, upgradeData.DefaultCost);
        
        return data;
    }
    
    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}
