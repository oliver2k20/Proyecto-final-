using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// Modelo de la orden
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Porfavor entre su nombre")]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Porfavor entre su/s apellido/s")]
        [Display(Name = "Apellido/s")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Porfavor entre su dirección")]
        [StringLength(100)]
        [Display(Name = "Dirección 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Dirección 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Por favor entre su codigo Zip")]
        [Display(Name = "Codigo Zip")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Porfavor entre su ciudad")]
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string City { get; set; }
        [StringLength(100)]
        [Display(Name = "Estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "Porfavor entre su pais")]
        [StringLength(50)]
        [Display(Name ="Pais")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Por favor entre su numero telefonico")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "El email no tiene el formato correcto")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
        //Esto no se bindeara
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
