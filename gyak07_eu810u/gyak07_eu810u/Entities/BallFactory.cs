using gyak07_eu810u.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak07_eu810u.Entities
{
    public class BallFactory : IToyFactory
    {

        public Toy CreateNew()
        {
            return new Ball();
        
        }
    }
}
