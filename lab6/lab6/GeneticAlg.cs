using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class GeneticAlg
    {
        private List<Specimen> list;
        private List<Specimen> bestPerGen;

        private const int populationSize = 15;
        private const int tournamentSize = 5;
        private const int generationsCount = 50;
        private const int numberOfMutation = 1;

        private const int minThread = 1;
        private const int maxThread = 100;

        private const int resources = 70;

        public GeneticAlg()
        {
            //maxThread = queue.Length();
            init();
            simulation();
        }

        public List<int> getBest()
        {
            List<int> r = new List<int>();

            for(int i = 0; i < bestPerGen.Count; i++)
            {
                r.Add(Utils.Bin2Dec(bestPerGen[i].getChromosome()));
            }
            return r;
        }

        private long getFitness(Specimen specimen)
        { 
            // Specimen . chromosome . N
            // SMO.test(N) -> time
            // (Queue -> Threads -> result) = time;
            // return 1/time;

            int threadCount = Utils.Bin2Dec(specimen.getChromosome());

            return threadCount;
        }
        
        private void init()
        {
            list = new List<Specimen>();
            bestPerGen = new List<Specimen>();

            for (int i = 0; i < populationSize; i++)
            {
                int n = Utils.rangeRandom(minThread, maxThread);
                string chr = Utils.Dec2Bin(n);
                list.Add(new Specimen(chr));
            }
            
        }

        private void simulation() { 

            for(int i = 0; i < generationsCount; i++)
            {
                getNewPopulation();
                bestPerGen.Add(FindBestIndInTour(list)); 
            }

        }

        // tournament
        private Specimen tournament()
        {
            Specimen best;

            List<Specimen> selected = new List<Specimen>();
            List<int> banned = new List<int>();

            while(selected.Count < tournamentSize)
            {

                int index = Utils.rangeRandom(0, populationSize-1);

                if (banned.Contains(index))
                {
                    continue;
                }
                else
                {
                    selected.Add(list[index]);
                    banned.Add(index);
                }
            }

            best = FindBestIndInTour(selected);

            return best;
        }

        private Specimen FindBestIndInTour(List<Specimen> selected)
        {
            Specimen candidate = selected[0];
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
            List<Specimen> temp = new List<Specimen>();
            
            while(temp.Count < populationSize)
            {
                Specimen parentA = tournament();
                Specimen parentB = tournament();

                temp.Add(getOffspring(parentA, parentB));
            }

            list = temp;
        }

        private Specimen getOffspring(Specimen parentA, Specimen parentB)
        {
            Specimen child;

            char[] aChrom = parentA.getChromosome().ToCharArray();
            char[] bChrom = parentB.getChromosome().ToCharArray();
            //crossover point:
            //char[] childChrom = { aChrom[0], aChrom[1], aChrom[2], bChrom[3], bChrom[4], bChrom[5], bChrom[6] };
            //uniform crossover:
            char[] childChrom = { aChrom[0], bChrom[1], aChrom[2], bChrom[3], aChrom[4], bChrom[5], aChrom[6] };

            child = new Specimen(new string(childChrom));
            
            for(int i = 0; i < numberOfMutation; i++)
            {
                child.mutation(Utils.rangeRandom(0, 6));
            }

            return child;

        }
        // initialization

        // mutation, potentially

        // offspring creation function

        /*
         * Fitness function strategies:
         * !!! IT PROBABLY NEEDS NORMALIZATION? Those numbers are too small. 
         * 1. Maybe f(x) = 1/time_spent
         * (1) 50 особей * [1..100] потоков
         * (1) ConcurrentQueue<T>
         * 2. Maybe analyze the resources spent. Probably something like 1/resources again
         * 3. 
         * Generally:
         * 1. Create a population of size X with random genes
         * 2.1. Tournament, choose TOURNAMENT_NUMBER of specimen, take the two most fit out of them
         * 2.2. When two most fit create offspring, said offspring should mutate. NUMBER_OF_MUTATIONS
         * 2.3. Put that wretched mutated child into new generation
         * 3. Do step 2 until the you reach the number of generations
         * 4. Happy happy happy
         */
    }

    internal class Specimen
    {

        private string chromosome; //100 = 1100100 (7)

        public Specimen(string chr)
        {
            this.chromosome = Utils.strNormalizeDec2Bin(chr);
        }

        public string getChromosome()
        {
            return chromosome;
        }

        public void mutation(int i)
        {
            char[] temp = chromosome.ToCharArray();

            if (temp[i] == '0')
            {
                temp[i] = '1';
            }
            else
            {
                temp[i] = '0';
            }

            this.chromosome = Utils.strNormalizeDec2Bin(new string(temp));

        }

        // something like a chromosome to express the number of threads

        // hardcoded maximum number of threads, each time a new specimen is born, the number of threads should be compared against it and limited by it

        // constructor from __chromosome__ (which is probably going to be a string), don't forget the previous check

        // class chromosome is probably not needed 0


    }
}
