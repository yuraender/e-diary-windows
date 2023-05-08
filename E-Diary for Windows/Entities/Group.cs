using System;
using System.Collections.Generic;

namespace E_Diary_for_Windows.Entities {
    public class Group {

        public int ID {
            get; set;
        }
        public string Name {
            get; set;
        }
        public string FullName {
            get; set;
        }
        public GroupGrade Grade {
            get; set;
        }
        public User Teacher {
            get; set;
        }
        public List<Subject> Subjects {
            get; set;
        }

        public bool IsSchoolGrade() {
            return Grade.ToString().Contains("E");
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((Group) obj).ID;
        }

        public override string ToString() {
            return Name;
        }
    }

    public enum GroupGrade {

        E1, E2, E3, E4, E5, E6, E7, E8, E9, E10, E11,
        S1, S2, S3, S4,
        H1, H2, H3, H4
    }

    public class GroupGradeName {

        public GroupGrade ID {
            get; set;
        }
        public string Name {
            get {
                int.TryParse(ID.ToString().Replace("E", "")
                    .Replace("S", "0").Replace("H", ""), out int grade);
                switch (ID) {
                    case GroupGrade.S1:
                    case GroupGrade.S2:
                    case GroupGrade.S3:
                    case GroupGrade.S4:
                        return grade + " курс (среднее)";
                    case GroupGrade.H1:
                    case GroupGrade.H2:
                    case GroupGrade.H3:
                    case GroupGrade.H4:
                        return grade + " курс (высшее)";
                    default:
                        return grade + " класс";
                }
            }
        }

        public GroupGradeName(GroupGrade type) {
            ID = type;
        }

        public override bool Equals(object obj) {
            return ID == ((GroupGradeName) obj).ID;
        }

        public override string ToString() {
            return Name;
        }
    }
}
