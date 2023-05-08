using System;
using System.Collections.Generic;

namespace E_Diary_for_Windows.Entities {
    public class User {

        public int ID {
            get; set;
        }
        public string Name {
            get; set;
        }
        public DateTime BirthDate {
            get; set;
        }
        public string Login {
            get; set;
        }
        public string Email {
            get; set;
        }
        public string Image {
            get; set;
        }
        public List<Role> Roles {
            get; set;
        }
        public List<Group> Groups {
            get; set;
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((User) obj).ID;
        }

        public override string ToString() {
            return Name + $" (#{ID})";
        }
    }
}
