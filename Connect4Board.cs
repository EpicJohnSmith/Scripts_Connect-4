using System;

public class Connect4Board
{
    private Checker[,] theBoard;
    private int rows = 6;
    private int columns = 7;

    public Connect4Board()
    {
        this.theBoard = new Checker[this.rows, this.columns];
    }
    
    public  void display()
    {
        for (int row = 0; row < this.rows; row++)
        {
            for (int col = 0; col < this.columns; col++)
            {
                Console.Write(this.theBoard[row, col] == null ? "_" : this.theBoard[row,col].GetColor());
                Console.Write(" "); // Add space between cells
            }
            Console.WriteLine(); // New line after each row
        }
    }

    public bool isWinner(MoveResult result)
{
    if (!result.success || result.row < 0 || result.column < 0)
    {
        return false; // Invalid move
    }

    string color = result.color;
    int row = result.row;
    int col = result.column;
    
    // Check horizontal win (left to right)
    int count = 0;
    for (int c = Math.Max(0, col - 3); c < Math.Min(columns, col + 4); c++)
    {
        if (c >= 0 && c < columns && theBoard[row, c] != null && theBoard[row, c].GetColor() == color)
        {
            count++;
            if (count >= 4) return true;
        }
        else
        {
            count = 0;
        }
    }
    
    // Check vertical win (top to bottom)
    count = 0;
    for (int r = Math.Max(0, row - 3); r < Math.Min(rows, row + 4); r++)
    {
        if (r >= 0 && r < rows && theBoard[r, col] != null && theBoard[r, col].GetColor() == color)
        {
            count++;
            if (count >= 4) return true;
        }
        else
        {
            count = 0;
        }
    }
    
    // Check diagonal (top-left to bottom-right)
    count = 0;
    for (int i = -3; i <= 3; i++)
    {
        int r = row + i;
        int c = col + i;
        
        if (r >= 0 && r < rows && c >= 0 && c < columns && 
            theBoard[r, c] != null && theBoard[r, c].GetColor() == color)
        {
            count++;
            if (count >= 4) return true;
        }
        else
        {
            count = 0;
        }
    }
    
    // Check diagonal (top-right to bottom-left)
    count = 0;
    for (int i = -3; i <= 3; i++)
    {
        int r = row + i;
        int c = col - i;
        
        if (r >= 0 && r < rows && c >= 0 && c < columns && 
            theBoard[r, c] != null && theBoard[r, c].GetColor() == color)
        {
            count++;
            if (count >= 4) return true;
        }
        else
        {
            count = 0;
        }
    }
    
    return false;
}
    
    public MoveResult makeMove(int column, string color)
    {
        MoveResult result = new MoveResult();

        if(column < 0 || column > this.columns - 1)
        {
            return result; // Invalid column
        }

        if(this.theBoard[0,column] != null)
        {
            return result; // Column is full
        }

        //a legal move and room for a new checker, so drop the checker onto the board
        for (int i = this.rows - 1; i >= 0; i--)
        {
            if (this.theBoard[i,column] == null)
            {
                this.theBoard[i,column] = new Checker(color); // Assuming "Red" is the color of the checker
                result.success = true;
                result.row = i;
                result.column = column;
                result.color = color;
                break;
            }
        }
        return result;
    }
}
