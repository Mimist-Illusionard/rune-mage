using UnityEngine;
using UnityEngine.UI;


public class FlexibleLayoutGroup : LayoutGroup
{
    public int Rows;
    public int Colums;
    public Vector2 CellSize;
    public Vector2 Spacing;

    public bool ConstantRows;
    public bool ConstantColums;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float sqrt = Mathf.Sqrt(transform.childCount);
        if (!ConstantRows) Rows = Mathf.CeilToInt(sqrt);
        if (!ConstantColums) Colums = Mathf.CeilToInt(sqrt);

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        var flColums = (float)Colums;
        var flRows = (float)Rows;

        float cellWidth = parentWidth / flColums - ((Spacing.x / flColums) * 2) - (padding.left / flColums) - (padding.right / flColums);
        float cellHeight = parentHeight / flRows - ((Spacing.y / flRows) * 2) - (padding.top / flRows) - (padding.bottom / flRows);

        CellSize.x = cellWidth;
        CellSize.y = cellHeight;

        int columsCount = 0;
        int rowsCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowsCount = i / Colums;
            columsCount = i % Colums;

            if (ConstantRows && transform.childCount > Colums * Rows) rowsCount = i / Colums + 1;

            var item = rectChildren[i];

            var xPos = (CellSize.x * columsCount) + (Spacing.x * columsCount) + padding.left;
            var yPos = (CellSize.y * rowsCount) + (Spacing.y * rowsCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, CellSize.x);
            SetChildAlongAxis(item, 1, yPos, CellSize.y);
        }
    }

    public override void CalculateLayoutInputVertical()
    {
        
    }

    public override void SetLayoutHorizontal()
    {
        
    }

    public override void SetLayoutVertical()
    {
        
    }    
}
