using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public static List<PlayerLevelSavedData> savedScores = new List<PlayerLevelSavedData>();

    public static void SaveData(PlayerLevelSavedData playerLevelSavedData)
    {
        var levelData = savedScores.FirstOrDefault(c => c.levelData == playerLevelSavedData.levelData);

        if (levelData == null)
        {
            savedScores.Add(playerLevelSavedData);
        }
        else
        {
            if (levelData.levelScore.value < playerLevelSavedData.levelScore.value)
            {
                levelData.levelScore = playerLevelSavedData.levelScore;
            }
        }
    }
}

[Serializable]
public class PlayerLevelSavedData
{
    public LevelData levelData;
    public Score levelScore;
}
