using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeSpawner : MonoBehaviour
{
    private Grid _grid;
    private int gridWidth = 20; // Ширина сетки
    private int gridHeight = 20; // Высота сетки

    private List<Cube> _cubes = new List<Cube>();

    public List<Cube> Cubes
    {
        get => _cubes;
        private set => _cubes = value;
    }

    [SerializeField] private Cube _cube;
    [SerializeField] private int _count = 400;
    [SerializeField] private float _spawnTimeInterval = 0.04f;

    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        _grid = GetComponent<Grid>();
        _coroutine = StartCoroutine(SpawnCube());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) RestartAllCubes();
    }

    private IEnumerator SpawnCube()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                Vector3 worldPosition = _grid.CellToWorld(cellPosition);
                Cube cube = Instantiate(_cube, worldPosition, Quaternion.identity, transform);
                _cubes.Add(cube);
                yield return new WaitForSeconds(_spawnTimeInterval);
            }
        }
    }

    private void RestartAllCubes()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        foreach (var cube in _cubes)
        {
            Destroy(cube.gameObject);
        }

        _cubes.Clear();

        _coroutine = StartCoroutine(SpawnCube());
    }
}