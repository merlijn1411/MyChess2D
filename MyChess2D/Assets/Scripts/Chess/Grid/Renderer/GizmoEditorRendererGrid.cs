using UnityEngine;

public class GizmoEditorRendererGrid : GridRenderer
{
    private void OnDrawGizmos()
    {
        if (gridManager.gridRenderMask != GridRenderMask.GizmoEditorRenderer) return;
        Gizmos.color = Color.white;

        var pos0 = new Vector3();
        var pos1 = new Vector3();

        for (var x = 0; x < gridManager.width; x++)
        {
            pos0.x = gridManager.width * gridManager.cellSize;
            pos0.y = x * gridManager.cellSize;
            pos1.x = 0;
            pos1.y = x * gridManager.cellSize;
            Gizmos.DrawLine(pos0,pos1);
        }
        
        for (var z = 0; z < gridManager.height; z++)
        {
            pos0.x = z * gridManager.cellSize;
            pos0.y = gridManager.height  * gridManager.cellSize;
            pos1.x = z * gridManager.cellSize;
            pos1.y = 0;
            Gizmos.DrawLine(pos0,pos1);
        }


    }
}
