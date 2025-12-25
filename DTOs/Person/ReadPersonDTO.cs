using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.Person;

public class ReadPersonDTO
{
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string? Name { get; set; }
        
        [MaxLength(100)]
        public string? Surname { get; set; }
        public int? Age { get; set; }

        [MaxLength(100)]
        
        public string? Mail { get; set; }
        
        [MaxLength(20)]
        public string? NationalID { get; set; }
        
        [MaxLength(10)]
        public string? Gender { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
}