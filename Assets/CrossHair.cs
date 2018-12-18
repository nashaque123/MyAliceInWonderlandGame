using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour {
    //Displays crosshair for user to see where they are aiming
    public Texture2D crosshairImage;

    void OnGUI()
    {
        float xCenter = (Screen.width / 2) - (crosshairImage.width / 2);
        float yCenter = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xCenter, yCenter, crosshairImage.width, crosshairImage.height), crosshairImage);
    }
}
