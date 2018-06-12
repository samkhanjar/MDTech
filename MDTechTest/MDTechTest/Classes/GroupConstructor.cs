using System.Collections.Generic;
using System.Linq;

namespace MDTechTest.Classes
{
    /// <summary>
    /// Uses a PatientMatrix and a single member of a group to locate the other members in the same group
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GroupConstructor<T>
    {
        private readonly PatientMatrix<bool> _visited;
        private readonly PatientMatrix<T> _matrix;

        // Class constructor
        public GroupConstructor(PatientMatrix<T> matrix, PatientMatrix<bool> visited)
        {
            _visited = visited;
            _matrix = matrix;
        }

        // The recursive part of the algorithm
        private void Construct(List<Coordinate> group, Coordinate current)
        {
            _visited[current] = true;

            // Gets all adjacent coordinates that not recently visited
            var nextCoordinates = _matrix.GetEqualAdjacentCoordinates(current).Where(c => !_visited[c]);

            // Loop through all coordinates, add them to list and 
            // recursivly locate other memebers in the same group   
            foreach (var next in nextCoordinates)
            {
                group.Add(next);
                Construct(group, next);
            }
        }

        public Group Construct(Coordinate seed)
        {
            var groupCoordinates = new List<Coordinate> { seed };
            Construct(groupCoordinates, seed);

            return new Group(groupCoordinates);
        }
    }
}
