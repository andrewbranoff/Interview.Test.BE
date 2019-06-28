using System;

namespace GraduationTracker {
    public class GraduationTracker {  //not a partial class, no other parts to the class defined - removed partial keyword
        /// <summary>
        /// Check if a specified student meets the requirements to graduate with a specified diploma
        /// </summary>
        /// <param name="diploma">Diploma object defining the requirements for graduation</param>
        /// <param name="student">Student object defining the grades of a specific student</param>
        /// <returns>Tuple - Item 1 is a graduated/failed boolean, Item2 is the academic standing/honors of the student.</returns>
        public Tuple<bool, Standing> HasGraduated(Diploma diploma, Student student) {
            var credits = 0;
            var average = 0;

            foreach (int requirementCourseID in diploma.Requirements) { //Converted all to foreach, index was never used except to manually access array
                foreach (Course course in student.Courses) {
                    var requirement = Repository.GetRequirement(requirementCourseID);

                    foreach (int courseID in requirement.Courses) {
                        if (courseID != course.Id) {
                            continue;//reduce nesting
                        }

                        average += course.Mark;
                        if (course.Mark <= requirement.MinimumMark) {
                            continue;
                        }

                        course.Credits = requirement.Credits;//update course on student to show credits as earned.
                        credits += course.Credits;
                    }
                }
            }

            average = average / student.Courses.Length;

            //Standing should be set on the student, a property for it exists in original code, not needed as a local variable

            if (average < 50 || credits < diploma.Credits)//also check if required number of credits earned - average can be over 50 if one course was failed but the others had excellent marks
                student.Standing = Standing.Remedial;
            else if (average < 80)
                student.Standing = Standing.Average;
            else if (average < 95)
                student.Standing = Standing.MagnaCumLaude;
            else
                student.Standing = Standing.SumaCumLaude;//95 and up - was MagnaCumLaude, SumaCumLaude was never used, Magna as both last "else if" and final "else" is redundant.

            switch (student.Standing) {
                case Standing.Remedial:
                    return new Tuple<bool, Standing>(false, student.Standing);
                case Standing.Average:
                    return new Tuple<bool, Standing>(true, student.Standing);
                case Standing.SumaCumLaude:
                    return new Tuple<bool, Standing>(true, student.Standing);
                case Standing.MagnaCumLaude:
                    return new Tuple<bool, Standing>(true, student.Standing);

                default:
                    return new Tuple<bool, Standing>(false, student.Standing);
            }
        }
    }
}