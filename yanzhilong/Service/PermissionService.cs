using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class PermissionService
    {
        private readonly UserService _UserService;
        private readonly RolePermissionRecordServiceMB _RolePermissionRecordServiceMB;


        public PermissionService(UserService userService,
            RolePermissionRecordServiceMB rolePermissionRecordServiceMB)
        {
            this._UserService = userService;
            this._RolePermissionRecordServiceMB = rolePermissionRecordServiceMB;
        }

        public bool Authorize(string SystemName)
        {
            foreach (var role in _UserService.CurrentUser.UserRoles)
                if (Authorize(SystemName, role))
                    //yes, we have such permission
                    return true;

            //no permission found
            return false;
        }

        protected virtual bool Authorize(string SystemName, Role customerRole)
        {
            if (String.IsNullOrEmpty(SystemName))
                return false;

            foreach (var PermissionRecord in customerRole.PermissionRecords)
                if (PermissionRecord.SystemName.Equals(SystemName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }
    }
}