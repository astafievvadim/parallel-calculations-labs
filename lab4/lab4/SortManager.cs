using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab4
{
    internal class SortManager
    {

        // Cлияние merge
        public void MergeSort(List<int> list, IProgress<int> progress = null)
        {
            int total = list.Count;
            int processed = 0;

            void RecursiveSort(List<int> current)
            {
                if (current.Count <= 1) return;

                int mid = current.Count / 2;
                var left = current.GetRange(0, mid);
                var right = current.GetRange(mid, current.Count - mid);

                RecursiveSort(left);
                RecursiveSort(right);

                Merge(current, left, right);

                int merged = current.Count;
                int done = Interlocked.Add(ref processed, merged);
                int percent = Math.Min(100, Math.Max(0, done * 100 / total));
                progress?.Report(percent);
            }

            RecursiveSort(list);
            progress?.Report(100); // гарантированно 100% в конце
        }

        public async Task MergeSortParallel(List<int> list, int threads, IProgress<int> progress = null, int maxDepth = 10)
        {
            var chunks = ChunkList(list, threads);
            int totalChunks = chunks.Count;
            int completedChunks = 0;

            var tasks = chunks.Select(chunk => Task.Run(() =>
            {
                MergeSort(chunk); // обычная однопоточная сортировка без рекурсивного прогресса
                int done = Interlocked.Increment(ref completedChunks);
                int percent = Math.Min(100, done * 100 / totalChunks);
                progress?.Report(percent);
            })).ToList();

            await Task.WhenAll(tasks);

            var merged = MergeSortedChunks(chunks);
            list.Clear();
            list.AddRange(merged);

            progress?.Report(100); // на всякий случай, финальный рывок
        }


        private void Merge(List<int> target, List<int> left, List<int> right)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Count && j < right.Count)
                target[k++] = (left[i] <= right[j]) ? left[i++] : right[j++];
            while (i < left.Count) target[k++] = left[i++];
            while (j < right.Count) target[k++] = right[j++];
        }

        private List<int> MergeSortedChunks(List<List<int>> chunks)
        {
            var result = new List<int>();
            var indices = new int[chunks.Count];

            while (true)
            {
                int minIndex = -1;
                int minVal = int.MaxValue;

                for (int i = 0; i < chunks.Count; i++)
                {
                    if (indices[i] < chunks[i].Count && chunks[i][indices[i]] < minVal)
                    {
                        minVal = chunks[i][indices[i]];
                        minIndex = i;
                    }
                }

                if (minIndex == -1) break;

                result.Add(minVal);
                indices[minIndex]++;
            }

            return result;
        }

        // heap или пирамида
        public  void HeapSort(List<int> list, IProgress<int> progress = null)
        {
            int n = list.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(list, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                (list[0], list[i]) = (list[i], list[0]);
                Heapify(list, i, 0);
                progress?.Report(100 - (i * 100 / n));
            }
        }

        public async Task HeapSortParallel(List<int> list, int threads, IProgress<int> progress = null)
        {
            var chunks = ChunkList(list, threads);
            int totalChunks = chunks.Count;
            int completedChunks = 0;

            var tasks = chunks.Select(chunk => Task.Run(() =>
            {
                HeapSort(chunk);
                int done = Interlocked.Increment(ref completedChunks);
                int percent = Math.Min(100, done * 100 / totalChunks);
                progress?.Report(percent);
            })).ToList();

            await Task.WhenAll(tasks);

            var merged = MergeSortedChunks(chunks);
            list.Clear();
            list.AddRange(merged);

            progress?.Report(100);
        }

        private  void Heapify(List<int> list, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && list[left] > list[largest]) largest = left;
            if (right < n && list[right] > list[largest]) largest = right;

            if (largest != i)
            {
                (list[i], list[largest]) = (list[largest], list[i]);
                Heapify(list, n, largest);
            }
        }

        // Пузырёк bubble
        public void BubbleSort(List<int> list, IProgress<int> progress = null)
        {
            int n = list.Count;
            if (n <= 1) return;

            int totalOps = (n - 1) * (n - 1);
            int doneOps = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);

                    doneOps++;
                    if (doneOps % 100 == 0 || doneOps == totalOps)
                    {
                        int percent = doneOps * 100 / totalOps;
                        progress?.Report(Math.Min(100, percent));
                    }
                }
            }

            progress?.Report(100);
        }

        public async Task BubbleSortParallel(List<int> list, int threads, IProgress<int> progress = null)
        {
            var chunks = ChunkList(list, threads);
            int totalChunks = chunks.Count;
            int completedChunks = 0;

            var tasks = chunks.Select(chunk => Task.Run(() =>
            {
                BubbleSort(chunk);
                int done = Interlocked.Increment(ref completedChunks);
                int percent = Math.Min(100, done * 100 / totalChunks);
                progress?.Report(percent);
            })).ToList();

            await Task.WhenAll(tasks);

            var merged = MergeSortedChunks(chunks);
            list.Clear();
            list.AddRange(merged);

            progress?.Report(100);
        }

        // Полезное
        private List<List<int>> ChunkList(List<int> list, int chunks)
        {
            var result = new List<List<int>>();
            int chunkSize = list.Count / chunks;
            for (int i = 0; i < chunks; i++)
            {
                int start = i * chunkSize;
                int end = (i == chunks - 1) ? list.Count : start + chunkSize;
                result.Add(list.GetRange(start, end - start));
            }
            return result;
        }
    }
}
