using System;

namespace SecureCoding {
    public class IntOverFlow {
        public static void Main(string[] args) {
            int a = int.MaxValue;
            int b = int.MaxValue;

            try {
                int result = safe_add(a, b);
                Console.WriteLine(result);
            } catch (OverflowException e) {
                Console.WriteLine("Overflow occurred: " + e.Message);
            }
        }

        public static int safe_add(int x, int y) {
            checked {
                return x + y;
            }
        }
    }
}
