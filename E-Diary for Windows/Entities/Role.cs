using System;

namespace E_Diary_for_Windows.Entities {
    public class Role {

        public int ID {
            get; set;
        }
        public string Name {
            get; set;
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((Role) obj).ID;
        }

        public override string ToString() {
            return Name;
        }
    }
}
