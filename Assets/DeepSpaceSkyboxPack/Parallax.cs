using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;

    private Transform cam;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        lastCameraPosition = cam.transform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxMultiplier;
        lastCameraPosition = cam.transform.position;

        if (Mathf.Abs(cam.position.x - transform.position.x) >= textureUnitSizeX) {
            float offsetPositionX = (cam.transform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cam.transform.position.x + offsetPositionX, transform.position.y);
        }

        if (Mathf.Abs(cam.position.y - transform.position.y) >= textureUnitSizeY) {
            float offsetPositionY = (cam.transform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x, cam.transform.position.y + offsetPositionY);
        }
    }
}
