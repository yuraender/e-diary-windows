using System;
using System.Collections.Generic;

namespace E_Diary_for_Windows.Entities {
    public class Lesson {

        public int ID {
            get; set;
        }
        public LessonType Type {
            get; set;
        }
        public int Term {
            get; set;
        }
        public DateTime Date {
            get; set;
        }
        public int LessoN {
            get; set;
        }
        public Group Group {
            get; set;
        }
        public Subject Subject {
            get; set;
        }
        public List<Mark> Marks {
            get; set;
        }
        public List<Homework> Homework {
            get; set;
        }

        public static string GetType(LessonType type) {
            switch (type) {
                case LessonType.ANSWER:
                    return "Ответ на уроке";
                case LessonType.TEST:
                    return "Тест";
                case LessonType.PRACTICAL_WORK:
                    return "Практическая";
                case LessonType.COURSE_WORK:
                    return "Курсовая";
                case LessonType.GRADIATE_WORK:
                    return "Дипломная";
                case LessonType.SEMESTER:
                    return "Итоговая за семестр";
                case LessonType.YEAR:
                    return "Итоговая за год";
                case LessonType.EXAMS:
                    return "Экзамен";
                default:
                    return "Итоговая";
            }
        }

        public bool IsLessonType() {
            switch (Type) {
                case LessonType.SEMESTER:
                case LessonType.YEAR:
                case LessonType.EXAMS:
                case LessonType.FINAL:
                    return false;
                default:
                    return true;
            }
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((Lesson) obj).ID;
        }

        public override string ToString() {
            string term = Group.IsSchoolGrade() ? "четверть" : "семестр";
            return $"{Date:dd MMMM yyyy}, {LessoN} урок";
        }
    }

    public enum LessonType {

        ANSWER, TEST,
        PRACTICAL_WORK, COURSE_WORK, GRADIATE_WORK,
        SEMESTER, YEAR, EXAMS, FINAL
    }

    public class LessonTypeName {

        public LessonType ID {
            get; set;
        }
        public string Name => Lesson.GetType(ID);

        public LessonTypeName(LessonType type) {
            ID = type;
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((LessonTypeName) obj).ID;
        }

        public override string ToString() {
            return Name;
        }
    }
}
