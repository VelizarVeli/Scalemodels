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

        private static void ImportEntities(ScalemodelsDbContext context, string baseDir = @"..\Datasets\")
        {
            Deserializer.ImportManifacturers(context, File.ReadAllText(@"C:\Users\Google\Documents\Proj\Scalemodels\Datasets\Manifacturers.json"));
            Deserializer.ImportAftermarket(context, File.ReadAllText(@"C:\Users\Google\Documents\Proj\Scalemodels\Datasets\Aftermarket.json"));
            Deserializer.ImportWishList(context, File.ReadAllText(@"C:\Users\Google\Documents\Proj\Scalemodels\Datasets\WishList.json"));
            Deserializer.ImportVarnishes(context, File.ReadAllText(@"C:\Users\Google\Documents\Proj\Scalemodels\Datasets\Varnishes.json"));
            Deserializer.ImportTools(context, File.ReadAllText(@"C:\Users\Google\Documents\Proj\Scalemodels\Datasets\Tools.json"));
            Deserializer.ImportPaints(context, File.ReadAllText(@"C:\Users\Google\Documents\Proj\Scalemodels\Datasets\PaintAndConsumable.json"));
        }
    }
}
