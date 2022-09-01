using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badyet.App.Models
{
    public class Payout
    {
        public DateOnly PayoutDate { get; set; }
        public decimal Amount { get; set; }
    }
}
