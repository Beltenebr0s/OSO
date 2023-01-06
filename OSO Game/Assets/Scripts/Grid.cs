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
    public int gridSize { get; set; }
    

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

    private void InitGrid(int gridSize)
    {
        for(int i = 0; i < gridSize; i++)
        {
            for(int j=0; j < gridSize; j++)
            {
                grid[i, j] = osoValues.EMPTY;
            }
        }
    }

    public int CheckOSOs(int i, int j, osoValues selectedValue)
    {
        int numOSOs = 0;
        // If the symbol is a O
        if(selectedValue == osoValues.SYMBOL_O)
            // Check if the selected cell is in the border
            if(i <= 1 || i == gridSize-1 || j <= 1 || j == gridSize-1)
            {
                numOSOs += CheckOSOsInBorder(i, j);
            }
            else 
            {
                // Horizontal
                numOSOs += IsOSO(grid[i, j], grid[i, j+1], grid[i, j+2]);
                numOSOs += IsOSO(grid[i, j], grid[i, j-1], grid[i, j-2]);
                // Vertical
                numOSOs += IsOSO(grid[i-1, j], grid[i, j], grid[i+1, j]);
                // Diagonals
                numOSOs += IsOSO(grid[i-1, j-1], grid[i, j], grid[i+1, j+1]);
                numOSOs += IsOSO(grid[i+1, j-1], grid[i, j], grid[i-1, j+1]);
            }
        // If the symbol is a S
        else 
        {
            // If it's in the border, it's impossible to create an OSO, so check if it's anywhere else
            if(!(i == 0 || i == gridSize-1 || j == 0 || j == gridSize-1))
            {
                // Horizontal
                numOSOs += IsOSO(grid[i, j-1], grid[i, j], grid[i, j+1]);
                // Vertical
                numOSOs += IsOSO(grid[i-1, j], grid[i, j], grid[i+1, j]);
                // Diagonals
                numOSOs += IsOSO(grid[i-1, j-1], grid[i, j], grid[i+1, j+1]);
                numOSOs += IsOSO(grid[i+1, j-1], grid[i, j], grid[i-1, j+1]);
            }
        }
        Debug.Log("OSOs en este turno: " + numOSOs);
        return numOSOs;
    }

    public int CheckOSOsInBorder(int i, int j)
    {
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
        // Top row
        else if (i == 0)
        {
            // Horizontal OSO
            numOSOs += IsOSO(grid[i, j-1], grid[i, j], grid[i, j+1]);
            // Vertical OSO
            numOSOs += IsOSO(grid[i, j], grid[i+1, j], grid[i+2, j]);
            // Diagonal osos
            // If it's the second column, only diagonal to the bottom right can be done
            if(j == 1)
                numOSOs += IsOSO(grid[i, j], grid[i+1, j+1], grid[i+2, j+2]);
            // If it'ts the second last column, only diagonal to the bottom left
            else if(j == gridSize-2)
                numOSOs += IsOSO(grid[i, j], grid[i+1, j-1], grid[i+2, j-2]);
            // Anywhere else, try both diagonals
            else
            {
                numOSOs += IsOSO(grid[i, j], grid[i+1, j+1], grid[i+2, j+2]);
                numOSOs += IsOSO(grid[i, j], grid[i+1, j-1], grid[i+2, j-2]);
            }
        }
        // Bottom row
        else if (i == gridSize-1)
        {
            // Horizontal OSO
            numOSOs += IsOSO(grid[i, j-1], grid[i, j], grid[i, j+1]);
            // Vertical OSO
            numOSOs += IsOSO(grid[i, j], grid[i-1, j], grid[i-2, j]);
            // Diagonal osos
            // If it's the second column, only diagonal to the top right can be done
            if(j == 1)
                numOSOs += IsOSO(grid[i, j], grid[i-1, j+1], grid[i-2, j+2]);
            // If it'ts the second last column, only diagonal to the top left
            else if(j == gridSize-2)
                numOSOs += IsOSO(grid[i, j], grid[i-1, j-1], grid[i-2, j-2]);
            // Anywhere else, try both diagonals
            else
            {
                numOSOs += IsOSO(grid[i, j], grid[i-1, j+1], grid[i-2, j+2]);
                numOSOs += IsOSO(grid[i, j], grid[i-1, j-1], grid[i-2, j-2]);
            }
        }
        // Left column
        else if (j == 0)
        {
            // Horizontal OSO
            numOSOs += IsOSO(grid[i, j], grid[i, j+1], grid[i, j+2]);
            // Vertical OSO
            numOSOs += IsOSO(grid[i-1, j], grid[i, j], grid[i+1, j]);
            // Diagonal osos
            // If it's the second row, only diagonal to the bottom right can be done
            if(i == 1)
                numOSOs += IsOSO(grid[i, j], grid[i+1, j+1], grid[i+2, j+2]);
            // If it'ts the second last row, only diagonal to the top right
            else if(i == gridSize-2)
                numOSOs += IsOSO(grid[i, j], grid[i-1, j+1], grid[i-2, j+2]);
            // Anywhere else, try both diagonals
            else
            {
                numOSOs += IsOSO(grid[i, j], grid[i+1, j+1], grid[i+2, j+2]);
                numOSOs += IsOSO(grid[i, j], grid[i-1, j+1], grid[i-2, j+2]);
            }
        }
        // Right column
        else if (j == gridSize-2)
        {
            // Horizontal OSO
            numOSOs += IsOSO(grid[i, j], grid[i, j-1], grid[i, j-2]);
            // Vertical OSO
            numOSOs += IsOSO(grid[i-1, j], grid[i, j], grid[i+1, j]);
            // Diagonal osos
            // If it's the second row, only diagonal to the bottom left can be done
            if(i == 1)
                numOSOs += IsOSO(grid[i, j], grid[i+1, j-1], grid[i+2, j-2]);
            // If it'ts the second last row, only diagonal to the top left
            else if(i == gridSize-2)
                numOSOs += IsOSO(grid[i, j], grid[i-1, j-1], grid[i-2, j-2]);
            // Anywhere else, try both diagonals
            else
            {
                numOSOs += IsOSO(grid[i, j], grid[i+1, j-1], grid[i+2, j-2]);
                numOSOs += IsOSO(grid[i, j], grid[i-1, j-1], grid[i-2, j-2]);
            }
        }
        return numOSOs;
    }

    private int IsOSO(osoValues a, osoValues b, osoValues c)
    {
        int n_oso = 0;
        if (a == osoValues.SYMBOL_O && b == osoValues.SYMBOL_S && c == osoValues.SYMBOL_O)
        {
            n_oso = 1;
        }
        return n_oso;
    }

    public void SetCell(int i, int j, osoValues value)
    {
        grid[i, j] = value;
        CheckOSOs(i, j, value);
    }

    public bool IsCellEmpty(int i, int j)
    {
        bool empty = grid[i, j] == osoValues.EMPTY;
        return empty;
    }

    public bool IsGridFull()
    {
        bool gridFull = false;
        for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                if(grid[i, j] != osoValues.EMPTY)
                {
                    gridFull = true;
                }
            }
        }
        return gridFull;
    }
}
