using System;
using System.Text.Json.Serialization;

namespace Wealth.Models
{
    public class AccountInstitution : IDto
    {
        [JsonPropertyName("pkAccountInstitutionId")]
        public ulong Id { get; set; }

        [JsonPropertyName("fkAccountId")]
        public ulong AccountId { get; set; }

        [JsonPropertyName("fkInstitutionId")]
        public uint InstitutionId { get; set; }

        [JsonPropertyName("fkAccountUserIdAdded")]
        public ulong AccountUserIdAdded { get; set; }

        [JsonPropertyName("integrationLoginUser")]
        public string IntegrationLoginUser { get; set; }

        [JsonPropertyName("integrationLoginPwd")]
        public string IntegrationLoginPwd { get; set; }

        [JsonPropertyName("integrationItemId")]
        public string IntegrationItemId { get; set; }

        [JsonPropertyName("integrationAccessToken")]
        public string IntegrationAccessToken { get; set; }

        [JsonPropertyName("integrationClientid")]
        public string IntegrationClientid { get; set; }

        [JsonPropertyName("integrationStatus")]
        public string IntegrationStatus { get; set; }

        [JsonPropertyName("integrationAvailableProducts")]
        public string IntegrationAvailableProducts { get; set; }

        [JsonPropertyName("integrationBilledProducts")]
        public string IntegrationBilledProducts { get; set; }

        [JsonPropertyName("integrationError")]
        public string IntegrationError { get; set; }

        [JsonPropertyName("integrationConsentExpirationTime")]
        public DateTimeOffset? IntegrationConsentExpirationTime { get; set; }

        [JsonPropertyName("addFrom")]
        public short? AddFrom { get; set; }

        [JsonPropertyName("addIp")]
        public string AddIp { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("lastInitDate")]
        public DateTimeOffset? LastInitDate { get; set; }

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
