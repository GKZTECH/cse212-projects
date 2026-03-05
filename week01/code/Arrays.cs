public static class Arrays
{
    
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    
     // This function creates an array of multiples of 'start'
    // 'count' defines how many multiples to generate
    
    public static double[] MultiplesOf(double number, int length)
    {
       // Step 1: Create a new array to hold the multiples
    double[] multiples = new double[length];

    // Step 2: Loop through 'length' times to fill the array
    for (int i = 0; i < length; i++)
    {
        // Step 3: Multiply number by (i + 1) to get each multiple
        multiples[i] = number * (i + 1);
    }

    // Step 4: Return the array containing all multiples
    return multiples;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    
    // This function rotates a list to the right by 'amount'
    // Elements that move past the end wrap around to the front
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the starting index of the rotated portion
        int startIndex = data.Count - amount;

        // Step 2: Get the last 'amount' elements that will move to the front
        List<int> rotatedPart = data.GetRange(startIndex, amount);

        // Step 3: Get the remaining elements that will shift to the back
        List<int> remainingPart = data.GetRange(0, startIndex);

        // Step 4: Clear the original list
        data.Clear();

        // Step 5: Add rotated elements first, then the remaining elements
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);
    }

    // Any other methods in this class remain unchanged
}