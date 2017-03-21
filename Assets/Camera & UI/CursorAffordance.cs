using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D combatCursor = null;
    [SerializeField] Texture2D errorCursor = null;

    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start ()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        cameraRaycaster.onLayerChange += OnLayerChanged;  // Registering OnLayerChanged to delegate
    }
	
	// Only called when layer changes
	void OnLayerChanged(Layer newLayer)
    {
        switch (newLayer)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(combatCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(errorCursor, cursorHotspot, CursorMode.Auto);
                Debug.LogError("Don't know what cursor to show");
                return;
        }
	}
}
