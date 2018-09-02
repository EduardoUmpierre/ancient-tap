using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class SaveLoad : MonoBehaviour {
    //
    private static Save CreateSaveGameObject()
    {
        Save save = new Save
        {
            level = Hero.level,
            maxLevel = Hero.maxLevel,
            coins = Hero.coins,
            damagePerSecond = Hero.damagePerSecond,
            damagePerClick = Hero.damagePerClick,
            criticalChance = Hero.criticalChance,
            criticalDamage = Hero.criticalDamage,
            goldBonus = Hero.goldBonus,
            shopListItems = ShopController.shopController
        };

        return save;
    }

    // It's static so we can call it from anywhere
    public static void Save() {
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }   
     
    //
    public static void Load() {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            Hero.level = save.level;
            Hero.maxLevel = save.maxLevel;
            Hero.coins = save.coins;
            Hero.damagePerSecond = save.damagePerSecond;
            Hero.damagePerClick = save.damagePerClick;
            Hero.criticalChance = save.criticalChance;
            Hero.criticalDamage = save.criticalDamage;
            Hero.goldBonus = save.goldBonus;

            foreach (KeyValuePair<string, Dictionary<string, object>> entry in save.shopListItems)
            {
                ShopController.shopController[entry.Key] = entry.Value;
            }

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
