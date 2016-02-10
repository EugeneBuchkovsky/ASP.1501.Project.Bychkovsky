using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using BLL.Infrastructure;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using AutoMapper;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        IUnitOfWork Database { get; set; }

        public ProfileService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ProfileDTO> GetProfiles()
        {
            Mapper.CreateMap<DAL.Entities.Profile, ProfileDTO>();
            return Mapper.Map<IEnumerable<DAL.Entities.Profile>, List<ProfileDTO>>(Database.Profiles.GetAll());
        }

        public ProfileDTO GetProfile(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Profile with this ID not foudn!", "");
            var profile = Database.Profiles.Get((int)Id);
            if (profile == null)
                throw new ValidationException("This profile not found!", "");
            Mapper.CreateMap<DAL.Entities.Profile, ProfileDTO>();
            return Mapper.Map<DAL.Entities.Profile, ProfileDTO>(profile);
        }

        public void Create(ProfileDTO profile)
        {
            DAL.Entities.Profile newProfile = new DAL.Entities.Profile
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Age = profile.Age,
                CreationDate = DateTime.Now,
                UserId = profile.UserId
            };
            Database.Profiles.Create(newProfile);
            Database.Save();
        }

        public void Update(ProfileDTO profile)
        {
            Mapper.CreateMap<ProfileDTO, DAL.Entities.Profile>();
            //var updateProfile = Mapper.Map<ProfileDTO, DAL.Entities.Profile>(profile);
            Database.Profiles.Update(Mapper.Map<ProfileDTO, DAL.Entities.Profile>(profile));
            Database.Save();
        }

        public void Delete(int Id)
        {
            Database.Profiles.Delete(Id);
        }

        public ProfileDTO GetProfileByUserId(int? Id)
        {
            Mapper.CreateMap<DAL.Entities.Profile, ProfileDTO>();
            return Mapper.Map<DAL.Entities.Profile, ProfileDTO>(Database.Profiles.GetAll().FirstOrDefault(p => p.UserId == Id));
        }
    }
}
