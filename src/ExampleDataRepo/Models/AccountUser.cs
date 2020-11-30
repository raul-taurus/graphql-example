using System;
using System.Text.Json.Serialization;

namespace Wealth.Models
{
    public class AccountUser : IDto
    {
        [JsonPropertyName("pkAccountUserId")]
        public ulong Id { get; set; }

        [JsonPropertyName("fkAccountId")]
        public ulong AccountId { get; set; }

        [JsonPropertyName("fkPartnerId")]
        public uint PartnerId { get; set; }

        [JsonPropertyName("userType")]
        public short UserType { get; set; }

        [JsonPropertyName("isDefaultUser")]
        public bool IsDefaultUser { get; set; }

        [JsonPropertyName("loginName")]
        public string LoginName { get; set; }

        [JsonPropertyName("loginPassword")]
        public string LoginPassword { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("dateOfBirthday")]
        public string DateOfBirthday { get; set; }

        [JsonPropertyName("maritalStatus")]
        public string MaritalStatus { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("addFrom")]
        public short? AddFrom { get; set; }

        [JsonPropertyName("addIp")]
        public string AddIp { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTimeOffset CreationDate { get; set; }

        [JsonPropertyName("modificationDate")]
        public DateTimeOffset? ModificationDate { get; set; }
    }
}
