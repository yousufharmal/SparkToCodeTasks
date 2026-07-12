namespace Task_5___Collections;

class Program
{
    static void Main(string[] args)
    {
        
        // Task 1 - Fixed Grades Array ///
        int[] grades = new int[5];

        
        for (int i = 0; i < grades.Length; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            grades[i] = Convert.ToInt32(Console.ReadLine());
        }

        
        Console.WriteLine("\nStudent Grades:");
        foreach (int grade in grades)
        {
            Console.WriteLine(grade);
        }
    }
}