
namespace TM.DomainTests.Models
{
    using TM.Domain.Entities;
    using TM.DomainTests.Utilities;
    using TM.DomainTests.Utilities.ModelsGenarator;
    using Xunit;
    public class RoundTests
    {
        [Trait("Round", "Creation Tests")]
        [Theory]                
        [MemberData(nameof(TestDataGenerator.GetTeamsValid), MemberType = typeof(TestDataGenerator))]
        public void RoundCreatedByFactoryWithAllValuesMustBeValid(TeamsTestGenerator data)
        {
            var teams = data.Teams;

            var round = Round.RoundFactory.NewRound(teams);
                        
            Assert.NotNull(round.Matchs);
            Assert.True(round.ValidationResult.IsValid);
            Assert.True(round.IsValid());
            Assert.False(round.EndRound());
            
        }
    }
}
