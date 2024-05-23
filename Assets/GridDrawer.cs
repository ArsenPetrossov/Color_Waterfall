using System;
using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    public int gridSize = 10;
    public float cellSize = 1f;
    public Vector3 gridStartPosition; // Начальная позиция сетки

   
    private void OnDrawGizmos()
    {
        gridStartPosition = transform.position;
        DrawGrid();
    }

    private void DrawGrid()
    {
        Gizmos.color = Color.gray;

        // Отрисовка горизонтальных линий
        for (float i = 0; i <= gridSize; i++)
        {
            float y = i * cellSize;
            Vector3 startPoint = gridStartPosition + new Vector3(0, 0, y);
            Vector3 endPoint = gridStartPosition + new Vector3(gridSize * cellSize, 0, y);
            Gizmos.DrawLine(startPoint, endPoint);
        }

        // Отрисовка вертикальных линий
        for (float i = 0; i <= gridSize; i++)
        {
            float x = i * cellSize;
            Vector3 startPoint = gridStartPosition + new Vector3(x, 0, 0);
            Vector3 endPoint = gridStartPosition + new Vector3(x, 0, gridSize * cellSize);
            Gizmos.DrawLine(startPoint, endPoint);
        }
    }
}