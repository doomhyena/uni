namespace _01_oop_alapjai;

public enum GradeType
{
    Elégtelen,
    Elégséges,
    Közepes,
    Jó,
    Jeles
}

public class ExamResult
{
    private static readonly Random random = new();
    private string neptunCode = "";
    private int score;

    public string NeptunCode
    {
        get => neptunCode;
        set
        {
            if (value != null && value.Length == 6)
            {
                neptunCode = value;
            }
        }
    }

    public int Score
    {
        get => score;
        set
        {
            if (value >= 0 && value <= 100)
            {
                score = value;
            }
        }
    }

    public bool Passed => Score >= 50;

    public ExamResult(string neptunCode, int score)
    {
        NeptunCode = neptunCode;
        Score = score;
    }

    public ExamResult()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] code = new char[6];
        for (int i = 0; i < 6; i++)
        {
            code[i] = chars[random.Next(chars.Length)];
        }
        NeptunCode = new string(code);
        Score = random.Next(0, 101);
    }

    public GradeType Grade(int[] limits)
    {
        if (Score >= limits[4]) return GradeType.Jeles;
        if (Score >= limits[3]) return GradeType.Jó;
        if (Score >= limits[2]) return GradeType.Közepes;
        if (Score >= limits[1]) return GradeType.Elégséges;
        return GradeType.Elégtelen;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Kérem N értékét: ");
        int n = int.Parse(Console.ReadLine()!);

        List<ExamResult> results = new();
        for (int i = 0; i < n; i++)
        {
            results.Add(new ExamResult());
        }

        Console.WriteLine("\nSikeres dolgozatok Neptun-kódjai:");
        foreach (var result in results)
        {
            if (result.Passed)
            {
                Console.WriteLine(result.NeptunCode);
            }
        }

        if (results.Count > 0)
        {
            double average = results.Average(r => r.Score);
            Console.WriteLine($"\nÁtlagpontszám: {average:F2}");

            var maxResult = results.MaxBy(r => r.Score);
            Console.WriteLine($"Legmagasabb pontszámhoz tartozó Neptun-kód: {maxResult?.NeptunCode} ({maxResult?.Score} pont)");
        }
    }
}
