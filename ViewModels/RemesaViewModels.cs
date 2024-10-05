using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP_CAMPOS.Models;

namespace EP_CAMPOS.ViewModels
{
    public class RemesaViewModels
    {
        public Remesa? FormRemesa  {get; set;}
        public IEnumerable<Remesa>? ListRemesa  {get; set;}
    }
}