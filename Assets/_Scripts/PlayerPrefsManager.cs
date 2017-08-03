using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty_key";
    const string LEVEL_KEY = "level_unlocked_";

    ///<summary>
    ///0 to 1
    ///</summary>
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0 && volume <= 1)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogWarning("Volume value can only between 0 and 1.");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 1f);
    }

    ///<summary>
    ///1 to 3
    ///</summary>
    public static void SetDifficulty(float volume)
    {
        if (volume >= 1 && volume <= 3)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, volume);
        else
            Debug.LogWarning("Volume value can only between 1 to 3.");
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetLevelUnlocked(int levelNum)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (levelNum > 0 && levelNum <= sceneCount)
            PlayerPrefs.SetInt(LEVEL_KEY + levelNum, 1);
        else
        {
            Debug.LogWarning("Invalid level number: No changes were made. Total number of Scene in build setting is " +
                             sceneCount + ".");
        }
    }

    public static bool IsLevelUnlocked(int levelNum)
    {
        return PlayerPrefs.GetInt(LEVEL_KEY + levelNum) == 1;
    }
}