using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class DbRepository
    {
        private ICar _car;

        public DbRepository(ICar car)
        {
            _car = car;
        }

        public void AddDB ()
        {
        
        }
    }
}
