using Kohde.Assessment.Interfaces;

namespace Kohde.Assessment
{
    public class Human : Being, IHuman
    {
        public Human(Human human) { 
        }
        public Human() {
        }

        public string Gender { get; set; }

        public override string ToString() {
            return "ToString";
        }
    }
}