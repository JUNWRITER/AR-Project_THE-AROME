using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationEvent : MonoBehaviour
{
    public void OpningEndEvent()
    {
        UIManager.Instance.SetScreen(UIManager.Instance.MainPage);
        UIManager.Instance.OnSetUIBar(true);
        SoundManager.Instance.PlayLoopSound("Sound1");
    }
}
