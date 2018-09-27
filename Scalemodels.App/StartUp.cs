using System;
using System.IO;
using Scalemodels.Data;
using Scalemodels.DataProcessor;

namespace Scalemodels.App
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new ScalemodelsDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //ImportEntities(context);
            }
        }

        //private static void ImportEntities(ScalemodelsDbContext context, string baseDir = @"..\Datasets\")
        //{
        //    const string exportDir = "./ImportResults/";

        //    var aftermarket = Deserializer.ImportAftermarket(context, File.ReadAllText(baseDir + "Aftermarket.json"));
        //    PrintAndExportEntitiesToFile(aftermarket, exportDir + "Aftermarket.txt");
        //}

        private static void PrintAndExportEntitiesToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }
    }
}
