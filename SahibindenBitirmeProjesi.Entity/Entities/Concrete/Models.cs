using Microsoft.AspNetCore.Http;
using SahibindenBitirmeProjesi.Entity.Entities.Interfaces;
using SahibindenBitirmeProjesi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SahibindenBitirmeProjesi.Entity.Entities.Concrete
{
    public class Models:IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Year { get; set; }        //Yıl
        public string Fuel { get; set; }        //Yakıt
        public string Gear { get; set; }        //Vites
        public int HorsePower { get; set; }     //Beygir
        public string Color { get; set; }       //Renk
        public string Description { get; set; } //Açıklama
        public string Image { get; set; }          //Fotoğraf

        [Column(TypeName ="decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public IFormFile ImageUpload{ get; set; }

        //IBaseEntity implement
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        [Display(Name ="Cars")]
        [Range(1,int.MaxValue,ErrorMessage ="You must to choose a cars")]
        public int CarsId { get; set; }

        [ForeignKey("CarsId")]
        public virtual Cars Cars { get; set; }
    }
}
