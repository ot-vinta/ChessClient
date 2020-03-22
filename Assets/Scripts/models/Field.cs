using UnityEngine;

namespace models
{
    public class Field
    {
        public static Vector2Int FieldCenter;
        public char[,] Cells;

        public Field(char[,] cells)
        {
            FieldCenter = new Vector2Int(cells.GetLength(0) - 1, 
                                         cells.GetLength(1) - 1);
            Cells = cells;
        }
    }
}