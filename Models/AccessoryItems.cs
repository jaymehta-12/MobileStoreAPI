using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    

    public class AccessoryItems
    {
        [Key]
        public int AId { get; set; }
        public string AName { get; set; }

        public int APrice { get; set; }

        public int Id { get; set; }

        public MobileItems MobileItems { get; set; }


    }
}
