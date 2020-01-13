using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvControl.API.DataLayer;
using TvControl.API.Dtos;
using TvControl.API.Models;

namespace TvControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository, IConfiguration config, IMapper mapper)
        {
            _movieRepo = movieRepository;
            _configuration = config;
            _mapper = mapper;
        }

        [HttpGet("getmovies", Name = "GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                var allMovies = await _movieRepo.GetMovies();

                return Ok(allMovies);
            }
            catch (Exception)
            {

                return BadRequest("Please try again later");
            }
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<IActionResult> GetMovie()
        {
            try
            {
                var allMovies = await _movieRepo.GetMovies();

                return Ok(allMovies);
            }
            catch (Exception)
            {

                return BadRequest("Please try again later");
            }
        }

        [HttpPost("addmovie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieToBeRegisteredDto movieToBeRegisteredDto)
        {
            var contributor = await _movieRepo.GetContributor(movieToBeRegisteredDto.ContributorName);
            var movieToCreate = _mapper.Map<Movie>(movieToBeRegisteredDto);
            try
            {
                if (contributor == null)
                {
                    var contributorToBeAdded = new Contributor
                    {
                        Name = movieToBeRegisteredDto.ContributorName,
                        Description = "I`m not sure what to put here",
                        Title = " some title"
                    };

                    var addContributor = _movieRepo.AddContributor(contributorToBeAdded);
                    movieToCreate.Contributors.Add(addContributor);
                }


                var createdMovie = await _movieRepo.AddMovie(movieToCreate);

                return CreatedAtRoute("GetMovie", new { controller = "Movie", id = movieToCreate.ID }, movieToCreate);
            }
            catch (Exception)
            {

                throw new Exception("Something terrible happened");
            }

           
        }
    }
}
