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

                ImportEntities(context);
            }
        }

        //TODO: Automate the path
        //TODO: Create services
        private static void ImportEntities(ScalemodelsDbContext context, string baseDir = @"C:\Users\Google\Documents\Proj\Scalemodels\Datasets\")
        {
            Deserializer.ImportManifacturers(context, File.ReadAllText(baseDir + "Manifacturers.json"));
            Deserializer.ImportAftermarket(context, File.ReadAllText(baseDir + "Aftermarket.json"));
            Deserializer.ImportWishList(context, File.ReadAllText(baseDir + "WishList.json"));
            Deserializer.ImportVarnishes(context, File.ReadAllText(baseDir + "Varnishes.json"));
            Deserializer.ImportTools(context, File.ReadAllText(baseDir + "Tools.json"));
            Deserializer.ImportPaints(context, File.ReadAllText(baseDir + "PaintAndConsumable.json"));
        }
    }
}
