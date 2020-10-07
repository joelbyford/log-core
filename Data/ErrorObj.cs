using System.ComponentModel.DataAnnotations;

namespace log_core.Data
{
    public class ErrorObj
    {
        [Range(1,1000)]
        public int Count { get; set; }
        [Required]
        public string Message { get; set; }
        [Range(0,5)]
        public int Level { get; set; }
    }
}