using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6
{
    public class GAparallel
    {
        private int threadNumber;
        private int populationSize;
        private int generationsCount;

        private List<ParallelSpecimen> currentGeneration;
        private List<GenerationalResult> generationalResults;

        private const int tournamentSize = 5;
        private const double mutationChance = 35; //%

        private const int hours = 5;

        public static int maxAccumulationSpeed = 100;
        public static int maxProcessingSpeed = 200;
        public static int maxNumberOfServers = 300;
        public static int maxQueueSize = 400;

        public GAparallel(int N, int popSize, 
                          int gensCount,    int maxAccSpeed, 
                          int maxProcSpeed, int maxNumOfServ, 
                          int maxQ)
        {
            threadNumber = N;
            populationSize = popSize;
            generationsCount = gensCount;

            maxAccumulationSpeed = maxAccSpeed;
            maxProcessingSpeed = maxProcSpeed;
            maxNumberOfServers = maxNumOfServ;
            maxQueueSize = maxQ;

            init();
            simulation();
        }


        public List<GenerationalResult> getResults()
        {
            return generationalResults;
        }

        private void addResult()
        {
            GenerationalResult gr = new GenerationalResult();

            ParallelSpecimen best = FindBestIndInTour(currentGeneration);

            gr.setBestSpecimen(best);

            double res = 0;
            for (int i = 0; i < currentGeneration.Count; i++)
            {
                res += getFitness(currentGeneration[i]);
            }

            res = res / currentGeneration.Count;
            Console.WriteLine(res + "___");
            gr.setAvgFitness(res);

            generationalResults.Add(gr);
        }

        public double getFitness(ParallelSpecimen pc)
        {
            var vals = pc.extractValues();
            PSSconsecutive pss = new PSSconsecutive(vals[0], vals[1], vals[2], vals[3]);
            return pss.Simulate(hours);
        }

        private void init()
        {
            currentGeneration = new List<ParallelSpecimen>();
            generationalResults = new List<GenerationalResult>();

            for (int i = 0; i < populationSize; i++)
            {
                int accSpeedGene        = Utilities.RangeRandom(1, 3);
                int procSpeedGene       = Utilities.RangeRandom(1, 3);
                int numberOfServersGene = Utilities.RangeRandom(1, 3);
                int queueSizeGene       = Utilities.RangeRandom(1, 3);

                currentGeneration.Add(new ParallelSpecimen(accSpeedGene, 
                                                           procSpeedGene, 
                                                           numberOfServersGene, 
                                                           queueSizeGene));
            }

            addResult();
        }

        private void simulation()
        {
            for (int i = 0; i < generationsCount; i++)
            {
                getNewPopulation();
                addResult();
            }
        }

        // Tournament selection without fitness scaling
        private ParallelSpecimen tournament()
        {
            ParallelSpecimen best;
            List<ParallelSpecimen> selected = new List<ParallelSpecimen>();
            List<int> banned = new List<int>();

            while (selected.Count < tournamentSize)
            {
                int index = Utilities.RangeRandom(0, populationSize - 1);

                if (banned.Contains(index))
                {
                    continue;
                }
                else
                {
                    selected.Add(currentGeneration[index]);
                    banned.Add(index);
                }
            }

            best = FindBestIndInTour(selected);

            return best;
        }

        private ParallelSpecimen FindBestIndInTour(List<ParallelSpecimen> selected)
        {
            ParallelSpecimen candidate = selected[0];
            int bestIndex = 0;
            for (int i = 1; i < selected.Count; i++)
            {
                if (getFitness(selected[i]) > getFitness(candidate))
                {
                    bestIndex = i;
                }
            }

            return selected[bestIndex];
        }


        private void getNewPopulation()
        {
            List<Task> tasks = new List<Task>();
            ConcurrentBag<ParallelSpecimen> offspringBag = new ConcurrentBag<ParallelSpecimen>();

            int populationPerTask = populationSize / threadNumber; 

            int remainder = populationSize % threadNumber; 

            for (int i = 0; i < threadNumber; i++)
            {
                int taskIndex = i;
                int extra = taskIndex < remainder ? 1 : 0;
                int myCount = populationPerTask + extra;
                int startIndex = taskIndex * populationPerTask + Math.Min(taskIndex, remainder);

                tasks.Add(Task.Run(() =>
                {
                    List<ParallelSpecimen> localOffspring = new List<ParallelSpecimen>();

                    for (int j = startIndex; j < startIndex + myCount; j++)
                    {
                        ParallelSpecimen parentA = tournament();
                        ParallelSpecimen parentB = tournament();
                        ParallelSpecimen offspring = getOffspring(parentA, parentB);
                        localOffspring.Add(offspring);
                    }

                    foreach (var o in localOffspring)
                        offspringBag.Add(o);
                }));
            }

            Task.WhenAll(tasks).Wait();

            currentGeneration = offspringBag.ToList();
        }

        private ParallelSpecimen getOffspring(ParallelSpecimen parentA, ParallelSpecimen parentB)
        {
            ParallelSpecimen child = parentA.getOffspringRnd(parentB);

            // Corrected mutation chance check
            if (Utilities.RangeRandom(0, 100) < mutationChance)
            {
                child.mutation();
            }

            return child;
        }
    }

    public class ParallelSpecimen
    {
        private string chromosome;

        public int TotalChromosomeLength() =>
            Utilities.GetStringLength(GAparallel.maxAccumulationSpeed) +
            Utilities.GetStringLength(GAparallel.maxProcessingSpeed) +
            Utilities.GetStringLength(GAparallel.maxNumberOfServers) +
            Utilities.GetStringLength(GAparallel.maxQueueSize);

        public ParallelSpecimen(int accSpeed, int procSpeed, int numberOfServers, int queueSize)
        {
            string accSpeedGene        = 
                        Utilities.NormalizeBinaryString(Utilities.DecToBin(accSpeed),
                        Utilities.GetStringLength(GAparallel.maxAccumulationSpeed));
            string procSpeedGene       = 
                        Utilities.NormalizeBinaryString(Utilities.DecToBin(procSpeed),
                        Utilities.GetStringLength(GAparallel.maxProcessingSpeed));
            string numberOfServersGene = 
                        Utilities.NormalizeBinaryString(Utilities.DecToBin(numberOfServers),
                        Utilities.GetStringLength(GAparallel.maxNumberOfServers));
            string queueSizeGene       = 
                        Utilities.NormalizeBinaryString(Utilities.DecToBin(queueSize),
                        Utilities.GetStringLength(GAparallel.maxQueueSize));

            string fullChromosome = accSpeedGene        + 
                                    procSpeedGene       + 
                                    numberOfServersGene + 
                                    queueSizeGene;
            this.chromosome = 
                       Utilities.NormalizeBinaryString(fullChromosome, TotalChromosomeLength());
        }
        
        public ParallelSpecimen(string chr)
        {
            this.chromosome = chr;
        }

        public ParallelSpecimen getOffspringRnd(ParallelSpecimen secondParent)
        {
            int length = TotalChromosomeLength();

            string ParentOne = this.getChromosome();
            string ParentTwo = secondParent.getChromosome();

            string a = Utilities.NormalizeBinaryString(ParentOne, length);
            string b = Utilities.NormalizeBinaryString(ParentTwo, length);

            char[] aChrom = a.ToCharArray();
            char[] bChrom = b.ToCharArray();

            char[] childChrom = new char[length];

            int crossOverPoint = Utilities.RangeRandom((int)(length * 0.25), (int)(length * 0.75));

            int generateNumber = Utilities.RangeRandom(0,1);
      
            for (int i = 0; i < crossOverPoint; i++)
            {
                childChrom[i] = aChrom[i];
            }

            for (int i = crossOverPoint; i < length; i++)
            {
                childChrom[i] = bChrom[i];
            }

            string temp = new string(childChrom);

            return new ParallelSpecimen(Utilities.NormalizeBinaryString(temp, length));
        }

        public string getChromosome()
        {
            return chromosome;
        }

        public int[] extractValues()
        {
            int[] result = new int[4];

            int a = Utilities.GetStringLength(GAparallel.maxAccumulationSpeed);
            int b = Utilities.GetStringLength(GAparallel.maxProcessingSpeed);
            int c = Utilities.GetStringLength(GAparallel.maxNumberOfServers);
            int d = Utilities.GetStringLength(GAparallel.maxQueueSize);

            //Vadim sdelal vsyio crasivo
            result[0] = Math.Max(Utilities.BinToDec(chromosome.Substring(0, a)), 1);
            result[0] = Math.Min(result[0], GAparallel.maxAccumulationSpeed);

            result[1] = Math.Max(Utilities.BinToDec(chromosome.Substring(a, b)), 1);
            result[1] = Math.Min(result[1], GAparallel.maxProcessingSpeed);

            result[2] = Math.Max(Utilities.BinToDec(chromosome.Substring(a + b, c)), 1);
            result[2] = Math.Min(result[2], GAparallel.maxNumberOfServers);

            result[3] = Math.Max(Utilities.BinToDec(chromosome.Substring(a + b + c, d)), 1);
            result[3] = Math.Min(result[3], GAparallel.maxQueueSize);

            return result;
        }

        public void mutation()
        {

            int length = TotalChromosomeLength();
            if (length == 0) return;

            char[] temp = chromosome.ToCharArray();
            int i = Utilities.RangeRandom(0, length - 1);
            temp[i] = (temp[i] == '0') ? '1' : '0';
            this.chromosome = Utilities.NormalizeBinaryString(new string(temp), length);
        }
    }
}
