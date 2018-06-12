using System;
using System.Collections.Generic;

namespace MDTechTest.Classes
{
    /// <summary>
    /// Get list of x and y coordinates for a given group
    /// </summary>    
    public class Group
    {
        public List<Coordinate> Coordinates { get; set; }

        public Group(List<Coordinate> coordinates)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException("coordinates");
            }

            Coordinates = coordinates;
        }
    }
}
