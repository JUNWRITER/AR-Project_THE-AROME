using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Nohoon;
using System;

public class UIManager : Singleton<UIManager>
{
    //public static UIManager instance;
    [Header("Page")]
    public GameObject MainPage;
    public GameObject menuPage;
    public GameObject OrderListPage;
    public GameObject PaySuccessPage;
    public GameObject OpeningPage;
    public GameObject UIBarPage; 

    [Header("Button")]
    public Button menu1Button;
    public Button menu2Button;
    public Button menu3Button;
    public Button takeButton;
    public Button cancleButton;
    public Button payButton;
    public Button backToMainButton;
    public Button SetButton;

    [Header("Text")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI priceText;

    [Header("3DFoodObject")]
    public GameObject Food3dObject1;
    public GameObject Food3dObject2;
    public GameObject Food3dObject3;

    //  �̳��� �߰� ����
    [Header("Togles")]
    [SerializeField] private Toggle bgmToggle;

    //  �̳��� DataManger -> ���ؿ� DataManager ��ü
    //public Dictionary<string, Menu> menuDictionary;
    public Dictionary<string, Food> menuDictionary;


    void Start()
    {
        //  �̳��� DataManger -> ���ؿ� DataManager ��ü
        //menuDictionary = Nohoon.DataManager.Instance.menuDictionary;
        menuDictionary = LoadDataManager.Instance.foodDictionary;

        //  �̳��� �߰� ����
        bgmToggle.onValueChanged.AddListener(BGMOnOff);
    }

    #region ���

    /// <summary>
    /// BGM OnOff
    /// </summary>
    /// <param name="onoff">BGM State</param>
    public void BGMOnOff(bool onoff)
    {
        if(onoff)
            SoundManager.Instance.PlayLoopSound("Sound1");
        else
            SoundManager.Instance.StopBGM();

        Debug.Log(onoff);

    }
    #endregion

    #region ��ư
    public void OnSetUIBar(bool _value)
    {
        if(_value)
            UIBarPage.SetActive(true);

        else
            UIBarPage.SetActive(false);

    }

    public void OnSetButton(bool _value)
    {
        if(_value)
            gameObject.SetActive(true);

        else
            gameObject.SetActive(false);
    }

    public void StartOpening()
    {
        OpeningPage.SetActive(true);
    }
public void Onmenu1Button(string key) //�޴� ���� ����: name, info, price + 3D ������
    {
        SetScreen(menuPage);

        //  �̳��� DataManger -> ���ؿ� DataManager ��ü

        //nameText.text = menuDictionary[key].name;
        //infoText.text = menuDictionary[key].info;
        //priceText.text = menuDictionary[key].price.ToString();

        nameText.text = menuDictionary[key].foodName;
        infoText.text = menuDictionary[key].foodInfo;
        priceText.text = menuDictionary[key].foodPrice.ToString();
    }
    public void Onmenu2Button()
    {
        SetScreen(menuPage);
    }
    public void Onmenu3Button()
    {
        SetScreen(menuPage);
    }

    //  2023.07.19 �̳��� ����
    //  ���� ���� ��Ź�帳�ϴ�
    public void testButton(string name) //�޴� ��ư ������ switch ���� ���鼭 key��ã�� 
    {
        switch (name)
        {
            case "A_Manu_Name":
                //Onmenu1Button("A_Manu_Name");
                Onmenu1Button("Jeinju Bibimbap");

                Food3dObject1.SetActive(true);
                Food3dObject2.SetActive(false);
                Food3dObject3.SetActive(false);
                //nameText.text = menuDictionary["A_Manu_Name"].name;
                //infoText.text = menuDictionary["A_Manu_Name"].info;
                //priceText.text = menuDictionary["A_Manu_Name"].price.ToString();

                break;

            case "B_Manu_Name":
                //Onmenu1Button("B_Manu_Name");
                Onmenu1Button("Stewed Ribs");
                Food3dObject1.SetActive(false);
                Food3dObject2.SetActive(true);
                Food3dObject3.SetActive(false);
                //nameText.text = menuDictionary["B_Manu_Name"].name;
                //infoText.text = menuDictionary["B_Manu_Name"].info;
                //priceText.text = menuDictionary["B_Manu_Name"].price.ToString();
                break;

            case "C_Manu_Name":
                //Onmenu1Button("C_Manu_Name");
                Onmenu1Button("Grilled Porkbelly");
                Food3dObject1.SetActive(false);
                Food3dObject2.SetActive(false);
                Food3dObject3.SetActive(true);
                //nameText.text = menuDictionary["C_Manu_Name"].name;
                //infoText.text = menuDictionary["C_Manu_Name"].info;
                //priceText.text = menuDictionary["C_Manu_Name"].price.ToString();
                break;
        }
    }

    public void OntakeButton()
    {
        SetScreen(OrderListPage);
    }
    public void OncancleButton()
    {
        SetScreen(MainPage);
    }
    public void OnpayButton()
    {
        SetScreen(PaySuccessPage);
    }
    public void OnbackToMainButton()
    {
        SetScreen(MainPage);
    }
    #endregion

    #region ������(Panel)
    public void SetScreen(GameObject OpeningPage) //������ ��, ��� �������� �����ִ� ���°� �⺻ 
    {
        // deactivate all screens
        MainPage.SetActive(false);
        menuPage.SetActive(false);
        OrderListPage.SetActive(false);
        PaySuccessPage.SetActive(false);
        UIBarPage.SetActive(false);

        //FoodObject�� �����ִ� ���°� �⺻ 
        Food3dObject1.SetActive(false);
        Food3dObject2.SetActive(false);
        Food3dObject3.SetActive(false);

        //active screen
        OpeningPage.SetActive(true);
    }
    #endregion




}
