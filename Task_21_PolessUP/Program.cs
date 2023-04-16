using System.Drawing;

int ax1 = -3, ay1 = 0, ax2 = 3, ay2 = 4, bx1 = 0, by1 = -1, bx2 = 9, by2 = 2;
Console.WriteLine($"Ввод: ax1 = {ax1}, ay1 = {ay1}, ax2 = {ax2}, ay2 = {ay2}, bx1 = {bx1}, by1 = {by1}, bx2 = {bx2}, by2 = {by2}");
Console.WriteLine("Вывод: " + SquareTwoRectangles(ax1, ay1, ax2, ay2, bx1, by1, bx2, by2));

// Плохо работает с большими числами
int SquareTwoRectangles(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
{
    DecartToScreen(ref ax1, ref ay1);
    DecartToScreen(ref ax2, ref ay2);
    DecartToScreen(ref bx1, ref by1);
    DecartToScreen(ref bx2, ref by2);
    Rectangle a = new Rectangle(ax1, ay2, Math.Abs(ax1 - ax2), Math.Abs(ay1 - ay2));
    Rectangle b = new Rectangle(bx1, by2, Math.Abs(bx1 - bx2), Math.Abs(by1 - by2));
    Rectangle rectanglesintersection = Rectangle.Intersect(a, b);
    if (rectanglesintersection.IsEmpty)
        return a.Height * a.Width + b.Height * b.Width;

    return a.Height * a.Width + b.Height * b.Width - rectanglesintersection.Height * rectanglesintersection.Width;
}

void DecartToScreen(ref int x, ref int y)
{
    int width = Console.LargestWindowWidth;
    int height = Console.LargestWindowHeight;
    x = x + width / 2;
    y = height / 2 - y;
}