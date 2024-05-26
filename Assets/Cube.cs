using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Color _currentColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _currentColor = _renderer.material.color;
    }

    public IEnumerator ChangeCubeColor(Color nextColor, float duration)
    {
        Color startColor = _currentColor;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / duration);
            _currentColor = Color.Lerp(startColor, nextColor, progress);
            _renderer.material.color = _currentColor;
            yield return null;
        }

        _currentColor = nextColor;
        _renderer.material.color = _currentColor;
    }
}