using UnityEngine;

public class LineRendererGrid : GridRenderer
{
    private Material _lineMaterial;
     
    public override void CreateGrid(Vector3 worldPosition, float cellSize,Material lineMaterial)
    {
        _lineMaterial = lineMaterial;
        
        if (gridManager.gridRenderMask != GridRenderMask.LineRenderer) return;
        var drawX = worldPosition.x * cellSize;
        var drawY = worldPosition.y * cellSize;
        
        //draw vertical line
        DrawLine(new Vector3(drawX, 0, 0), new Vector3(drawX, drawY, 0));
        
        //draw horizontal line
        DrawLine(new Vector3(0, drawY, 0), new Vector3(drawX, drawY, 0));
        
    }
    
    private void DrawLine(Vector3 start, Vector3 end)
    {
        var lineObject = new GameObject("Line");
        var lineRenderer = lineObject.AddComponent<LineRenderer>();

        lineRenderer.material = _lineMaterial;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
    
}
