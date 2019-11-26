
using System;

namespace ApepMediaMicroService.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Tag { get; set; }
        public int GroupId { get; set; }
    }
}
