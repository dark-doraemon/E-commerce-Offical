using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string hoten { get; set; }   
        public int tuoi { get; set; }   
        public int gioitinh { get; set; }
        public string cccd { get; set; }
        public string sdt { get; set; } 
        public string diachi { get; set; }
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }    
    }
}
