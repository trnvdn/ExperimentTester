using AutoMapper;
using ExperimentTester.Models;
using ExperimentTester.Models.Dto;

namespace ExperimentTester
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Experiment, ExperimentDto>().ReverseMap();
                cfg.CreateMap<Participant, ParticipantDto>().ReverseMap();
            });

            return config;
        }
    }
}
