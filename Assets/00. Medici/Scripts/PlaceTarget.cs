using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Medici
{
    public class PlaceTarget : MonoBehaviour
    {
        private ARRaycastManager raycastManager;
        private GameObject placeTarget;

        private void Start()
        {
            raycastManager = FindAnyObjectByType<ARRaycastManager>();
            placeTarget = transform.GetChild(0).gameObject;
            placeTarget.SetActive(false);
        }

        private void Update()
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;

                if (!placeTarget.activeInHierarchy)
                    placeTarget.SetActive(true);
            }

        }
    }

}
