using EFMovieRentalDomain.Models;
using Microsoft.AspNetCore.Mvc;
using MovieTag.Domain;
using MoviRentalApi.Models;
using Tag.Domain;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTagController : ControllerBase
    {
        private readonly ILogger<MovieTagController> _logger;
        private readonly IMovieTagService _movieTagService;

        public MovieTagController(ILogger<MovieTagController> logger, IMovieTagService movieTagService)
        {
            _logger = logger;
            _movieTagService = movieTagService;
        }

        [HttpGet("ByTag/{Id}")]
        public async Task<List<MovieTagsDetail>> GetByTag(int Id)
        {
            var movies = await _movieTagService.GetMovieTagsByTag(Id);
            return movies;
        }

        [HttpGet("ByMovie/{Id}")]
        public async Task<List<MovieTagsDetail>> GetByMovie(int Id)
        {
            var movies = await _movieTagService.GetMovieTagsByMovie(Id);
            return movies;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] MovieTagData movieTagData)
        {
            var response = await _movieTagService.Post(movieTagData.moveiId, movieTagData.tagId);
            return response;
        }

        [HttpDelete]
        public async Task<string> Delete([FromBody] MovieTagData movieTagData)
        {
            var response = await _movieTagService.Delete(movieTagData.moveiId, movieTagData.tagId);
            return response;
        }
    }

}
