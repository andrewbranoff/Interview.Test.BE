using System.Linq;

namespace GraduationTracker {
    public class Repository {
        public static Student GetStudent(int id) {
            var students = GetStudents();

            return students.FirstOrDefault(s => id == s.Id);//Convert all to LINQ expressions - will return null if not found still and can only ever return one match.
        }

        public static Diploma GetDiploma(int id) {
            var diplomas = GetDiplomas();

            return diplomas.FirstOrDefault(d => id == d.Id);
        }

        public static Requirement GetRequirement(int id) {
            var requirements = GetRequirements();

            return requirements.FirstOrDefault(r => id == r.Id);
        }

        private static Diploma[] GetDiplomas() {
            return new[] { //Removed redundant explicit array types throughout solution. Also put opening brace on the same line as the declaration of new object
                new Diploma {
                    Id = 1,
                    Credits = 4,
                    Requirements = new[]{100,102,103,104}
                }
            };
        }

        public static Requirement[] GetRequirements() {
            return new[] {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new[]{1}, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new[]{2}, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new[]{3}, Credits=1},
                    new Requirement{Id = 104, Name = "Physical Education", MinimumMark=50, Courses = new[]{4}, Credits=1 }//Physical had been misspelled "Physichal" throughout all files. Corrected throughout.
                };
        }

        private static Student[] GetStudents() {
            return new[] {
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
    }
}