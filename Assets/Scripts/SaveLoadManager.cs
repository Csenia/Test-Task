using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private const string ProgressKey = "PlayerProgress";

    public void SaveProgress(PlayerProgressData progressData)
    {
        string json = JsonUtility.ToJson(progressData);
        PlayerPrefs.SetString(ProgressKey, json);
        PlayerPrefs.Save();
    }

    public PlayerProgressData LoadProgress()
    {
        if (PlayerPrefs.HasKey(ProgressKey))
        {
            string json = PlayerPrefs.GetString(ProgressKey);
            return JsonUtility.FromJson<PlayerProgressData>(json);
        }
        return new PlayerProgressData(0, 1); // Возвращаем начальные значения, если сохранений нет
    }
}
