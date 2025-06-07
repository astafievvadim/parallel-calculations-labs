
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab6
{
    public class SimulationResult
    {
        /*
        /
        public int ProcessedCount { get; }
        public TimeSpan Elapsed { get; }

        public SimulationResult(int processedCount, TimeSpan elapsed)
        {
            ProcessedCount = processedCount;
            Elapsed = elapsed;
        }

        public override string ToString()
        {
            return $"Обработано элементов: {ProcessedCount}; " +
                   $"Затрачено времени: {Elapsed.TotalSeconds:F2} сек.";
        }
    }

    internal class PSS
    {
        private readonly Queue<int> input;
        private readonly Random rand;
        private readonly int size;

        private readonly int itemCount;
        private readonly int minValue;
        private readonly int maxValue;
        //private readonly int workerCount;

        public PSS(int size)
        {
            this.size = size;
            input = new Queue<int>(size);
            rand = new Random();
        }

        public PSS(int itemCount, int minValue, int maxValue)
        {
            this.itemCount = itemCount;
            this.minValue = minValue;
            this.maxValue = maxValue;

            input = new Queue<int>(size);
            rand = new Random();

            for (int i = 0; i < itemCount; i++)
            {
                input.Enqueue(Utils.RangeRandom(minValue, maxValue));
            }
        }

        public double riggedRun(int workerCount)
        {
            var queue = new ConcurrentQueue<int>();
            var rnd = new Random();
            
            for(int i = 0; i < input.Count; i++)
            {
                queue.Enqueue(input.Dequeue());
            }

            double totalCounter = 0;
            for (int w = 0; w < workerCount; w++)
            {
                int item;

                queue.TryDequeue(out item);
                totalCounter += item;
            }

            totalCounter = (totalCounter+1) / (workerCount+1);

            return totalCounter;
        }

        public TimeSpan run(int itemCount, int minValue, int maxValue, int workerCount)
        {
            var queue = new ConcurrentQueue<int>();
            var output = new ConcurrentBag<int>();
            var rnd = new Random();

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(rnd.Next(minValue, maxValue + 1));
            }

            var sw = Stopwatch.StartNew();

            Task[] tasks = new Task[workerCount];
            for (int w = 0; w < workerCount; w++)
            {
                tasks[w] = Task.Run(() =>
                {
                    while (queue.TryDequeue(out var item))
                    {
                        output.Add(item);
                    }
                });
            }

            Task.WaitAll(tasks);

            sw.Stop();
            return sw.Elapsed;
        }


        public void CreateStartValue(int minValue, int maxValue)
        {
            input.Clear();
            for (int i = 0; i < size; i++)
            {
                input.Enqueue(Utils.RangeRandom(minValue, maxValue));
            }
        }

        public SimulationResult SimulationWork(TimeSpan maxDuration)
        {
            int processedCount = 0;
            var stopwatch = Stopwatch.StartNew();

            while (input.Count > 0)
            {
                int workMs = Utils.RangeRandom(100, 300);

                if (stopwatch.Elapsed + TimeSpan.FromMilliseconds(workMs) > maxDuration)
                    break;

                Thread.Sleep(workMs);
                input.Dequeue();
                processedCount++;
            }

            stopwatch.Stop();
            return new SimulationResult(processedCount, stopwatch.Elapsed);
        }
        */
    }
}
