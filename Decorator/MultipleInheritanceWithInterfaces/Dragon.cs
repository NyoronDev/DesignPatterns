namespace Decorator.MultipleInheritanceWithInterfaces
{
    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        // With Weight we have a problem since both elements has the same property
        // This is one of the cases that is not good enought
        // We need to create our own Weight property
        private int weight;

        public int Weight { get { return weight; } set { weight = value; bird.Weight = value; lizard.Weight = value; } }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }
}