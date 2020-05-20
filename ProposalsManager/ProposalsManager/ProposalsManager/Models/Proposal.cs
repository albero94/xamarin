using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProposalsManager.Models
{
    public class Proposal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
        public DateTime IssuedDate { get; set; } = DateTime.Today;
        public DateTime SubmittedDate { get; set; } = DateTime.Today;
        public DateTime DueDate { get; set; } = DateTime.Today;
        public bool IsPrime { get; set; }
        public String LastUpdatedBy { get; set; } = "Noone";

    }
}
