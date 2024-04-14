namespace Lab3 {
    internal class Program {
        private const int NoThreads = 8;
        private const int MatrixSize = 5000;

        static void Main(string[] args) {
            LLThreading fredy = new LLThreading(NoThreads, MatrixSize);

            HLThreading fredy1 = new HLThreading(NoThreads, MatrixSize);
            Console.WriteLine("-----------------");
            

        }
    }
}
