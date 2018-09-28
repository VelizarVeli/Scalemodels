using AutoMapper;
using Scalemodels.DataProcessor.Dto;
using Scalemodels.Models;

namespace Scalemodels.App
{
   public class ScalemodelsProfile : Profile
    {
        public ScalemodelsProfile()
        {
            CreateMap<ManifacturerDto, Manifacturer>();
        }
    }
}
