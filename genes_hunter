using System;

namespace YourNamespace
{
    class Genomics
    {
        // Method to find a gene in a DNA sequence
        public string findGene(string dna)
        {
            // Start codon: ATG
            // Stop codon: TAA

            // Find the index of the start codon (ATG) in the DNA sequence
            // creating the varialbe startCodonIndex, and using the method "IndexOf"
            int startCodonIndex = dna.IndexOf("ATG");

            // If start codon is not found, print a message and return an empty string
            // -1 indicates failure, it means the program couldn't find "ATG"
            if (startCodonIndex == -1)
            {
                Console.WriteLine("Start codon (ATG) not found.");
                return "";
            }

            // Find the index of the stop codon (TAA) after the start codon (ATG)
            // Using ("TAA", startCodonIndex) to check only after the startCodonIndex, and not the entire string before that.

            int stopCodonIndex = dna.IndexOf("TAA", startCodonIndex);
            // If stop codon is not found after the start codon, print a message and return an empty string
            if (stopCodonIndex == -1)
            {
                Console.WriteLine("Stop codon (TAA) not found after the start codon (ATG).");
                return "";
            }

            // Report the substring between the start codon (ATG) and the stop codon (TAA), including both codons
            // + 3 is used to include the stopCodonIndex strings.
            string gene = dna.Substring(startCodonIndex, stopCodonIndex - startCodonIndex + 3);
            return gene;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DNA sequence to search for a gene
            string dna = "ACGATGCGTAAGC";
            //               ^      ^ 
           
            // Create an instance of the Genomics class
            // Genomics = class, genomics = variable
            Genomics genomics = new Genomics();

            // Call the findGene method to find a gene in the DNA sequence and store the result in a variable
            string gene = genomics.findGene(dna);
            // Print the gene found in the DNA sequence
            Console.WriteLine("Gene found: " + gene);
        }
    }
}
