public struct Point
{
    /// <summary>
    /// Inintializes a new instance of the <see cref="x"/> and <see cref="y"/>.
    /// </summary>
    /// <param name="x">The x-axis coordinate.</param>
    /// <param name="y">The y-axis coordinate.</param>
    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    /// <summary>
    /// The X coordinate of the point.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// The Y coordinate of the point.
    /// </summary>
    public int Y { get; set; }
}
