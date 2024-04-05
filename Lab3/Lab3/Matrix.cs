using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    internal class Matrix {
        public int[,] matrixClass { get; set; }       //[r,c]

        public Matrix(int n) {
            var rand = new Random();
            matrixClass = new int[n, n];

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    matrixClass[i, j] = rand.Next(1,10);
                }
            }
        }

        public static Matrix Zeros(Matrix matrix1) {
            for (int i = 0; i < GetSize(matrix1); i++) {
                for (int j = 0; j < GetSize(matrix1); j++) {
                    matrix1.matrixClass[i, j] = 0;
                }
            }

            return matrix1;
        }

        public static int GetSize(Matrix matrix) {
            return matrix.matrixClass.GetLength(0);
        }

        public override string ToString() {
            string s = "";

            for (int i = 0;i < matrixClass.GetLength(0);i++) {
                s += "|";
                for (int j = 0; j< matrixClass.GetLength(1); j++) {
                    s += matrixClass[i, j] + "\t";
                }
                s += "|\n";
            }

            return s;
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2) {
            Matrix result = new Matrix(GetSize(matrix1));
            result = Zeros(result);

            for (int i = 0; i<GetSize(matrix1); i++) {
                for(int j=0; j<GetSize(matrix1);j++) {
                    for(int k=0; k<GetSize(matrix1);k++) {
                        result.matrixClass[i, j] += matrix1.matrixClass[i, k] * matrix2.matrixClass[k, j];
                    }
                }
            }

            return result;
        }
    }
}
