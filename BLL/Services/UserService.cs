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
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("User with this ID not foudn!", "");
            var user = Database.Users.Get((int)id);
            if (user == null)
                throw new ValidationException("This user not found!","");
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<User, UserDTO>(user);
        }

        public UserDTO GetUserByEmail(string email)
        {
            if (email == null)
                throw new ValidationException("Uncorrect email!", "");
            IEnumerable<User> users = Database.Users.GetAll();
            var user = Database.Users.GetAll().FirstOrDefault(u=>u.Email==email);
            if (user == null)
                return null;
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<User, UserDTO>(user);
        }

        public void Create(UserDTO user)
        {
            User u = new User
            {
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId
            };
            Database.Users.Create(u);
            Database.Save();

            DAL.Entities.Profile prof = new DAL.Entities.Profile
            {
                 FirstName = "Undefined",
                 LastName = "Undefined",
                 Age = 0,
                 CreationDate = DateTime.Now,
                 UserId = u.Id
            };
            Database.Profiles.Create(prof);
            Database.Save();
        }

        public void Delete(int Id)
        {
            Database.Users.Delete(Id);
        }

        public void Update(UserDTO user)
        {
            Mapper.CreateMap<UserDTO, User>();
            User updateUser = Mapper.Map<UserDTO, User>(user);
            Database.Users.Update(updateUser);
        }
    }
}
