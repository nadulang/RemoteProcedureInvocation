using System;
using System.ComponentModel.DataAnnotations;

namespace UserService.Domain.Entities
{
    public class Users_
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string address { get; set; }
    }
}
