using System;
namespace SecureCoding {
    public class IntOverFlow {
        public static void Main(String[] args) {
            int a = int.MaxValue;
            int b = int.MaxValue;
            Console.WriteLine(a + b);
        }
    }
}