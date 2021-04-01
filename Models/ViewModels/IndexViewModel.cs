using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class IndexViewModel //the controller comes here to generate the page info displayed
    {
        public List<Bowlers> Bowlers { get; set; } //Creates a list of bowlers of Type Bowlers
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamTitle { get; set; }
    }
}
