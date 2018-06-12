using System;
using System.Collections.Generic;
using System.Linq;

namespace MDTechTest.Classes
{
    /// <summary>
    /// This algorithm can locate groups of any value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GroupLocator<T>
    {
        private readonly T _groupValue;

        // Class constructor
        public GroupLocator(T groupValue)
        {
            _groupValue = groupValue;
        }

        // Generic method which can take a a two-dimentional array of any type
        public List<Group> LocateGroups(T[,] matrix)
        {
            // If matrix is null then return null exception
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }

            // Locate groups
            return LocateGroups(new PatientMatrix<T>(matrix));
        }

        private List<Group> LocateGroups(PatientMatrix<T> matrix)
        {
            var groups = new List<Group>();
            var visited = new PatientMatrix<bool>(matrix.Rows, matrix.Columns);

            // loop through all coordinates in matrix that are not yet visited
            foreach (var coordinate in matrix.Where(c => !visited[c]))
            {
                // assign visited flag for this coordinates to true
                visited[coordinate] = true;

                // Determines whether the specified object equals to the current object  
                if (!matrix[coordinate].Equals(_groupValue))
                    continue;

                // Construct the group and add it to the generic list.
                var group = new GroupConstructor<T>(matrix, visited).Construct(coordinate);
                groups.Add(group);
            }
            // return group list
            return groups;
        }
    }
}
