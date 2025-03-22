using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SetClearImage : MonoBehaviour
{
    private Image targetImage;

    void Start()
    {
        targetImage = GetComponent<Image>();

        byte[] fileData = File.ReadAllBytes("Assets/Screenshots/clear_image.png");
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        targetImage.sprite = Sprite.Create(
            texture, 
            new Rect(0, 0, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f));
    }
}
