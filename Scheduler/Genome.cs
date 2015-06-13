using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using btl.generic;

namespace Scheduler
{
    public class Genome
    {
        ArrayList population;
        Random RandomGen = new Random(DateTime.Now.Millisecond);
        public Genome()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public Genome(ArrayList gene)
        {
            population = new ArrayList();
            population = gene;
            m_length = gene.Count;
            m_genes = new double[gene.Count];

            CreateGenes();
        }
        public Genome(int length)
        {
            m_length = length;
            m_genes = new double[length];
            CreateGenes();
        }
        public Genome(int length, bool createGenes)
        {
            m_length = length;
            m_genes = new double[length];
            if (createGenes)
                CreateGenes();
        }
        /*
		public Genome(ref int[] genes)
		{
			m_length = genes.GetLength(0);
			m_genes = new int[ m_length ];
			for (int i = 0 ; i < m_length ; i++)
				m_genes[i] = genes[i];
		}*/


        private void CreateGenes()
        {
            // DateTime d = DateTime.UtcNow;
            for (int i = 0; i < m_length; i++)
            {
                int Index;
                Index = RandomGen.Next(population.Count);
                m_genes[i] = (int)population[Index];
                population.RemoveAt(Index);
            }

        }

        public void Crossover(ref Genome genome2, out Genome child1, out Genome child2)
        {
            int pos = (int)(m_random.Next() * (int)m_length);
            child1 = new Genome(m_length, false);
            child2 = new Genome(m_length, false);
            for (int i = 0; i < m_length; i++)
            {
                if (i < pos)
                {
                    child1.m_genes[i] = m_genes[i];
                    child2.m_genes[i] = genome2.m_genes[i];
                }
                else
                {
                    child1.m_genes[i] = genome2.m_genes[i];
                    child2.m_genes[i] = m_genes[i];
                }
            }
        }


        public void Mutate()
        {
            int Index = 0;
			for (int pos = 0 ; pos < m_length; pos++)
			{
				if (m_random.Next() < m_mutationRate)
                    
                    Index = RandomGen.Next(population.Count);
					m_genes[pos] = (int)population[Index];
			}
          
        }

        public double[] Genes()
        {
            return m_genes;
        }

        public void Output()
        {
            for (int i = 0; i < m_length; i++)
            {
                System.Console.WriteLine("{0:F4}", m_genes[i]);
            }
            System.Console.Write("\n");
        }

        public void GetValues(ref double[] values)
        {
            for (int i = 0; i < m_length; i++)
                values[i] = m_genes[i];
        }


        public double[] m_genes;
        private int m_length;
        private double m_fitness;
        static Random m_random = new Random();

        private static double m_mutationRate;

        public double Fitness
        {
            get
            {
                return m_fitness;
            }
            set
            {
                m_fitness = value;
            }
        }




        public static double MutationRate
        {
            get
            {
                return m_mutationRate;
            }
            set
            {
                m_mutationRate = value;
            }
        }

        public int Length
        {
            get
            {
                return m_length;
            }
        }
    }

}
