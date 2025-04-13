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
        
        //make 10 random moves for testing
        for(int i = 0; i < 10; i++)
        {
            this.theBoard.display();
            MoveResult result;
            do
            {
                result = this.theBoard.makeMove(rand.Next(0, 7), colors[i%2]);
            }
            while(!result.success);
    
            //we have a successful move
            //check to see if that move was involved in a winning move!!!!
            if(this.theBoard.isWinner(result))
            {
                //we have a winner, announce it or whatever and end the game
            }
        }
        Console.WriteLine("Play Function in GameManager");
        


        
    }
}
