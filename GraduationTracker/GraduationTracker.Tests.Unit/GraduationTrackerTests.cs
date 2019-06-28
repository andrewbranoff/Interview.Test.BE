using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

//Removed unused using statements in all files

namespace GraduationTracker.Tests.Unit {
    [TestClass]
    public class GraduationTrackerTests {
        [TestMethod]
        public void TestGraduated() {
            var tracker = new GraduationTracker();
            var diploma = Repository.GetDiploma(1);
            var students = new List<Student> {
                Repository.GetStudent(1),
                Repository.GetStudent(2),
                Repository.GetStudent(3),
                Repository.GetStudent(4)
            };

            var graduated = students.Select(student => tracker.HasGraduated(diploma, student)).ToList();

            //Previous test was asserting the list of graduating students would be empty (blank test for any asserted false) - possible only if student list was blank
            Assert.IsTrue(graduated.All(e => e.Item1)); //Test that all students in this group graduated
        }

        [TestMethod]
        public void TestNotGraduated() {
            var tracker = new GraduationTracker();
            var diploma = Repository.GetDiploma(1);
            var students = new List<Student> {
                Repository.GetStudent(5),
                Repository.GetStudent(6),
                Repository.GetStudent(7)
            };

            var notGraduated = students.Select(student => tracker.HasGraduated(diploma, student)).ToList();

            Assert.IsFalse(notGraduated.Any(e => e.Item1)); //Test that there are no students in this group that have graduated
        }
    }
}