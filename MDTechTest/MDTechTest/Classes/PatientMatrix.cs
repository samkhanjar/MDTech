using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MDTechTest.Classes
{
    /// <summary>
    /// Implements IEnumerable<Coordinate> to allow for easy enumeration of all coordinates. 
    /// Contains helper methods for getting adjacent coordinates
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PatientMatrix<T> : IEnumerable<Coordinate>
    {
        // Get number of rows and columns 
        public int Rows { get { return _values.GetLength(0); } }
        public int Columns { get { return _values.GetLength(1); } }

        public T this[Coordinate coordinate]
        {
            get { return _values[coordinate.X, coordinate.Y]; }
            set { _values[coordinate.X, coordinate.Y] = value; }
        }

        private readonly T[,] _values;

        // Overloading constructors. One takes two-dimentional array of any type 
        // and the other takes number of rows and columns 
        public PatientMatrix(T[,] values)
        {
            _values = values;
        }

        public PatientMatrix(int rows, int columns)
        {
            _values = new T[rows, columns];
        }        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Coordinate> GetEnumerator()
        {
            for (var x = 0; x < Rows; x++)
            {
                for (var y = 0; y < Columns; y++)
                {
                    yield return new Coordinate(x, y);
                }
            }
        }

        public IEnumerable<Coordinate> GetEqualAdjacentCoordinates(Coordinate coordinate)
        {
            return GetAdjacentCoordinates(coordinate).Where(a => this[a].Equals(this[coordinate]));
        }

        // Get adjacent coordinates in any direction (vertical, horizontal and oblique)
        public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate)
        {
            var adjacent = new[]
            {
                // Get all 8 adjacent corrrdinates 
                new Coordinate(coordinate.X, coordinate.Y + 1),
                new Coordinate(coordinate.X, coordinate.Y - 1),
                new Coordinate(coordinate.X - 1, coordinate.Y + 1),
                new Coordinate(coordinate.X - 1, coordinate.Y),
                new Coordinate(coordinate.X - 1, coordinate.Y - 1),
                new Coordinate(coordinate.X + 1, coordinate.Y + 1),
                new Coordinate(coordinate.X + 1, coordinate.Y),
                new Coordinate(coordinate.X + 1, coordinate.Y - 1)
            };

            return adjacent.Where(InRange);
        }

        public bool InRange(Coordinate coordinate)
        {
            return coordinate.X >= 0 && coordinate.X < Rows && coordinate.Y >= 0 && coordinate.Y < Columns;
        }
    }
}
