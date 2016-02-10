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
    public class RoleService : IRoleService
    {
        IUnitOfWork Database { get; set; }
        public RoleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            Mapper.CreateMap<Role, RoleDTO>();
            return Mapper.Map<IEnumerable<Role>, List<RoleDTO>>(Database.Roles.GetAll());
        }

        public IEnumerable<UserDTO> GetAllUsersInRole(string name)
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetRole(int? id)
        {
            if (id == null)
                throw new ValidationException("This role not found!", "");
            var role = Database.Roles.Get((int)id);
            if (role == null)
                throw new ValidationException("This role not found!", "");
            Mapper.CreateMap<Role, RoleDTO>();
            return Mapper.Map<Role, RoleDTO>(role);
        }
    }
}
