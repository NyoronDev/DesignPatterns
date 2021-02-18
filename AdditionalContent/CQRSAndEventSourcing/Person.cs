namespace AdditionalContent.CQRSAndEventSourcing
{
    public class Person
    {
        private int age;
        private EventBroker eventBroker;

        public Person(EventBroker eventBroker)
        {
            this.eventBroker = eventBroker;
            eventBroker.Commands += BrokerOnCommands;
            eventBroker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            var ac = query as AgeQuery;
            if (ac != null && ac.Target == this)
            {
                ac.Result = age;
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;
            if (cac != null && cac.Target == this)
            {
                // Recording the change of the value
                if (cac.Register)
                {
                    eventBroker.AllEvents.Add(new AgeChangedEvent(this, age, cac.Age));
                }

                age = cac.Age;
            }
        }
    }
}