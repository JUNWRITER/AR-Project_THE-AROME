using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Medici
{
    public class TargetPositionDisplay : MonoBehaviour
    {
        public GameObject target;
        public TextMeshProUGUI targetPosText;

        private void Update()
        {
            if (target.activeInHierarchy)
                targetPosText.text = $"({target.transform.position})";
        }
    }
}

