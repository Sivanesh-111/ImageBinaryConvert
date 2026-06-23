using System.ComponentModel.DataAnnotations;

namespace ImageBinaryConvert.Models
{
    public class Client
    {
        [Key]
        public short CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string EmailLogo { get; set; }

        public byte[]? BinaryData { get; set; }
    }
}