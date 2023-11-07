using AuthApp.Data;
using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public class UserService //: GenericRepository<User>
    { 
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly AuthDBContext context;
       
        public UserService(UserManager<User> userManager, AuthDBContext context, IMapper mapper) //: base(context)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            user.Id = Guid.NewGuid().ToString();
            return await userManager.CreateAsync(user,password);
        }


        public async Task<IdentityResult> CreateAsync(User user)    //No password
        {
            user.Id = Guid.NewGuid().ToString();
            return await userManager.CreateAsync(user);
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<User> FindUserByIdAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<bool> UserExist(string email)
        {
            var user = await FindUserByEmailAsync(email);

            return user != null;
        }

        public async Task<IdentityResult> AddRoles(RolesDto rolesDto)
        {
            if (rolesDto.Roles == null)
                rolesDto.Roles.Add("User");   //Set Default Role if Null

            var user = await FindUserByIdAsync(rolesDto.Id);
            
            var results = await userManager.AddToRolesAsync(user, rolesDto.Roles);

            return results;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
        public Task Update(string id, UserDto userDto)
        {          
            
            //context.Entry(user).State = EntityState.Modified;
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await userManager.GetRolesAsync(user);
        }

       

        public async Task<int> Update(UserDto userDto)
        {
            var entity = context.Users.First(x => x.Id == userDto.Id);

            if (entity == null)
                return 0;

            if (userDto.Firstname != null)
                entity.Firstname = userDto.Firstname;

            if (userDto.Lastname != null)
                entity.Lastname = userDto.Lastname;
                        

            if (userDto.PhoneNumber != null)
                entity.PhoneNumber = userDto.PhoneNumber;

            //context.Users.Add(entity);
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //await userManager.AddToRolesAsync(user, userDto.Roles);

            var results = await context.SaveChangesAsync();

            return results;
        }

        public async Task<IdentityResult> ChangePassword(string id, string currentPassword, string newPassword)
        {
            var user = context.Users.First(x => x.Id == id);
            var results = await userManager.ChangePasswordAsync(user,currentPassword, newPassword);

            return results;
        }
    }
}
