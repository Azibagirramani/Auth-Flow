using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NgGold.Models;

namespace NgGold.Models
{

    [Table("business")]
    public class Business
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Key]
        [Column("cac_doc")]
        public string? Cac_doc { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("state")]
        public string? State { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("is_active")]
        public bool Is_active { get; set; }

        [Column("currency")]
        public string? Currency { get; set; }


        [Column("trial_ends")]
        public DateTime Trial_ends { get; set; }


        [Column("estimated_income")]
        public uint Estimated_income { get; set; }


        [Column("subscription")]
        public uint Subscription { get; set; }


        [Column("subsidiary_of")]
        public uint Subsidiary_of { get; set; }

        [Column("is_verified")]
        public bool Is_verified { get; set; }

        [Column("created_by")]
        public Guid? Created_by { get; set; }

    }

}