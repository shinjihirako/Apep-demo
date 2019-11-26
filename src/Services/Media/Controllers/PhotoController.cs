using ApepMediaMicroService.Models;
using ApepMediaMicroService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ApepMediaMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    { 
        private readonly IPhotoRepository _photoRepository;
        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var photos = _photoRepository.GetPhotos();
            return new OkObjectResult(photos);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var photo = _photoRepository.GetPhotoByID(id);
            return new OkObjectResult(photo);
        }


        [HttpPost("Create")]
        public IActionResult Post([FromBody] Photo photo)
        {
            using (var scope = new TransactionScope())
            {
                _photoRepository.InsertPhoto(photo);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = photo.Id }, photo);
            }
        }

        [HttpPut("Edit")]
        public IActionResult Put([FromBody] Photo photo)
        {
            if(photo != null)
            {
                using (var scope = new TransactionScope())
                {
                    _photoRepository.UpdatePhoto(photo);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete(int id)
        {
            _photoRepository.DeletePhoto(id);
            return new OkResult();
        }
    }
}