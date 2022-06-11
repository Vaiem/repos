using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace BlogDesing.Models
{
    public class DisignCreate
    {
        string _nameDesing;
        IFormFile filePhoto;
        public DisignCreate(string NameDesing, IFormFile formFile)
        {
            _nameDesing = NameDesing;
            filePhoto = formFile;
        }

        public Desing GetDesing {
            get
            {
                byte[] photo;
                using (BinaryReader readUser = new BinaryReader(this.filePhoto.OpenReadStream()))
                {
                    photo = readUser.ReadBytes((int)this.filePhoto.Length);
                }
                
               
                return new Desing {Name = _nameDesing,PhotoOne = photo };
            }
        }




    }
}
