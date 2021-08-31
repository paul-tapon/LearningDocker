using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Domain.Entities
{
    public class AppUser
    {
        public AppUser()
        {

        }

        #region Columns / Properties

        public int AppUserId { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Qualifier { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool? IsLocalNetworkUser { get; set; }
        public bool? IsActivated { get; set; }
        public Guid CustomerUniqueId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedByAppUserId { get; set; }
        public AppUser CreatedByAppUser { get; set; }
        public int? LastModifiedByAppUserId { get; set; }
        public AppUser LastModifiedByAppUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string ForgotPasswordUrlParam { get; set; }
        public DateTime? ForgotPasswordExpiryDate { get; set; }

        #endregion

        #region Navigational Properties
        #endregion

    }
}
