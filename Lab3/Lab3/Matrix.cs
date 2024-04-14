using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    internal class Matrix {
        public int[,] matrix { get; set; }       //[r,c]
        public int n { get; set; }

        public Matrix(int n) {
            this.n = n;
            matrix = new int[n, n];

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    matrix[i, j] = 0;
                }
            }
        }

        public void RandomizeMatrix() {
            Random random = new Random();

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    matrix[i, j] = random.Next(1,10);
                }
            }
        }


        public override string ToString() {
            string s = "";

            for (int i = 0;i < this.n;i++) {
                s += "|";
                for (int j = 0; j< this.n; j++) {
                    s += matrix[i, j] + "\t";
                }
                s += "|\n";
            }

            return s;
        }
    }
}
