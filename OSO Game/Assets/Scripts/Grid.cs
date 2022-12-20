using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private enum osoValues 
    {
        EMPTY,
        SYMBOL_O,
        SYMBOL_S
    }
    private osoValues[,] grid;

    public Grid()
    {
        grid = new osoValues[5, 5];
        InitGrid(5);
    }
    public Grid(int gridSize)
    {
        grid = new osoValues[gridSize, gridSize];
        InitGrid(gridSize);
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
            if(IsOSO(grid[i, j], grid[i, j+1], grid[i, j+2]))
            {
                numOSOs++;
            }
            // Vertical OSO
            if(IsOSO(grid[i, j], grid[i+1, j], grid[i+2, j]))
            {
                numOSOs++;
            }
            // Diagonal oso
            if(IsOSO(grid[i, j], grid[i+1, j+1], grid[i+2, j+2]))
            {
                numOSOs++;
            }
        } 
        
        return numOSOs;
    }

    private bool IsOSO(osoValues a, osoValues b, osoValues c)
    {
        bool b_oso = false;
        if (a == osoValues.SYMBOL_O && b == osoValues.SYMBOL_S && c == osoValues.SYMBOL_O)
        {
            b_oso = true;
        }
        return b_oso;
    }

}
