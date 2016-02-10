using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUser(int? Id);
        UserDTO GetUserByEmail(string email);
        void Create(UserDTO user);
        void Update(UserDTO user);
        void Delete(int Id);
    }
}
