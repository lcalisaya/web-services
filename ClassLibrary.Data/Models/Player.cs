using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string ActualClub { get; set; }
        public string Genre { get; set; }
    }
}
