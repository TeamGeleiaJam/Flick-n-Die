using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] Vector2 offset, scrollSpeed;

    void Update()
    {
        offset = new Vector2(offset.x += scrollSpeed.x * Time.deltaTime, offset.y += scrollSpeed.y * Time.deltaTime);
        rend.material.SetTextureOffset("_MainTex", offset);
    }
}
