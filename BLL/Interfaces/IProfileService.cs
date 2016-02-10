using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IProfileService
    {
        IEnumerable<ProfileDTO> GetProfiles();
        ProfileDTO GetProfile(int? Id);
        ProfileDTO GetProfileByUserId(int? Id);
        void Create(ProfileDTO profile);
        void Update(ProfileDTO profile);
        void Delete(int Id);
    }
}
