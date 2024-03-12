using MYCMS.Core.Dtos;
using MYCMS.Core.Dtos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Infrastructure.Services.Categories
{
    public interface ICategoryService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateCategoryDto dto);

        Task<int> Update(UpdateCategoryDto dto);

        Task<UpdateCategoryDto> Get(int Id);

        Task<int> Delete(int Id);
    }
}
