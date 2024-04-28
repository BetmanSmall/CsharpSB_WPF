using Newtonsoft.Json;

namespace CsharpSB_WPF.Project.Data {
    public class FullName {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }

        public FullName() {
        }

        public FullName(int index) {
            FirstName = "FirstName_" + index;
            LastName = "LastName_" + index;
            SurName = "SurName_" + index;
        }

        public override string ToString() {
            return ToString(true);
        }

        public string ToString(bool json) {
            if (json) {
                return JsonConvert.SerializeObject(this);
            } else {
                return FirstName + ", " + LastName + ", " + SurName;
            }
        }
    }
}