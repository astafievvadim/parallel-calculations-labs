using System;
using System.Threading;
using System.Threading.Tasks;

namespace lab4
{
    internal class BinarySearchTree
    {
        public Node Root;

        public void Insert(int key)
        {
            Root = InsertRec(Root, key);
        }

        private Node InsertRec(Node root, int key)
        {
            if (root == null) return new Node(key);

            if (key < root.Key)
                root.Left = InsertRec(root.Left, key);
            else if (key > root.Key)
                root.Right = InsertRec(root.Right, key);

            return root;
        }

        public int GetMin(Node node)
        {
            if (node == null) return int.MinValue;

            while (node.Left != null)
                node = node.Left;

            return node.Key;
        }

        public int GetMax(Node node)
        {
            if (node == null) return int.MaxValue;

            while (node.Right != null)
                node = node.Right;

            return node.Key;
        }

        public bool InterpolationSearch(int key)
        {
            return InterpolationSearchRec(Root, key, GetMin(Root), GetMax(Root));
        }

        private bool InterpolationSearchRec(Node node, int key, int min, int max)
        {
            if (node == null || min == max) return false;

            if (node.Key == key) return true;

            double range = max - min;
            if (range == 0) return false;

            double guess = min + (double)(key - min) * range / (max - min);

            if (guess < node.Key)
                return InterpolationSearchRec(node.Left, key, min, node.Key);
            else if (guess > node.Key)
                return InterpolationSearchRec(node.Right, key, node.Key, max);

            return true;
        }

        public async Task<bool> InterpolationSearchParallel(int key, int maxThreads)
        {
            var semaphore = new SemaphoreSlim(maxThreads);
            return await InterpolationSearchParallelRec(Root, key, GetMin(Root), GetMax(Root), semaphore);
        }

        private async Task<bool> InterpolationSearchParallelRec(Node node, int key, int min, int max, SemaphoreSlim semaphore)
        {
            if (node == null || min == max) return false;
            if (node.Key == key) return true;

            double range = max - min;
            if (range == 0) return false;

            double guess = min + (double)(key - min) * range / (max - min);

            Node nextNode = guess < node.Key ? node.Left : node.Right;
            int newMin = guess < node.Key ? min : node.Key;
            int newMax = guess < node.Key ? node.Key : max;

            if (semaphore.CurrentCount > 0)
            {
                await semaphore.WaitAsync();
                try
                {
                    return await Task.Run(() => InterpolationSearchParallelRec(nextNode, key, newMin, newMax, semaphore));
                }
                finally
                {
                    semaphore.Release();
                }
            }
            else
            {
                return await InterpolationSearchParallelRec(nextNode, key, newMin, newMax, semaphore);
            }
        }
    }

    class Node
    {
        public int Key;
        public Node Left, Right;

        public Node(int key)
        {
            Key = key;
            Left = Right = null;
        }
    }
}
