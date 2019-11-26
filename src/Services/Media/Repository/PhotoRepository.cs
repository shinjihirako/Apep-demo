using System.Collections.Generic;
using System.Linq;
using ApepMediaMicroService.DBContexts;
using ApepMediaMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace ApepMediaMicroService.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotoContext _dbContext;

        public PhotoRepository(PhotoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeletePhoto(int PhotoId)
        {
            //TODO do this in one roundtrip 
            var photo = _dbContext.Photos.Find(PhotoId);
            _dbContext.Photos.Remove(photo);
            Save();
        }

        public Photo GetPhotoByID(int PhotoId)
        {
            return _dbContext.Photos.Find(PhotoId);
        }

        public IEnumerable<Photo> GetPhotos()
        {
            return _dbContext.Photos.ToList();
        }

        public void InsertPhoto(Photo Photo)
        {
            _dbContext.Add(Photo);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePhoto(Photo Photo)
        {
            _dbContext.Entry(Photo).State = EntityState.Modified;
            Save();
        }
    }
}
