using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Nohoon.Singleton<DataManager>
{
    public Dictionary<string, MenuInfo> MenuDic = new Dictionary<string, MenuInfo>();

    #region Unity Default Method
    private void Awake()
    {
        Init();

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    private void Init()
    {
        MenuInfo menuInfo1 = new MenuInfo("비빔밥", "칼로리 : 350kcal, 탄수화물 : 65g, 단백질 : 10g, 지방 : 5g", 6000);
        MenuDic.Add(menuInfo1.name, menuInfo1);
        MenuInfo menuInfo2 = new MenuInfo("갈비찜", "칼로리 : 240kcal, 탄수화물 : 8g, 단백질 : 20g, 지방 : 15g", 15000);
        MenuDic.Add(menuInfo2.name, menuInfo2);
        MenuInfo menuInfo3 = new MenuInfo("삼겹살", "칼로리 : 375kcal, 탄수화물 : 0g, 단백질 : 20g, 지방 : 35g", 11000);
        MenuDic.Add(menuInfo3.name, menuInfo3);
        MenuInfo menuInfo4 = new MenuInfo("삼계탕", "칼로리 : 550kcal, 탄수화물 : 20g, 단백질 : 30g, 지방 : 30g", 16000);
        MenuDic.Add(menuInfo4.name, menuInfo4);
        MenuInfo menuInfo5 = new MenuInfo("부대찌개", "칼로리 : 475kcal, 탄수화물 : 20g, 단백질 : 29g, 지방 : 31g", 13000);
        MenuDic.Add(menuInfo5.name, menuInfo5);
    }
}
