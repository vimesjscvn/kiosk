using System;
using System.Collections.Generic;
using System.Linq;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Models;
using static CS.Common.Common.Constants;

namespace CS.VM.Adapters
{
    /// <summary>
    ///     The data adapter.
    /// </summary>
    public static class DataAdapter
    {
        public static Role ToModel(RoleViewModel roleViewModel)
        {
            return new Role
            {
                Id = roleViewModel.Id,
                Code = roleViewModel.Code,
                Name = roleViewModel.Name,
                Description = roleViewModel.Description,
                IsActive = roleViewModel.IsActive,
                CreatedBy = Systems.CreatedBy,
                UpdatedBy = Systems.UpdatedBy,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }

        public static SysUser ToModel(SysUserViewModel user)
        {
            return new SysUser
            {
                Id = user.Id,
                Type = user.Type,
                FullName = user.FullName,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
                Token = user.Token,
                TokenExp = user.TokenExp,
                LastLogin = user.LastLogin,
                UserName = user.UserName,
                ImageUrl = user.ImageUrl,
                DataType = user.DataType,
                Sex = user.Sex,
                BirthDate = user.BirthDate,
                TitleId = user.Title,
                PositionId = user.Position,
                IsDeleted = user.IsDeleted,
                IsActive = user.IsActive,
                Code = user.Code,
                CreatedBy = Systems.CreatedBy,
                UpdatedBy = Systems.UpdatedBy,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }

        public static PermissionViewModel ToViewModel(Permission permission)
        {
            return new PermissionViewModel
            {
                Id = permission.Id,
                Code = permission.Code,
                Description = permission.Description,
                IsActive = permission.IsActive
            };
        }

        public static RoleViewModel ToViewModel(Role type)
        {
            return new RoleViewModel
            {
                Id = type.Id,
                Code = type.Code,
                Name = type.Name,
                Description = type.Description,
                IsActive = type.IsActive
            };
        }

        public static SysUserViewModel ToViewModel(SysUser user)
        {
            return new SysUserViewModel
            {
                Id = user.Id,
                Type = user.Type,
                FullName = user.FullName,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
                Token = user.Token,
                TokenExp = user.TokenExp,
                LastLogin = user.LastLogin,
                UserName = user.UserName,
                ImageUrl = user.ImageUrl,
                DataType = user.DataType,
                Sex = user.Sex,
                BirthDate = user.BirthDate,
                Title = user.TitleId,
                Position = user.PositionId,
                TitleDescription = user.Title?.Description,
                PositionDescription = user.Position?.Description,
                IsDeleted = user.IsDeleted,
                IsActive = user.IsActive,
                Code = user.Code,
                Role = user.Role != null ? ToViewModel(user.Role) : null,
                Permissions = user.Permissions?.Select(ToViewModel).ToList()
            };
        }

        public static ListValueViewModel ToViewModel(ListValue data)
        {
            return new ListValueViewModel
            {
                Id = data.Id,
                Description = data.Description,
                Code = data.Code,
                Type = data.Type,
                DisplayOrder = data.DisplayOrder,
                ListValueTypeId = data.ListValueTypeId,
                IsActive = data.IsActive,
                IsSystem = data.IsSystem,
                IsDeleted = data.IsDeleted,
                CreatedBy = data.CreatedBy,
                CreatedDate = data.CreatedDate.Truncate(TimeSpan.TicksPerSecond),
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate.Truncate(TimeSpan.TicksPerSecond)
            };
        }

        public static UserProfileViewModel ToViewModel(SysUser user, IEnumerable<ListValue> listTitles,
            IEnumerable<ListValue> listPositions)
        {
            return new UserProfileViewModel
            {
                Type = user.Type,
                FullName = user.FullName,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
                Token = user.Token,
                TokenExp = user.TokenExp,
                LastLogin = user.LastLogin,
                UserName = user.UserName,
                ImageUrl = user.ImageUrl,
                Sex = user.Sex,
                BirthDate = user.BirthDate,
                Title = user.TitleId,
                ListTitles = listTitles.Select(ToViewModel).ToList(),
                Position = user.PositionId,
                ListPositions = listPositions.Select(ToViewModel).ToList(),
                IsDeleted = user.IsDeleted,
                IsActive = user.IsActive,
                Code = user.Code
            };
        }
    }
}