using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class MoveParameters : IParameters
    {
        [ParameterInfo(Name = "Сдвиг на (%)",
                    MinValue = 0,
                    MaxValue = 100,
                    DefaultValue = 0,
                    Increment = 5)]

        public double MoveInPercent { get; set; }
    }
}
