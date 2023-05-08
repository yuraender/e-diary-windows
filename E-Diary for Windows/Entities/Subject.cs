using System;

namespace E_Diary_for_Windows.Entities {
    public class Subject {

        public int ID {
            get; set;
        }
        public string Name {
            get; set;
        }
        public User Teacher {
            get; set;
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((Subject) obj).ID;
        }

        public override string ToString() {
            return Name;
        }
    }
}
