using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    #region Declaration & Definition
    public Button BGMOnButton;
    public Button BGMOffButton;
    public Button SFXButton;
    #endregion

    #region Unity Default Method
    void Start()
    {
        BGMOnButton.onClick.AddListener(PlayBGM);
        BGMOffButton.onClick.AddListener(StopBGM);
        SFXButton.onClick.AddListener(PlaySFX);
    }

    void Update()
    {
        
    }
    #endregion

    #region Method
    private void PlayBGM()
    {
        SoundManager.Instance.PlayLoopSound("Sound1");
    }

    private void StopBGM()
    {
        SoundManager.Instance.StopBGM();
    }

    private void PlaySFX()
    {
        SoundManager.Instance.PlaySound("Sound2");
    }
    #endregion
}
