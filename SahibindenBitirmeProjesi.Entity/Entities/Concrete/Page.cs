using SahibindenBitirmeProjesi.Entity.Entities.Interfaces;
using SahibindenBitirmeProjesi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SahibindenBitirmeProjesi.Entity.Entities.Concrete
{
    public class Page :IBaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Must type a title")]
        [MinLength(5, ErrorMessage = "Minimum lenght is 5")]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required(ErrorMessage = "Must type a content")]
        [MinLength(5, ErrorMessage = "Minimum lenght is 5")]
        public string Content { get; set; }

        public int? Sorting { get; set; }

        //IBaseEntity implement
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
