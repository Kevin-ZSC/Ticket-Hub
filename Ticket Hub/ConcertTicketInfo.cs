using System.ComponentModel.DataAnnotations;
namespace Ticket_Hub
{
    public class ConcertTicketInfo
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Concert ID must be a positive number")]
        public int ConcertId { get; set; } = 0;

        [Required, EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required, RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phone { get; set; } = string.Empty;

        [Required, Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10 tickets")]
        public int Quantity { get; set; } = 0;

        [Required, CreditCard(ErrorMessage = "Please provide a valid credit card number")]
        public string CreditCard { get; set; } = string.Empty;

        [Required, RegularExpression(@"^(0[1-9]|1[0-2])\/([0-9]{2})$", ErrorMessage = "Expiration date must be in MM/YY format")]
        public string Expiration { get; set; } = string.Empty;

        [Required, RegularExpression(@"^\d{3}$", ErrorMessage = "Security code must be 3 digits")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required, StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Address { get; set; } = string.Empty;

        [Required, StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string City { get; set; } = string.Empty;

        [Required, StringLength(50, ErrorMessage = "Province/State cannot exceed 50 characters")]
        public string Province { get; set; } = string.Empty;

        [Required, RegularExpression(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$",ErrorMessage = "Please provide a valid Canadian postal code (e.g., A1B 0A1)")]
        public string PostalCode { get; set; } = string.Empty;

        [Required, StringLength(50, ErrorMessage = "Country cannot exceed 50 characters")]
        public string Country { get; set; } = string.Empty;
    }
}