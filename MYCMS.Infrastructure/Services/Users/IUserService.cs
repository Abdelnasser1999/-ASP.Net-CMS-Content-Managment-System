using MYCMS.Core.Dtos;
using MYCMS.Core.Dtos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<UpdateUserDto> Get(string id);
        Task<string> Create(CreateUserDto userDto);
        Task<string> Update(UpdateUserDto userDto);
        Task<string> Delete(string id);
    }
}
