using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImageUI : MonoBehaviour
{  
     private void OnEnable()
     {
        UIManager.Instance.StartOpening();
     }
    private void OnDisable()
    {
        UIManager.Instance.StartOpening();
    }
}
