namespace Lab3 {
    internal class Program {
        static void Main(string[] args) {
            Matrix matrix1 = new Matrix(4);
            Matrix matrix2 = new Matrix(4);
            Matrix result = Matrix.Multiply(matrix1, matrix2);


            Console.WriteLine(matrix1.ToString());
            Console.WriteLine(matrix2.ToString());
            Console.WriteLine(result.ToString());
        }
    }
}
