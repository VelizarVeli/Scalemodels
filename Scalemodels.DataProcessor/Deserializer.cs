using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Scalemodels.Data;
using Scalemodels.DataProcessor.Dto;

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

        ////public static string ImportManifacturers(ScalemodelsDbContext context, string jsonString)
        ////{
        ////    var sb = new StringBuilder();

        ////    var deserializedManifacturers = JsonConvert.DeserializeObject<ManifacturerDto[]>(jsonString);
        ////}

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}
