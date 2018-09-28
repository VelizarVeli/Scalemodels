using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
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

        //public static string ImportAftermarket(ScalemodelsDbContext context, string jsonString)
        //{
        //    var sb = new StringBuilder();

        //    var deserializedAftermarket = JsonConvert.DeserializeObject();
        //}

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
