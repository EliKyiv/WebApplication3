using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class FriendModel
    {
        [Required(ErrorMessage = "Friend ID is required.")]
        public int FriendID { get; set; }

        [Required(ErrorMessage = "Friend Name is required.")]
        [StringLength(25, ErrorMessage = "Friend Name cannot be longer than 25 characters.")]
        public string FriendName { get; set; }

        [StringLength(25, ErrorMessage = "Place cannot be longer than 25 characters.")]
        public string Place { get; set; }
    }
}
