using UnityEditor.Timeline;
using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [SerializeField] //will be visible in the Unity Inspector
    bool freezeXZAxis = true;
    public void Update()
    {
        // This method is intended to update the billboard effect for a sprite.
        // Currently, it does not contain any implementation.

        // You can add code here to adjust the sprite's rotation or position
        // to always face the camera, creating a billboard effect.

        // Rotate the sprite to face the camera while maintaining the XZ axis orientation
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        }
        else
        {
            // If not freezing the XZ axis, align the sprite's rotation with the camera's rotation
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
