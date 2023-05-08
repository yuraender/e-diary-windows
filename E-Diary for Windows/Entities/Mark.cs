using System;

namespace E_Diary_for_Windows.Entities {
    public class Mark {

        public int ID {
            get; set;
        }
        public MarkType MarK {
            get; set;
        }
        public User User {
            get; set;
        }

        public static string GetType(MarkType type) {
            switch (type) {
                case MarkType.ONE:
                    return "1";
                case MarkType.TWO:
                    return "2";
                case MarkType.THREE:
                    return "3";
                case MarkType.FOUR:
                    return "4";
                case MarkType.FIVE:
                    return "5";
                case MarkType.MISSING:
                    return "Пропуск";
                case MarkType.MISSING_BAD:
                    return "Пропуск (неув.)";
                case MarkType.MISSING_GOOD:
                    return "Болел";
                default:
                    return "Опоздал";
            }
        }

        public bool IsMarkType() {
            switch (MarK) {
                case MarkType.MISSING:
                case MarkType.MISSING_BAD:
                case MarkType.MISSING_GOOD:
                case MarkType.LATE:
                    return false;
                default:
                    return true;
            }
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((Mark) obj).ID;
        }

        public override string ToString() {
            return base.ToString();
        }
    }

    public enum MarkType {

        ONE, TWO, THREE, FOUR, FIVE,
        MISSING, MISSING_BAD, MISSING_GOOD, LATE
    }

    public class MarkTypeName {

        public MarkType ID {
            get; set;
        }
        public string Name => Mark.GetType(ID);

        public MarkTypeName(MarkType type) {
            ID = type;
        }

        public override bool Equals(object obj) {
            return !(obj is DBNull) && ID == ((MarkTypeName) obj).ID;
        }

        public override string ToString() {
            return Name;
        }
    }
}
