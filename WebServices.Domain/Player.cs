using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebServices.Domain
{
    public class Player
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of birth"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM yyyy}")]
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
        [DisplayName("Plays in")]
        public string ActualClub { get; set; }
        public string Genre { get; set; }
    }
}
