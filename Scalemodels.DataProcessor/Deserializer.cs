using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Scalemodels.Data;
using Scalemodels.DataProcessor.Dto;
using Scalemodels.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Scalemodels.DataProcessor
{
    public class Deserializer
    {
        private const string FailureMessage = "Invalid Data";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportAftermarket(ScalemodelsDbContext context, string jsonString)
        {
            var deserializedAftermarket = JsonConvert.DeserializeObject<PurchasedAftermarketDto[]>(jsonString,
                new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

            var validAftermarketItems = new List<PurchasedAftermarket>();


            foreach (var aftermarketDto in deserializedAftermarket)
            {
                if (!IsValid(aftermarketDto))
                {
                    continue;
                }

                var manifacturer = context.Manifacturers
                    .FirstOrDefault(m => m.Name == aftermarketDto.Manifacturer);

                if (manifacturer == null)
                {
                    manifacturer = new Manifacturer
                    {
                        Name = aftermarketDto.Manifacturer
                    };
                    context.Manifacturers.Add(manifacturer);
                    context.SaveChanges();
                }

                var aftermarket = new PurchasedAftermarket
                {
                    ProductName = aftermarketDto.ProductName,
                    Manifacturer = manifacturer,
                    Price = aftermarketDto.Price,
                    Category = aftermarketDto.Category,
                    DateOfPurchase = aftermarketDto.DateOfPurchase,
                    FactoryNumber = aftermarketDto.FactoryNumber,
                    Placement = aftermarketDto.Placement
                };

                validAftermarketItems.Add(aftermarket);
            }

            context.PurchasedAftermarkets.AddRange(validAftermarketItems);
            context.SaveChanges();

            return "All Good!";
        }

        public static string ImportManifacturers(ScalemodelsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedManifacturers = JsonConvert.DeserializeObject<ManifacturerDto[]>(jsonString);

            var ValidManifacturers = new HashSet<Manifacturer>();

            foreach (var manifacturerDto in deserializedManifacturers)
            {
                if (!IsValid(manifacturerDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var manifacturerAlreadyExists = ValidManifacturers.Any(m => m.Name == manifacturerDto.Manifacturer);
                if (manifacturerAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var manifacturer = new Manifacturer
                {
                    Name = manifacturerDto.Manifacturer
                };

                ValidManifacturers.Add(manifacturer);

                sb.AppendLine(string.Format(SuccessMessage, manifacturerDto.Manifacturer));
            }

            context.Manifacturers.AddRange(ValidManifacturers);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}
