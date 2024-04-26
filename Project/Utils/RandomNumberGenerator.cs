using System;
using System.Text;

namespace CsharpSB_WPF.Project.Utils {
    public static class RandomNumberGenerator {
        public static string GenerateRandomNumber(int length) {
            if (length > 0) {
                var sb = new StringBuilder();
                var rnd = SeedRandom();
                for (int i = 0; i < length; i++) {
                    sb.Append(rnd.Next(0, 9).ToString());
                }
                return sb.ToString();
            }
            return string.Empty;
        }

        private static Random SeedRandom() {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        public static string GetAsterisksMask(int length, string symbol = "*") {
            if (length > 0) {
                var sb = new StringBuilder();
                for (int i = 0; i < length; i++) {
                    sb.Append(symbol);
                }
                return sb.ToString();
            }
            return string.Empty;
        }
    }
}