namespace MDTechTest.Classes
{
    /// <summary>
    /// two-dimentional coordinate used by PatientMatrix and Group
    /// </summary>
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
