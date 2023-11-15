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
        MenuInfo menuInfo1 = new MenuInfo("�����", "Į�θ� : 350kcal, ź��ȭ�� : 65g, �ܹ��� : 10g, ���� : 5g", 6000);
        MenuDic.Add(menuInfo1.name, menuInfo1);
        MenuInfo menuInfo2 = new MenuInfo("������", "Į�θ� : 240kcal, ź��ȭ�� : 8g, �ܹ��� : 20g, ���� : 15g", 15000);
        MenuDic.Add(menuInfo2.name, menuInfo2);
        MenuInfo menuInfo3 = new MenuInfo("����", "Į�θ� : 375kcal, ź��ȭ�� : 0g, �ܹ��� : 20g, ���� : 35g", 11000);
        MenuDic.Add(menuInfo3.name, menuInfo3);
        MenuInfo menuInfo4 = new MenuInfo("�����", "Į�θ� : 550kcal, ź��ȭ�� : 20g, �ܹ��� : 30g, ���� : 30g", 16000);
        MenuDic.Add(menuInfo4.name, menuInfo4);
        MenuInfo menuInfo5 = new MenuInfo("�δ��", "Į�θ� : 475kcal, ź��ȭ�� : 20g, �ܹ��� : 29g, ���� : 31g", 13000);
        MenuDic.Add(menuInfo5.name, menuInfo5);
    }
}
