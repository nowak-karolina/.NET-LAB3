using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    internal class LLThreading {
        public Thread[] threads {  get; set; }
        public Problem problem { get; set; }
        public int numberOfThreads { get; set; }
        
        public LLThreading(int noThreads, int matrixSize) {
            problem = new Problem(matrixSize);
            numberOfThreads = noThreads;

            int matrixFields = matrixSize * matrixSize;
            int necessaryThreads = 0;

            if (matrixFields - numberOfThreads < 0) {
                necessaryThreads = matrixFields;
            } else {
                necessaryThreads = numberOfThreads;
            }


            threads = new Thread[necessaryThreads];


            for (int i = 0; i < necessaryThreads; i++) {
                int startField = i * (matrixFields / necessaryThreads);
                int fieldsToCompute = 0;

                if (i == necessaryThreads - 1) { //ostatni watek
                    fieldsToCompute = matrixFields - startField; //ostantie pola
                } else {
                    fieldsToCompute = matrixFields/necessaryThreads;
                }

                threads[i] = new Thread(() => {
                    Solve(startField, fieldsToCompute, problem);
                });
                threads[i].Name = i.ToString();

            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (Thread thread in threads) {
                thread.Start();
            }

            foreach (Thread thread in threads) {
                thread.Join();
            }
            watch.Stop();

            Console.WriteLine("LL " + watch.Elapsed.TotalMilliseconds.ToString("F0") + " ms");
        }

        public static void Solve(int start, int fields, Problem problem) {
            //Console.WriteLine($"watek {Thread.CurrentThread.Name}, start: {start}, ilosc pol: {fields} ");
            for (int i = start; i < start+fields; i++) {
                for (int k=0; k < problem.matrixSize;k++) {
                    problem.matrixR.matrix[i / problem.matrixSize, i% problem.matrixSize] += problem.matrixA.matrix[i / problem.matrixSize, k] * problem.matrixB.matrix[k, i % problem.matrixSize];
                }
            }
        }
    }
}
