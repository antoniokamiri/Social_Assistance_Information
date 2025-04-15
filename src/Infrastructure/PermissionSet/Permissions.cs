using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.PermissionSet;
public static partial class Permissions
{
    /// <summary>
    ///     Returns a list of Permissions.
    /// </summary>
    /// <returns></returns>
    public static List<string> GetRegisteredPermissions()
    {
        var permissions = new List<string>();
        foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c =>
                     c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
        {
            var propertyValue = prop.GetValue(null);
            if (propertyValue is not null)
                permissions.Add((string)propertyValue);
        }

        return permissions;
    }

    [DisplayName("User Permissions")]
    [Description("Set permissions for user operations.")]
    public static class Users
    {
        public const string View = "Permissions.Users.View";
        public const string Create = "Permissions.Users.Create";
        public const string Edit = "Permissions.Users.Edit";
        public const string Delete = "Permissions.Users.Delete";
        public const string Search = "Permissions.Users.Search";
        public const string Import = "Permissions.Users.Import";
        public const string Export = "Permissions.Dictionaries.Export";
        public const string ManageRoles = "Permissions.Users.ManageRoles";
        public const string RestPassword = "Permissions.Users.RestPassword";
        public const string SendRestPasswordMail = "Permissions.Users.SendRestPasswordMail";
        public const string ManagePermissions = "Permissions.Users.Permissions";
        public const string Deactivation = "Permissions.Users.Activation/Deactivation";
    }

    [DisplayName("Role Permissions")]
    [Description("Set permissions for role operations.")]
    public static class Roles
    {
        public const string View = "Permissions.Roles.View";
        public const string Create = "Permissions.Roles.Create";
        public const string Edit = "Permissions.Roles.Edit";
        public const string Delete = "Permissions.Roles.Delete";
        public const string Search = "Permissions.Roles.Search";
        public const string Export = "Permissions.Roles.Export";
        public const string Import = "Permissions.Roles.Import";
        public const string ManagePermissions = "Permissions.Roles.Permissions";
        public const string ManageNavigation = "Permissions.Roles.Navigation";
    }

}

public static partial class Permissions
{
    [DisplayName("Applicants Permissions")]
    [Description("Set permissions for applicant operations.")]
    public static class Applicants
    {

        [Description("Allows viewing applicant details.")]
        public const string View = "Permissions.Applicants.View";

        [Description("Allows creating applicant details.")]
        public const string Create = "Permissions.Applicants.Create";

        [Description("Allows editing applicant details.")]
        public const string Edit = "Permissions.Applicants.Edit";

        [Description("Allows deleting applicant details.")]
        public const string Delete = "Permissions.Applicants.Delete";

        [Description("Allows print applicant details.")]
        public const string Print = "Permissions.Applicants.Print";

        [Description("Allows searching applicant details.")]
        public const string Search = "Permissions.Applicants.Search";

        [Description("Allows exporting applicant details.")]
        public const string Export = "Permissions.Applicants.Export";
    }



    [DisplayName("Locations Permissions")]
    [Description("Set permissions for locations operations.")]
    public static class Locations
    {
        public const string View = "Permissions.Locations.View";
        public const string Create = "Permissions.Locations.Create";
        public const string Edit = "Permissions.Locations.Edit";
        public const string Delete = "Permissions.Locations.Delete";
        public const string Search = "Permissions.Locations.Search";
        public const string Export = "Permissions.Locations.Export";
        public const string Import = "Permissions.Locations.Import";
    }
}
