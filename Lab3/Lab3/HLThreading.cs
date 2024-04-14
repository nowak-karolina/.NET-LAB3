using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3 {
    internal class HLThreading {
        public Problem problem { get; set; }
        public int numberOfThreads { get; set; }

        int[] threadUesed = new int[Environment.ProcessorCount];


        public HLThreading(int noThreads, int matrixSize) {
            problem = new Problem(matrixSize);
            numberOfThreads = noThreads;

            int matrixFields = matrixSize * matrixSize;
            int necessaryThreads = 0;

            if (matrixFields - numberOfThreads < 0) {
                necessaryThreads = matrixFields;
            } else {
                necessaryThreads = numberOfThreads;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            Parallel.For(0, necessaryThreads, i => {
                int startField = i * (matrixFields / necessaryThreads);
                int fieldsToCompute = 0;
                if (i == necessaryThreads - 1) { //ostatni watek
                    fieldsToCompute = matrixFields - startField; //ostantie pola
                } else {
                    fieldsToCompute = matrixFields / necessaryThreads;
                }

                Solve(startField, fieldsToCompute, problem);
            });

            watch.Stop();

            Console.WriteLine("HL " + watch.Elapsed.TotalMilliseconds.ToString("F0") + " ms");

        }

        public static void Solve(int start, int fields, Problem problem) {
            //Console.WriteLine($"watek {Thread.CurrentThread.Name}, start: {start}, ilosc pol: {fields} ");
            for (int i = start; i < start + fields; i++) {
                for (int k = 0; k < problem.matrixSize; k++) {
                    problem.matrixR.matrix[i / problem.matrixSize, i % problem.matrixSize] += problem.matrixA.matrix[i / problem.matrixSize, k] * problem.matrixB.matrix[k, i % problem.matrixSize];
                }
            }
        }
    }
}
