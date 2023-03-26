using UnityEngine;

public class Grid : MonoBehaviour
{
    public float gridSize = 1f;
    public int numGridLines = 10;
    public Material gridMaterial;

    private LineRenderer lineRenderer;
    public Vector3[] points;
    void Start()
    {
        // Create a new GameObject with a Line Renderer component
        GameObject gridObject = new GameObject("Grid");
        lineRenderer = gridObject.AddComponent<LineRenderer>();

        // Set the Line Renderer properties
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = gridMaterial;

        // Set the Line Renderer points to the grid lines
        if (numGridLines > 0)
        {
            points = new Vector3[(numGridLines + 1) * (numGridLines + 1) * 2];
            int index = 1;

            for (int i = 0; i <= numGridLines; i++)
            {
                float pos = i * gridSize;

                // Horizontal line
                points[index++] = new Vector3(0f, 0f, pos);
                points[index++] = new Vector3(numGridLines * gridSize, 0f, pos);

                // Vertical line
                points[index++] = new Vector3(pos, 0f, 0f);
                points[index++] = new Vector3(pos, 0f, numGridLines * gridSize);
            }

            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
        }
    }
}