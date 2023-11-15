using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.IO;

/// <summary>
/// Data Singleton Class
/// </summary>
/// 
public class LoadDataManager : SingletonClass <LoadDataManager>
{
    /// <summary>
    /// Key : string(메뉴 이름) , Value : Food (메뉴 클래스)
    /// </summary>
    public Dictionary<string, Food> foodDictionary = new Dictionary<string, Food>();

    public void CreateDictionary()
    {

        TextAsset textAsset = Resources.Load<TextAsset>("foods");
        FoodArr foodArr = JsonUtility.FromJson<FoodArr>(textAsset.text);

        for (int i = 0; i < foodArr.foods.Length; i++)
        {
            Debug.Log($"Name : {foodArr.foods[i].foodName}, Price : {foodArr.foods[i].foodPrice}," +
                $" Info : {foodArr.foods[i].foodInfo}");

            foodDictionary.Add(foodArr.foods[i].foodName, foodArr.foods[i]);
        }
    }

    private void Start()
    {
        CreateDictionary();
    }
}
