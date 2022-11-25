using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputHandler : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    [SerializeField] GameObject tower;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            PlaceTower();
            isPlaceable = false;
        }
    }

    private void PlaceTower()
    {
        // Place tower
        Instantiate(tower, this.transform.position, Quaternion.identity);
    }
}
