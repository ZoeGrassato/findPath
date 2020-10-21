using System;

namespace findPathV2
{
    class Program
    {
        public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                          bool[,] mapMatrix)
        {
            var currentRow = fromRow;
            var currentCol = fromColumn;
            var hasReachedDestination = false;

            while (!hasReachedDestination)
            {
                var itemToRight = currentCol + 1 < mapMatrix.GetLength(0) ? mapMatrix[currentRow, currentCol + 1] : false;
                var itemToLeft = currentCol - 1 >= 0 ? mapMatrix[currentRow, currentCol - 1] : false; 
                var itemUp = currentRow -1 >= 0 ? mapMatrix[currentRow - 1, currentCol] : false;
                var itemDown = currentRow + 1 < mapMatrix.GetLength(0) ? mapMatrix[currentRow + 1, currentCol] : false;

                mapMatrix[currentRow, currentCol] = false;
                if (itemToLeft == true) currentCol -= 1;
                else if (itemToRight == true) currentCol += 1;
                else if (itemUp == true) currentRow -= 1;
                else if (itemDown == true) currentRow += 1;
                else return false;

                mapMatrix[currentRow, currentCol] = true;

                if (currentRow == toRow && currentCol == toColumn) hasReachedDestination = true;
            }
            return hasReachedDestination;
        }
        static void Main(string[] args)
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
