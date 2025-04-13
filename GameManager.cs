using UnityEngine;

using System;

public class GameManager
{
    private Connect4Board theBoard;

    public GameManager()
    {
        this.theBoard = new Connect4Board();
    } 

    public void play()
{
    System.Random rand = new System.Random();
    
    string[] colors = { "R", "B" };
    string[] colorNames = { "Red", "Blue" };
    bool gameEnded = false;
    int moveCount = 0;
    
    Console.WriteLine("Starting Connect4 Game!");
    Console.WriteLine("R = Red, B = Blue");
    
    while (!gameEnded && moveCount < 42) // 42 is max possible moves (6x7 board)
    {
        this.theBoard.display();
        Console.WriteLine($"Move #{moveCount+1}: {colorNames[moveCount%2]}'s turn");
        
        MoveResult result;
        do
        {
            int column = rand.Next(0, 7);
            Console.WriteLine($"Attempting move in column {column}");
            result = this.theBoard.makeMove(column, colors[moveCount%2]);
        }
        while(!result.success);

        Console.WriteLine($"Placed {colorNames[moveCount%2]} checker in column {result.column}, row {result.row}");
        moveCount++;
        
        //check if the move resulted in a win
        if(this.theBoard.isWinner(result))
        {
            this.theBoard.display();
            Console.WriteLine($"GAME OVER! {colorNames[(moveCount-1)%2]} wins in {moveCount} moves!");
            gameEnded = true;
        }
        else if(moveCount >= 42)
        {
            this.theBoard.display();
            Console.WriteLine("GAME OVER! It's a draw!");
            gameEnded = true;
        }
    }
    
    if(!gameEnded)
    {
        this.theBoard.display();
        Console.WriteLine("Game ended without a winner.");
    }
}
}