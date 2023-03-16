using Microsoft.AspNetCore.Identity;

namespace Catalog.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// MiddleName
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
    }
}
