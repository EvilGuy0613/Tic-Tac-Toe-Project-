using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Net.Http.Headers;

Random Turn=new Random();
// Random Number Generator that will determine the order on who goes first. (Not implemented yet) 

bool Left1 = false, Center1 = false, Right1 = false, Up1 = false, Down1 = false, UpLeft1 = false, UpRight1 = false, DownLeft1 = false, DownRight1 = false;  
// Variables representing the Player's sqaures. Flase = NotPlayed && True == Played) 

Dictionary<string, bool> Player = new Dictionary<string, bool>
{
{ "Left", Left1 }, { "Center", Center1 }, { "Up", Up1 }, { "Down", Down1 }, { "Right", Right1 }, { "UpLeft", UpLeft1 }, 
{ "UpRight", UpRight1 }, { "DownLeft", DownLeft1 }, { "DownRight", DownRight1 }
}; 
//Pairing our bool variables to a text value based on the 9 square inputs. In this case, these hold the player's inputs

Dictionary<string, int> Directions = new Dictionary<string, int>()
{
{ "Left", 3 }, { "Center", 4 }, { "Up", 1 }, { "Down", 7 }, { "Right", 5}, { "UpLeft", 0 }, 
{ "UpRight", 2 }, { "DownLeft", 6 }, { "DownRight", 8 }
};

//Pairing our text values to a number. We will use these numbers to change some values based on if the Player or CPU filled in the Square. 


string PlayerPlayed= "[Player Square]"; //Variable to signify which squares have been filled by the Player. 
string CPUPlayed= "[CPU Square]"; //Variable to signify which squares have been filled by the CPU. (Not implemented yet) 

string [] vars = new string [9];

for (int i = 0; i < 9; i++) //This will create 9 variables with the value "Not Played" to signify the current condition of our squares
{
vars[i] = "[Not Played]";
}



for (;;) //The Game Begins! 

{

if (Player["Left"] && Player["Center"] && Player["Right"] || Player["UpLeft"] && Player["Up"] && Player["UpRight"] || Player["DownLeft"] && Player["Down"] && Player["DownRight"] ||
Player["UpLeft"] &&  Player["Left"] && Player["DownLeft"] || Player["Up"] && Player["Center"] && Player["Down"] || Player["UpRight"] && Player["Right"] && Player["DownRight"] ||
Player["UpLeft"] && Player["Center"] && Player["DownRight"] || Player["UpRight"] && Player["Center"] && Player["DownLeft"])

//The Player meets 1 of the 8 winning conditions and wins the game!

{ 

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Tic Tac Toe, three in a row! You Win!");

Console.ForegroundColor = ConsoleColor.White; //Displays the final results 
Console.WriteLine($"UpLeft {vars[0]}    Up Square {vars[1]}    Up Right {vars[2]}\n" +
                  $"Left Square {vars[3]}   Center Square {vars[4]}   Right Square {vars[5]}\n" +
                  $"DownLeft Square {vars[6]}   Down Square {vars[7]}   DownRight Square {vars[8]}");

Console.ReadKey();

break; 

}


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("It's Your Turn!");
Console.ReadKey();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Choose a Square");
Console.ReadKey();

Console.WriteLine($"UpLeft {vars[0]}    Up Square {vars[1]}    Up Right {vars[2]}\n" +
                  $"Left Square {vars[3]}   Center Square {vars[4]}   Right Square {vars[5]}\n" +
                  $"DownLeft Square {vars[6]}   Down Square {vars[7]}   DownRight Square {vars[8]}");

//Shows the current status of the game


Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Left,Right,Center,Up,Down,UpLeft,UpRight,DownLeft,DownRight");
string Playerinput = Console.ReadLine();

//The Player inputs the square they wish to play on 
    
    if (Player.ContainsKey(Playerinput) && Player[Playerinput]) //If Player inputs a sqaure that is filled in already, they will be prompted that the square is filled in. 

    {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{Playerinput} is already filled!");
    Console.ReadKey();
     
    }
    
    else if(Player.ContainsKey(Playerinput)) //The Player inputs a square that is not played on 
    
    {
    Player[Playerinput] = true;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"You choose the {Playerinput} Square!");
    Console.ReadKey();
    int index = Directions [Playerinput];
    vars[index] = PlayerPlayed;
    } //After the status of the squared being played will update to [Player Square] signifying this square is taken
    
    else //Input doesn't match any keywords 
    {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Invaild Input!");
    Console.ReadKey();
    }
}




    
    
    
  