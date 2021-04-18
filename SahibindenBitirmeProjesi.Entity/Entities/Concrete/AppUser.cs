using Microsoft.AspNetCore.Identity;
using SahibindenBitirmeProjesi.Entity.Entities.Interfaces;
using SahibindenBitirmeProjesi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahibindenBitirmeProjesi.Entity.Entities.Concrete
{
    public class AppUser: IdentityUser,IBaseEntity
    {
        //IBaseEntity implement
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
        
    }
}
