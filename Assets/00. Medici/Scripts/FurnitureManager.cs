using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public Transform placementTarget;

    public void PlaceFurniture(GameObject furniturePrefab)
    {
        GameObject furniture = Instantiate(furniturePrefab, placementTarget.position, placementTarget.rotation);

    }
}
