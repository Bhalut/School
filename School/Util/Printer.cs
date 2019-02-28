using static System.Console;

namespace CoreSchool.Util
{
    public static class Printer
    {
        public static void DrawLine(int size = 45)
        {
            WriteLine("".PadLeft(size, '-'));
        }

        public static void WriteTitle(string title)
        {
            int size = title.Length + 4;
            DrawLine(size);
            WriteLine($"| {title} |");
            DrawLine(size);
        }
    }
}