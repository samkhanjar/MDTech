using MDTechTest.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MDTechTestUnitTest
{
    [TestClass]
    public class GroupLocatorTests
    {        
        [TestMethod]
        public void Throws_if_matrix_is_null()
        {
            // Arrange
            var gl = new GroupLocator<int>(1);
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => gl.LocateGroups(null));
        }

        [TestMethod]
        public void Returns_empty_collection_if_matrix_is_empty()
        {
            // Arrange
            var gl = new GroupLocator<int>(1);
            var EmptyMatrix = new int[,] { };
            // Act
            List<Group> groups = gl.LocateGroups(EmptyMatrix);
            // Assert
            Assert.AreEqual(groups.Count, 0);
        }

        [TestMethod]
        public void Returns_collection_of_groups_of_three()
        {
            // Arrange
            var gl = new GroupLocator<int>(1);
            var PatientMatrix = new int[,] {
                { 1, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 1 },
                { 1, 1, 0, 1, 0, 0 }
            };

            // Act
            List<Group> groups = gl.LocateGroups(PatientMatrix);

            // Assert
            Assert.AreEqual(groups.Count, 3);
        }

        [TestMethod]
        public void Returns_collection_of_groups_of_four()
        {
            // Arrange
            var gl = new GroupLocator<int>(1);
            var PatientMatrix = new int[,] {
                { 1, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 0 }
            };

            // Act
            List<Group> groups = gl.LocateGroups(PatientMatrix);

            // Assert
            Assert.AreEqual(groups.Count, 4);
        }

        [TestMethod]
        public void Returns_collection_of_groups_of_five()
        {
            // Arrange
            var gl = new GroupLocator<int>(1);
            var PatientMatrix = new int[,] {
                { 1, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 0 }
            };

            // Act
            List<Group> groups = gl.LocateGroups(PatientMatrix);

            // Assert
            Assert.AreEqual(groups.Count, 5);
        }
    }
}
