using System.Collections.Generic;

namespace AdditionalContent.LocalInversionOfControl
{
    public class Person
    {
        public List<string> Names = new List<string>();
        public List<Person> Children = new List<Person>();
    }
}