using System;
using System.Text.RegularExpressions;
using CsharpSB_WPF.Project.Utils;
using Newtonsoft.Json;

namespace CsharpSB_WPF.Project.Data {
    public class PhoneNumber {
        // Regular expression used to validate a phone number.
        private const string Pattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        private static bool IsPhoneNbr(string number) {
            if (number != null) return Regex.IsMatch(number, Pattern);
            else return false;
        }

        public string number { get; set; }

        public PhoneNumber(string number) {
            if (number.Length == 0) number = GenerateRandomPhoneNumber();
            if (IsPhoneNbr(number)) {
                this.number = number;
            } else {
                throw new Exception("Bad phoneNumber format!");
            }
        }

        public PhoneNumber() : this(GenerateRandomPhoneNumber()) {
        }

        private static string GenerateRandomPhoneNumber() {
            return string.Format("07{0}", RandomNumberGenerator.GenerateRandomNumber(8));
        }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}