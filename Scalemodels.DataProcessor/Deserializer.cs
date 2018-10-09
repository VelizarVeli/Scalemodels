﻿using System.Collections.Generic;
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

        public static string ImportWishList(ScalemodelsDbContext context, string jsonString)
        {
            var deserializedWishList = JsonConvert.DeserializeObject<WishListDto[]>(jsonString);

            var validWishListItems = new HashSet<WishList>();

            foreach (var wishListDto in deserializedWishList)
            {
                var manifacturer = context.Manifacturers.FirstOrDefault(m => m.Name == wishListDto.Manifacturer);

                if (manifacturer == null)
                {
                    manifacturer = new Manifacturer
                    {
                        Name = wishListDto.Manifacturer
                    };
                    context.Manifacturers.Add(manifacturer);
                    context.SaveChanges();
                }

                var wishList = new WishList
                {
                    Name = wishListDto.Name,
                    Manifacturer = manifacturer,
                    FactoryNumber = wishListDto.FactoryNumber
                };

                validWishListItems.Add(wishList);
            }

            context.WishListModels.AddRange(validWishListItems);
            context.SaveChanges();
            return "All good";
        }

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

        public static string ImportVarnishes(ScalemodelsDbContext context, string jsonString)
        {
            var deserializedVarnishes = JsonConvert.DeserializeObject<VarnishDto[]>(jsonString,
                new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

            var validVarnishes = new HashSet<Varnish>();

            foreach (var varnishDto in deserializedVarnishes)
            {
                var manifacturer = context.Manifacturers.FirstOrDefault(m => m.Name == varnishDto.Manifacturer);

                if (manifacturer == null)
                {
                    manifacturer = new Manifacturer
                    {
                        Name = varnishDto.Manifacturer
                    };
                    context.Manifacturers.Add(manifacturer);
                    context.SaveChanges();
                }

                var varnish = new Varnish
                {
                    Name = varnishDto.Name,
                    Manifacturer = manifacturer,
                    Price = varnishDto.Price,
                    DateOfPurchase = varnishDto.DateOfPurchase
                };

                validVarnishes.Add(varnish);
            }

            context.Varnishes.AddRange(validVarnishes);
            context.SaveChanges();
            return "All good";
        }

        public static string ImportTools(ScalemodelsDbContext context, string jsonString)
        {
            var deserializedTools = JsonConvert.DeserializeObject<ToolDto[]>(jsonString,
                new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

            var validTools = new HashSet<Tool>();

            foreach (var toolDto in deserializedTools)
            {
                var manifacturer = context.Manifacturers.FirstOrDefault(m => m.Name == toolDto.Manifacturer);

                if (toolDto.Manifacturer == null)
                {
                }
                else
                {
                    if (manifacturer == null)
                    {
                        manifacturer = new Manifacturer
                        {
                            Name = toolDto.Manifacturer
                        };
                        context.Manifacturers.Add(manifacturer);
                        context.SaveChanges();
                    }
                }

                var tool = new Tool
                {
                    Name = toolDto.Name,
                    Manifacturer = manifacturer,
                    Price = toolDto.Price,
                    DateOfPurchase = toolDto.DateOfPurchase,
                    Description = toolDto.Description
                };

                validTools.Add(tool);
            }

            context.Tools.AddRange(validTools);
            context.SaveChanges();
            return "All good";
        }

        public static string ImportModelShows(ScalemodelsDbContext context, string jsonString)
        {
            var deserializedModelShows = JsonConvert.DeserializeObject<ModelShowDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var sb = new StringBuilder();

            var validModelShows = new List<ModelShow>();
            foreach (var modelShowDto in deserializedModelShows)
            {
                if (!IsValid(modelShowDto))
                {
                    continue;
                }

                //    var categories = modelShowDto.Categories.Select(s => new ModelShowCategory
                //        {
                //            ModelShow = context.ModelShows.SingleOrDefault(sc => sc.Categories == s.CategoryId)
                //        })
                //        .ToArray();

                //    var train = new Train
                //    {
                //        TrainNumber = trainDto.TrainNumber,
                //        Type = type,
                //        TrainSeats = trainSeats
                //    };

                //    validTrains.Add(train);

                //    sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
            }

            //context.Trains.AddRange(validTrains);
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
