using Kohde.Assessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment {
    public class Animal : Being , IAminal{

        public Animal(Animal animal){
        }

        public Animal() {
        }
        public string Food { get; set; }
    }


    
}
