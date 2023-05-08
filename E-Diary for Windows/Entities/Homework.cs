using System;
using System.Collections.Generic;

namespace E_Diary_for_Windows.Entities {
    public class Homework {

        public int ID {
            get; set;
        }
        public string Name {
            get; set;
        }
        public string Description {
            get; set;
        }
        public List<Mark> Marks {
            get; set;
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((Homework) obj).ID;
        }

        public override string ToString() {
            return Name;
        }
    }
}
