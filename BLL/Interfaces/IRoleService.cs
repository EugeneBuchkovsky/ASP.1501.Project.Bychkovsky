using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> GetAll();
        IEnumerable<UserDTO> GetAllUsersInRole(string name);
        RoleDTO GetRole(int? id);
    }
}
