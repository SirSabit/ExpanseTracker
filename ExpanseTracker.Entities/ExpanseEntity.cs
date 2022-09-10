using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanseTracker.Entities
{
    public class ExpanseEntity
    {
        public int ID { get; set; }

        public string? ExpanseName { get; set; }

        public decimal ExpanseAmount { get; set; }
        public DateTime ExpanseDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
