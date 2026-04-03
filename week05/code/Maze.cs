// DO NOT MODIFY THIS FILE

public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
{
    if (currPath == null)
    {
        currPath = new List<ValueTuple<int, int>>();
    }

    // Add current position
    currPath.Add((x, y));

    // Check if end
    if (maze.IsEnd(x, y))
    {
        results.Add(currPath.AsString());
        currPath.RemoveAt(currPath.Count - 1);
        return;
    }

    // Directions: Right, Down, Left, Up
    int[,] directions = {
        {1, 0},
        {0, 1},
        {-1, 0},
        {0, -1}
    };

    for (int i = 0; i < 4; i++)
    {
        int newX = x + directions[i, 0];
        int newY = y + directions[i, 1];

        // Fix other
        if (maze.IsValidMove(currPath, newX, newY))
        {
            SolveMaze(results, maze, newX, newY, currPath);
        }
    }

    // Backtrack
    currPath.RemoveAt(currPath.Count - 1);
}    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }


    /// <summary>
    /// Helper function to determine if the (x,y) position is a valid
    /// place to move given the size of the maze, the content of the maze,
    /// and the current path already traversed.
    /// </summary>
    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        // Can't go outside of the maze boundary (assume maze is a square)
        if (x > Width - 1 || x < 0)
            return false;
        if (y > Height - 1 || y < 0)
            return false;
        // Can't go through a wall
        if (Data[y * Height + x] == 0)
            return false;
        // Can't go if we have already been there (don't go in circles)
        if (currPath.Contains((x, y)))
            return false;
        // Otherwise, we are good
        return true;
    }
}