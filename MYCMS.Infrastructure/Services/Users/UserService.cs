using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MYCMS.Core.Constants;
using MYCMS.Core.Dtos;
using MYCMS.Core.Dtos.Helpers;
using MYCMS.Core.Exceptions;
using MYCMS.Core.ViewModels;
using MYCMS.Data.Models;
using MYCMS.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly CMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;

        public UserService(CMSDbContext db, IMapper mapper, UserManager<User> userManager
            , IFileService fileService, IEmailService emailService)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _emailService = emailService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination , Query query)
        {
            
            var queryString = _db.Users.Where(x => !x.IsDelete && (x.FullName.Contains(query.GeneralSearch) ||x.PhoneNumber.Contains(query.GeneralSearch) || x.Email.Contains(query.GeneralSearch) ||string.IsNullOrWhiteSpace(query.GeneralSearch) )).AsQueryable();

            var dataCount = queryString.Count();
            pagination.Total = dataCount;
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var users = _mapper.Map<List<UserViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);

            var result = new ResponseDto
            {
                data = users,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount
                }
            };

            return result;
        }
        public async Task<UpdateUserDto> Get(string id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateUserDto>(user);
        }
        public async Task<string> Create(CreateUserDto userDto)
        {
            var EmailOrPhoneIsExist = await _db.Users.AnyAsync(x => (x.Email == userDto.Email || x.PhoneNumber == userDto.PhoneNumber) && !x.IsDelete);
            if(EmailOrPhoneIsExist)
            {
                throw new UserInfoIsAlreadyExistException();
            }

            var user = _mapper.Map<User>(userDto);
            user.UserName = userDto.Email;

            if(userDto.ImageUrl != null)
            {
                user.ImageUrl =await _fileService.SaveFile(userDto.ImageUrl, FolderNames.ImagesFolder);
            }
            string Password = GeneratePassword();
            var result = await _userManager.CreateAsync(user, Password);
            if (!result.Succeeded)
            {
                throw new CreateUserFailedException();
            }
            await _emailService.Send(user.Email, "New Account!", $"Email : {user.Email} , Password : {Password}");
            return user.Id;
        }
        public async Task<string> Update(UpdateUserDto userDto)
        {
            var EmailOrPhoneIsExist = await _db.Users.AnyAsync(x => (x.Email == userDto.Email || x.PhoneNumber == userDto.PhoneNumber) && !x.IsDelete && x.Id != userDto.Id);
            if(EmailOrPhoneIsExist)
            {
                throw new UserInfoIsAlreadyExistException();
            }

            var user =await _db.Users.FindAsync(userDto.Id);
            var updatedUser = _mapper.Map<UpdateUserDto, User>(userDto , user);


            if(userDto.ImageUrl != null)
            {
                user.ImageUrl =await _fileService.SaveFile(userDto.ImageUrl, FolderNames.ImagesFolder);
            }
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return user.Id;
        }
        public async Task<string> Delete(string id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if(user == null)
            {
                throw new EntityNotFoundException();
            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }
        private string GeneratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 8); 
        }
    }
}
