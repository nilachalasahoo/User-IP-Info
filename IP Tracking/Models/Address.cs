using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IP_Tracking.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Department")]
        public string ITR_Section { get; set; }


        [Required]
        [DisplayName("IP Address")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Please enter a valid IP address.")]
        public string IP_Address { get; set; }

        [Required]
        [DisplayName("MAC Address")]
        [RegularExpression(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$", ErrorMessage = "Please enter a valid MAC address.")]
        public string MAC_Address { get; set; }

        [Required]
        [DisplayName("Employee Name")]
        public string Employee_Name { get; set; }

        [Required]
        [DisplayName("Location")]
        public string Location { get; set; }

        [Required]
        [DisplayName("IO Number")]
        public int IO_Number { get; set; }

        [Required]
        [DisplayName("Switchport No.")]
        public int Switchport_No { get; set; }

        [Required]
        [DisplayName("Domain name")]
        public string Domain_Name { get; set; }

    }
}