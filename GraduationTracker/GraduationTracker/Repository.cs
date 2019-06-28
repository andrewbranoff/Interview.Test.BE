using System.Data;
using System.Linq;

namespace GraduationTracker {
    /// <summary>
    /// Repository for student and diploma data
    /// </summary>
    public class Repository {

        #region Student

        /// <summary>
        /// Gets all available student data
        /// </summary>
        /// <returns>Array of Student objects</returns>
        private static Student[] GetStudents() {
            return new[] { //Removed redundant explicit array types throughout solution. Also put opening brace on the same line as the declaration of new object
               new Student {
                   Id = 1,
                   Courses = new[] {
                        new Course{Id = 1, Name = "Math", Mark=94 },
                        new Course{Id = 2, Name = "Science", Mark=94 },
                        new Course{Id = 3, Name = "Literature", Mark=94 },
                        new Course{Id = 4, Name = "Physical Education", Mark=94 }
                   }
               },
               new Student {
                   Id = 2,
                   Courses = new[] {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physical Education", Mark=80 }
                   }
               },
                new Student {
                    Id = 3,
                    Courses = new[] {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physical Education", Mark=50 }
                    }
                },
                new Student {
                    Id = 4,
                    Courses = new[] {
                        new Course{Id = 1, Name = "Math", Mark=98 },
                        new Course{Id = 2, Name = "Science", Mark=98 },
                        new Course{Id = 3, Name = "Literature", Mark=98 },
                        new Course{Id = 4, Name = "Physical Education", Mark=98 }
                    }
                },
                new Student {
                    Id = 5,
                    Courses = new[] {
                        new Course{Id = 1, Name = "Math", Mark=94 },
                        new Course{Id = 2, Name = "Science", Mark=94 },
                        new Course{Id = 3, Name = "Literature", Mark=94 },
                        new Course{Id = 4, Name = "Physical Education", Mark=40 }
                    }
                },
                new Student {
                    Id = 6,
                    Courses = new[] {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physical Education", Mark=40 }
                    }
                },
                new Student {
                    Id = 7,
                    Courses = new[] {
                        new Course{Id = 1, Name = "Math", Mark=55 },
                        new Course{Id = 2, Name = "Science", Mark=45 },
                        new Course{Id = 3, Name = "Literature", Mark=55 },
                        new Course{Id = 4, Name = "Physical Education", Mark=45 }
                    }
                }
            };
        }

        /// <summary>
        /// Finds a specific student by their ID
        /// </summary>
        /// <param name="id">Value to match on the Id field of the Student object</param>
        /// <returns>Student object with matching ID, NULL if none found</returns>
        public static Student GetStudent(int id) {
            var students = GetStudents();
            var student = students.FirstOrDefault(s => id == s.Id);//Convert all to LINQ expressions - will return null if not found still and can only ever return one match.

            if (student == null) {
                throw new DataException($"No student found with an ID of {id}. Please check student ID and try again.");//Throw friendlier exception than NullReference that would be thrown otherwise
            }

            return student;
        }

        #endregion

        #region Requirement

        /// <summary>
        /// Gets all available course requirement data
        /// </summary>
        /// <returns>Array of Requirement objects</returns>
        public static Requirement[] GetRequirements() {
            return new[] {
                new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new[]{1}, Credits=1 },
                new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new[]{2}, Credits=1 },
                new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new[]{3}, Credits=1},
                new Requirement{Id = 104, Name = "Physical Education", MinimumMark=50, Courses = new[]{4}, Credits=1 }//Physical had been misspelled "Physichal" throughout all files. Corrected throughout.
            };
        }

        /// <summary>
        /// Finds a specific course requirement by its ID
        /// </summary>
        /// <param name="id">Value to match on the Id field of the Requirement object</param>
        /// <returns>Requirement object with matching ID, NULL if none found</returns>
        public static Requirement GetRequirement(int id) {
            var requirements = GetRequirements();
            var requirement = requirements.FirstOrDefault(r => id == r.Id);

            if (requirement == null) {
                throw new DataException($"No course requirement found with an ID of {id}. Please check course requirement ID and try again.");
            }

            return requirement;
        }

        #endregion

        #region Diploma

        /// <summary>
        /// Gets all available diploma data
        /// </summary>
        /// <returns>Array of Diploma objects</returns>
        private static Diploma[] GetDiplomas() {
            return new[] {
                new Diploma {
                    Id = 1,
                    Credits = 4,
                    Requirements = new[]{100,102,103,104}
                }
            };
        }

        /// <summary>
        /// Finds a specific diploma by its ID
        /// </summary>
        /// <param name="id">Value to match on the Id field of the Diploma object</param>
        /// <returns>Diploma object with matching ID, NULL if none found</returns>
        public static Diploma GetDiploma(int id) {
            var diplomas = GetDiplomas();
            var diploma = diplomas.FirstOrDefault(d => id == d.Id);

            if (diploma == null) {
                throw new DataException($"No diploma found with an ID of {id}. Please check diploma ID and try again.");
            }

            return diploma;
        }

        #endregion
    }
}