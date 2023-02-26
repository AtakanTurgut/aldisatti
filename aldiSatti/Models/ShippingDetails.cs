using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aldiSatti.Models
{
    public class ShippingDetails
    {
        public string userName { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Giriniz!")]
        public string address { get; set; }
        [Required(ErrorMessage = "Lütfen Şehir Giriniz!")]
        public string city { get; set; }
        [Required(ErrorMessage = "Lütfen Semt Giriniz!")]
        public string district { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle Giriniz!")]
        public string quarter { get; set; }
        [Required(ErrorMessage = "Lütfen Posta Kodu Giriniz!")]
        public string postCode { get; set; }
    }
}