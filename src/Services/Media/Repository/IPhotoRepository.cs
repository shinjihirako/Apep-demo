using ApepMediaMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApepMediaMicroService.Repository
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetPhotos();
        Photo GetPhotoByID(int PhotoId);
        void InsertPhoto(Photo Photo);
        void DeletePhoto(int PhotoId);
        void UpdatePhoto(Photo Photo);
        void Save();
    }
}
