using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoloringBehavior : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubes;
    [SerializeField] private float _delayRecoloring = 0.2f;
    [SerializeField] private float _recoloringDuration = 0.5f;

    public void ChangeColor()
    {
        StartCoroutine(Recoloring());
    }

    private IEnumerator Recoloring()
    {
        Color nextColor = Random.ColorHSV(0, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        for (var i = 0; i < _cubes.Cubes.Count; i++)
        {
            StartCoroutine(_cubes.Cubes[i].ChangeCubeColor(nextColor, _recoloringDuration));
            yield return new WaitForSeconds(_delayRecoloring);
        }
    }
}
