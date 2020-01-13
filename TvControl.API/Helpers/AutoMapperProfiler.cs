using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvControl.API.Dtos;
using TvControl.API.Models;

namespace TvControl.API.Helpers
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<MovieToBeRegisteredDto, Movie>();
        }
    }
}
