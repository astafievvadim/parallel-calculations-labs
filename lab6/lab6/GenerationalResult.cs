using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class GenerationalResult
    {
        private double avgFitness;

        private ParallelSpecimen best;

        public double getAvgFitness()
        {
            return avgFitness;
        }

        public ParallelSpecimen getBestSpecimen()
        {
            return best;
        }

        public void setBestSpecimen(ParallelSpecimen b)
        {
            this.best = b;
        }

        public void setAvgFitness(double a)
        {
            this.avgFitness = a;
        }

    }
}
