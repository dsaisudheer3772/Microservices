using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRM.Core.Models
{
    [Index(nameof(Device.devicename), IsUnique = true)]
    public class Device
    {
        [Key]
        public long deviceid { get; set; }
        public string? devicename { get; set; }

    }
}
