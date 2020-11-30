using System;
using System.Text.Json.Serialization;

namespace Wealth.Models
{
    public class Account : IDto
    {
        [JsonPropertyName("pkAccountId")]
        public ulong Id { get; set; }

        [JsonPropertyName("fkPartnerId")]
        public uint PartnerId { get; set; }

        [JsonPropertyName("fkPartnerAdvisorId")]
        public uint? PartnerAdvisorId { get; set; }

        [JsonPropertyName("addFrom")]
        public short? AddFrom { get; set; }

        [JsonPropertyName("addIp")]
        public string AddIp { get; set; }

        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

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
