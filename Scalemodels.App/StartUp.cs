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
                //  context.Database.EnsureDeleted();
                //  context.Database.EnsureCreated();

                ImportEntities(context);
            }
        }

        private static void ImportEntities(ScalemodelsDbContext context, string baseDir = @"..\Datasets\")
        {
            var manifaturers = Deserializer.ImportManifacturers(context, File.ReadAllText(baseDir + "Manifacturers.json"));
        }
    }
}
