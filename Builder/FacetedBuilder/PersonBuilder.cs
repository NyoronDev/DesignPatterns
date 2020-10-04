namespace Builder.FacetedBuilder
{
    // Facade to expose other builders
    public class PersonBuilder
    {
        // Reference
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        // Used to use Person instead of PersonBuilder
        public static implicit operator Person(PersonBuilder personBuilder)
        {
            return personBuilder.person;
        }
    }
}