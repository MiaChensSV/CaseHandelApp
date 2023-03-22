using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseHandelApp.Contexts;
using CaseHandelApp.Models.Entities;
using CaseHandelApp.Models.Form;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Services
{
    internal class UserService
    {
        private readonly DataContext _context = new DataContext();
        public async Task<UserEntity> CreateUser(UserRegistrationForm form)
        {
            if (!_context.Users.Any(x => x.Email == form.Email))
            {
                Guid _id = Guid.NewGuid();
                var _addressEntity = new AddressEntity()
                {
                    StreetName = form.StreetName,
                    PostalCode = form.PostalCode,
                    City = form.City,
                };
                var _userTypeEntity = new UserTypeEntity()
                {
                    UserType = form.UserTypeName,
                };
                if(!_context.Addresses.Any(x=>x.StreetName==form.StreetName && x.City==form.City))
                {
                    _context.Addresses.Add(_addressEntity);
                    _context.SaveChanges();
                }
                else
                {
                    _addressEntity = _context.Addresses.FirstOrDefault(x => x.StreetName == form.StreetName && x.City == form.City);
                }
                
                if (!_context.UsersType.Any(x => x.UserType == form.UserTypeName))
                {
                    _context.UsersType.Add(_userTypeEntity);
                    _context.SaveChanges();
                }
                else
                {
                    _userTypeEntity = _context.UsersType.FirstOrDefault(element => element.UserType == form.UserTypeName);
                }
                var userEntity = new UserEntity()
                {
                    Id = _id,
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    PhoneNumber = form.PhoneNumber,
                    AddressId = _addressEntity!.Id,
                    UserTypeId = _userTypeEntity!.Id,
                };
                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();
                return userEntity;
            }
            else return null!;
        }
        public async Task<UserEntity> GetUser(string email)
        {
            var _user= await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (_user != null)
            {
                return _user;
            }
            else return null!;
        }
    }
}
