/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
int examAssignments = 5;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

decimal[] extraCreditScores = new decimal[] { 92, 89, 89, 96 }; // Extra credit scores for each student

int[] studentScores = new int[10];

Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit");

foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;
    else if (currentStudent == "Andrew")
        studentScores = andrewScores;
    else if (currentStudent == "Emma")
        studentScores = emmaScores;
    else if (currentStudent == "Logan")
        studentScores = loganScores;

    int sumAssignmentScores = 0;
    decimal currentStudentGrade = 0;
    int gradedAssignments = 0;

    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
            sumAssignmentScores += score;
        else
            sumAssignmentScores += score / 10;
    }

    currentStudentGrade = (decimal)sumAssignmentScores / examAssignments;

    decimal totalExtraCredit = extraCreditScores[Array.IndexOf(studentNames, currentStudent)];

    decimal examScore = currentStudentGrade;
    decimal overallGrade = examScore + totalExtraCredit;

    string letterGrade = "";
    if (currentStudentGrade >= 97)
        letterGrade = "A+";
    else if (currentStudentGrade >= 93)
        letterGrade = "A";
    else if (currentStudentGrade >= 90)
        letterGrade = "A-";
    else if (currentStudentGrade >= 87)
        letterGrade = "B+";
    else if (currentStudentGrade >= 83)
        letterGrade = "B";
    else if (currentStudentGrade >= 80)
        letterGrade = "B-";
    else if (currentStudentGrade >= 77)
        letterGrade = "C+";
    else if (currentStudentGrade >= 73)
        letterGrade = "C";
    else if (currentStudentGrade >= 70)
        letterGrade = "C-";
    else if (currentStudentGrade >= 67)
        letterGrade = "D+";
    else if (currentStudentGrade >= 63)
        letterGrade = "D";
    else if (currentStudentGrade >= 60)
        letterGrade = "D-";
    else
        letterGrade = "F";

    Console.WriteLine($"{currentStudent,-15}{examScore,-15:F2}{overallGrade,-15:F2}{totalExtraCredit,-5:F2} ({extraCreditScores[Array.IndexOf(studentNames, currentStudent)],-5:F2} pts) {letterGrade}");
}

Console.WriteLine("\nPress the Enter key to continue");
Console.ReadLine();

