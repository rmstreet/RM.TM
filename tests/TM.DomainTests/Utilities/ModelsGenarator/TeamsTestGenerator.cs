
namespace TM.DomainTests.Utilities.ModelsGenarator
{
    using System.Collections.Generic;
    using TM.Domain.Entities;

    public class TeamsTestGenerator
    {
        public TeamsTestGenerator(int quantity)
        {
            Quantity = quantity;
            Teams = BogusGenerator.Teams(quantity);
        }

        public int Quantity { get; private set; }
        public List<Team> Teams { get; private set; }
    }
}
