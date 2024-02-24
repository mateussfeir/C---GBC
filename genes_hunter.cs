// Steps to run the code on the terminal:
// First: cd "path" ("/Users/mateussfeir/Desktop/Obj. Orient. Prog. COMP1202/genomics")
// Second: dotnet new console [Only one time] - Delete the Program.cs generated
// Third: dotnet build -o output [Whenever the developer makes a change.]
// Fourth: dotnet run


// using (to import something) and System (is the namespace that you want to import.)
using System;
using System.ComponentModel.DataAnnotations;

// Defining a new namespace that is being created
namespace MyGenesHunter
{
    // Class is a template that define a structure of the objects
    class Gene_class
    {   
        // public: means the method can be accessed even outside of the class
        // string: defines the type of value that the method will return
        // findGenes: is the name of the method
        // string dna: the parameter is the dna, and string is the type of value that will be passed.
        public string findGenes(string dna)
        {
            // To make the program keeps searching for all the genes in the dna_sequece we need to follow these steps:
            // Add an index = 0 and make the program start to search from this index
            // Create a loop, and everytime one gene is found, make the index be = stopCodon + 1
            // Print the gene found
            int index = 0;
            int gene_index = 1;
            string allgenes = "";

            while (index != -1) {
                int startCodon = dna.IndexOf("ATG", index);
                if (startCodon == -1)
                {
                    break;
                }

                int stopCodon = dna.IndexOf("TAA", startCodon);
                if (stopCodon == -1)
                {
                    break;
                }
                // Substring is used to extract a piece of data.
                string gene = dna.Substring(startCodon, stopCodon - startCodon + 3);
                index = stopCodon + 1;
                if ((stopCodon - startCodon) % 3 == 0) {
                    allgenes += gene_index + ": " + gene + "\n";
                    gene_index += 1;
                }
                }

            return allgenes;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the genes hunter app.");
            string dna_sequence = "TATGACGTAGTACTAACGTCGTACGTAAGTTATGACAGTACTAACGTAGCGTACGTAAGTATGTATTAA";

            // Create an instance of the class containing the findGenes method
            Gene_class geneClass = new Gene_class(); // Corrected typo here

            // Call the findGenes method and store the result
            string result = geneClass.findGenes(dna_sequence);

            // Output the result
            Console.WriteLine("That's the genes found: \n" + result);
        }
    }
}
