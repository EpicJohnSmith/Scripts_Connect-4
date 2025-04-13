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
        //check to see if result was involved in a horizontal win
        //check to see if result was involved in a vertical win
        //check to see if result was involved in a diagonal win
        //return true if yes, and false if no
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
