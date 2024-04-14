using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    internal class Problem {
        public Matrix  matrixA { get; set; }
        public Matrix matrixB { get; set; }
        public Matrix matrixR { get; set; }

        public int matrixSize {  get; set; }

        
        public Problem(int n) {
            matrixA = new Matrix(n);
            matrixB = new Matrix(n);
            matrixR = new Matrix(n);
            matrixSize = n;

            matrixA.RandomizeMatrix();
            matrixB.RandomizeMatrix();
        }

    }
}
