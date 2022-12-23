using System;
using System.IO;
using TreeSummingExercise.Utilities;

namespace TreeSummingExercise
{
    internal static class Program
    {
        private const string TextFilePath = @"**__place_filepath_here__**\TreeSummingExercise\intputfile.txt";

        private static void Main()
        {
            if (!File.Exists(TextFilePath))
                Console.WriteLine("Ensure the file 'inputfile.txt' is in the correct folder");
            else
                Run(File.ReadAllText(TextFilePath).Replace(" ", string.Empty));

            Console.ReadKey();
        }

        private static void Run(string text)
        {
            var resolver = new TreeResolver();
            var generatedTrees = TreeResolver.DecodeAndCreateAllTrees(text);
            var formattedOutput = resolver.SolveTrees(generatedTrees);
            foreach (var solution in formattedOutput) Console.WriteLine(solution);
        }
    }
}
