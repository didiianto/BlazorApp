using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public class EventRegistration
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string? Gender { get; set; }

        //[Required(ErrorMessage = "At least one interest must be selected.")]
        public string? Interests { get; set; }
    }
}
