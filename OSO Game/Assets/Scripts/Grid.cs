using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public enum osoValues 
    {
        EMPTY,
        SYMBOL_O,
        SYMBOL_S
    }
    private osoValues[,] grid;
    private int gridSize;
    

    public Grid()
    {
        grid = new osoValues[5, 5];
        InitGrid(5);
        this.gridSize = 5;
    }
    public Grid(int gridSize)
    {
        grid = new osoValues[gridSize, gridSize];
        InitGrid(gridSize);
        this.gridSize = gridSize;
    }

    private void InitGrid(int gridSize){
        for(int i = 0; i < gridSize; i++)
        {
            for(int j=0; j < gridSize; j++)
            {
                grid[i, j] = osoValues.EMPTY;
            }
        }
    }

    public int CheckOSOs(int i, int j){
        int numOSOs = 0;
        // Top left corner
        if(i == 0 && j == 0)
        {
            // Horizontal OSO
            numOSOs += IsOSO(grid[i, j], grid[i, j+1], grid[i, j+2]);
            // Vertical OSO
            numOSOs += IsOSO(grid[i, j], grid[i+1, j], grid[i+2, j]);
            // Diagonal oso
            numOSOs += IsOSO(grid[i, j], grid[i+1, j+1], grid[i+2, j+2]);
        }
        // Top right corner
        else if (i == 0 && j == gridSize)
        {
            // Horizontal
            numOSOs += IsOSO(grid[i, j-2], grid[i, j-1], grid[i, j]);
            // Vertical
            numOSOs += IsOSO(grid[i, j], grid[i+1, j], grid[i+2, j]);
            // Diagonal
            numOSOs += IsOSO(grid[i, j], grid[i+1, j-1], grid[i+2, j-2]);
        }
        // Bottom left corner
        else if (i == gridSize && j == 0)
        {
            // Horizontal
            numOSOs += IsOSO(grid[i, j], grid[i, j+1], grid[i, j+2]);
            // Vertical
            numOSOs += IsOSO(grid[i, j], grid[i-1, j], grid[i-2, j]);
            // Diagonal
            numOSOs += IsOSO(grid[i, j], grid[i-1, j+1], grid[i-2, j+2]);
        }
        // Bottom right corner
        else if (i == gridSize && j == gridSize)
        {
            // Horizontal
            numOSOs += IsOSO(grid[i, j], grid[i, j-1], grid[i, j-2]);
            // Vertical
            numOSOs += IsOSO(grid[i, j], grid[i-1, j], grid[i-2, j]);
            // Diagonal
            numOSOs += IsOSO(grid[i, j], grid[i-1, j-1], grid[i-2, j-2]);
        }
        // Anywhere else in the grid
        else 
        {
            // Horizontal
            numOSOs += IsOSO(grid[i, j-1], grid[i, j], grid[i, j+1]);
            // Vertical
            numOSOs += IsOSO(grid[i-1, j], grid[i, j], grid[i+1, j]);
            // Diagonals
            numOSOs += IsOSO(grid[i-1, j-1], grid[i, j], grid[i+1, j+1]);
            numOSOs += IsOSO(grid[i+1, j-1], grid[i, j], grid[i-1, j+1]);
        }
        return numOSOs;
    }

    private int IsOSO(osoValues a, osoValues b, osoValues c)
    {
        int b_oso = 0;
        if (a == osoValues.SYMBOL_O && b == osoValues.SYMBOL_S && c == osoValues.SYMBOL_O)
        {
            b_oso = 1;
        }
        return b_oso;
    }

    public void SetCell(int i, int j, osoValues value)
    {
        grid[i, j] = value;
    }

}
