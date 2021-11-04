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

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }

        [DisplayName("Plays in")]
        public string ActualClub { get; set; }

        public string Genre { get; set; }
    }
}
