using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class UserAddressDTO
    {
        public int UserAddressId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive integer.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Door number is required.")]
        [StringLength(50, ErrorMessage = "Door number must not exceed 50 characters.")]
        public string DoorNumber { get; set; }

        [StringLength(100, ErrorMessage = "Apartment name must not exceed 100 characters.")]
        public string? ApartmentName { get; set; }

        [StringLength(100, ErrorMessage = "Landmark must not exceed 100 characters.")]
        public string? Landmark { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(100, ErrorMessage = "Street must not exceed 100 characters.")]
        public string Street { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "City ID must be a positive integer.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Contact number must be a valid phone number.")]
        public string ContactNumber { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Status ID must be a positive integer.")]
        public int? StatusId { get; set; }

       



            public override string ToString()
        {
            string result = $"DoorNumber: {DoorNumber}";

            if (!string.IsNullOrEmpty(ApartmentName))
            {
                result += $" | ApartmentName: {ApartmentName}";
            }

            if (!string.IsNullOrEmpty(Landmark))
            {
                result += $" | Landmark: {Landmark}";
            }

            result += $" | Street: {Street}  | PostalCode: {PostalCode} | ContactNumber: {ContactNumber}";

            return result;
        }
    }
    }

    
