using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.Person;

public class UpdatePersonDTO
{       
        [MaxLength(100)]
        [Required]
        public required string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public required string Surname { get; set; }
        public required int Age { get; set; }

        [MaxLength(100)]
        [Required]
        public required string Mail { get; set; }

        [MaxLength(20)]
        [Required]
        public required string NationalID { get; set; }

        [MaxLength(10)]
        [Required]
        public required string Gender { get; set; }

        [MaxLength(20)]
        [Required]
        public required string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
}