using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLableHandler : MonoBehaviour
{

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color occupiedColor = Color.gray;
    
    TextMeshPro label;
    // Coordinates to display in 2D space
    Vector2Int coordinates = new Vector2Int();
    MouseInputHandler mouseHandler;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        mouseHandler = GetComponentInParent<MouseInputHandler>();
        // Display the coordinates on awake -> once during gameplay.
        DisplayCoordinates();
    }

    private void Update()
    {
        // Update coordinates in editor
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            RenameTheObject();            
        }
        ColorCoordinates();
    }

    // Displays the coordinates on each game object.
    private void DisplayCoordinates()
    {
        // Get the coordinates from the PARENT (tile) position. Save them to our Vector2Int variable.
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); 
        // Display the coordinates
        label.text = (coordinates.x + ","  + coordinates.y);
    }

    // Renames the gameobjects parent to current coordinates.
    private void RenameTheObject()
    {
        this.transform.parent.name = coordinates.ToString();
    }

    private void ColorCoordinates()
    {
        if (mouseHandler.IsPlaceable)
        {
            label.color = defaultColor;
        } else
        {
            label.color = occupiedColor;
        }
    }
}
