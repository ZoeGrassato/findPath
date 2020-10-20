using System;
using System.Collections.Generic;

namespace findPath
{
    public class RoutePlanner
    {
        public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                          bool[,] mapMatrix)
        {
            var currentRow = fromRow;
            var currentCol = fromColumn;
            for (int i = 0; i < Math.Abs(fromRow - toRow); i++)
            {
                var nextAvailableStep = FindNextClosestStep(mapMatrix, currentRow, currentCol, toRow, toColumn);
                var canDoRowShift = Math.Abs(nextAvailableStep.Key - currentRow) <= 1 && Math.Abs(nextAvailableStep.Value - currentCol) == 0 ? true : false;
                var canDoColShift = Math.Abs(nextAvailableStep.Key - currentRow) == 0 && Math.Abs(nextAvailableStep.Value - currentCol) <= 1 ? true : false;

                if (canDoRowShift || canDoColShift)
                {
                    if (currentRow == toRow && currentCol == toColumn) return true;
                    currentRow = nextAvailableStep.Key;
                    currentCol = nextAvailableStep.Value;
                } 
            }

            return false;
        }

        public static KeyValuePair<int,int> FindNextClosestStep(bool[,] matrix, int fromRow, int fromColumn, int toRow, int toColumn)
        {
            var final = new KeyValuePair<int, int>();

            for (int i = fromRow + 1; i <= toRow; i++)
            {
                for(int j = fromColumn + 1; j <= toColumn; j++)
                {
                    if(matrix[i,j] == true)
                    {
                        final = new KeyValuePair<int, int>(i, j);
                        return final;
                    }
                }
            }
            return final;
        }

        public static void Main(string[] args)
        {
            bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };

            Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
        }
    }
}
