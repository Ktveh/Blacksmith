using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Vector2 _offset;

    private void Update()
    {
        _renderer.material.mainTextureOffset = new Vector2(_renderer.material.mainTextureOffset.x + _offset.x * Time.deltaTime, _renderer.material.mainTextureOffset.y + _offset.y * Time.deltaTime);
    }
}
