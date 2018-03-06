
namespace TM.DomainTests.Models
{
    using Xunit;
    using System;
    using System.Collections.Generic;
    using Domain.Entities;

    public class EntityTests
    {
        #region ToString Method

        [Fact]
        [Trait("Entity", "ToString Method")]
        public void ToStringEntityShouldReturnNameTypeWithId()
        {
            var id = Guid.NewGuid();
            var entityA = Team.TeamFactory.NewCompleteTeam(id, "FLA", "Flamengo");
            var stringExpected = $"Team[Id = {id} ]";

            Assert.False(string.IsNullOrEmpty(entityA.ToString()));
            Assert.Equal(stringExpected, entityA.ToString());
        }

        #endregion

        #region GetHashCode Method

        [Fact]
        [Trait("Entity", "GetHashCode Method")]
        public void AddTwoEqualsEntitiesInAllPropertiesInAHashSetCollectionShouldContainOneTeamInTheCollection()
        {
            var listTeams = new HashSet<Team>();
            var id = Guid.NewGuid();
            var teamA = Team.TeamFactory.NewCompleteTeam(id, "FLA", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(id, "FLA", "Flamengo");

            listTeams.Add(teamA);
            listTeams.Add(teamB);

            Assert.Single(listTeams);
        }

        [Fact]
        [Trait("Entity", "GetHashCode Method")]
        public void AddTwoEntitiesWithDifferentPropertiesInAHashSetCollectionShouldContainTwoTeamsInTheCollection()
        {
            var listTeams = new HashSet<Team>();
            var id = Guid.NewGuid();
            var teamA = Team.TeamFactory.NewCompleteTeam(id, "FLA", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(id, "FLA", "Flmengo");

            listTeams.Add(teamA);
            listTeams.Add(teamB);

            Assert.Equal(2, listTeams.Count);
        }

        #endregion

        #region Equals Method
        [Fact]
        [Trait("Entity", "Equals Method")]
        public void ComparingTwoEqualsEntitiesUsingEqualsMethodShouldReturnTrue()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var entityB = Team.TeamFactory.NewCompleteTeam(entityA.Id, "FLA", "Flamengo");

            Assert.True(entityA.Equals(entityB));
        }

        [Fact]
        [Trait("Entity", "Equals Method")]
        public void ComparingTwoDifferentEntitiesUsingEqualsMethodShouldReturnFalse()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");
            var entityB = Team.TeamFactory.NewCompleteTeam(entityA.Id, "FLA", "Flamengo");

            Assert.False(entityA.Equals(entityB));
        }

        [Fact]
        [Trait("Entity", "Equals Method")]
        public void ComparingNullEntityUsingEqualsMethodShouldReturnFalse()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");
            Team entityB = null;

            Assert.False(entityA.Equals(entityB));
        }
        #endregion

        #region Equals Operator
        [Fact]
        [Trait("Entity", "Equals Operator")]
        public void ComparingTwoEqualsEntitiesUsingEqualsOperatorShouldReturnTrue()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var entityB = Team.TeamFactory.NewCompleteTeam(entityA.Id, "FLA", "Flamengo");

            Assert.True(entityA == entityB);
        }

        [Fact]
        [Trait("Entity", "Equals Operator")]
        public void ComparingTwoDifferentEntitiesUsingEqualsOperatorShouldReturnFalse()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");
            var entityB = Team.TeamFactory.NewCompleteTeam(entityA.Id, "FLA", "Flamengo");

            Assert.False(entityA == entityB);
        }

        [Fact]
        [Trait("Entity", "Equals Operator")]
        public void ComparingLeftNullEntityUsingEqualsOperatorShouldReturnFalse()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");
            Team entityB = null;

            Assert.False(entityA == entityB);
        }

        [Fact]
        [Trait("Entity", "Equals Operator")]
        public void ComparingRightNullEntityUsingEqualsOperatorShouldReturnFalse()
        {
            Team entityA = null;
            var entityB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");

            Assert.False(entityA == entityB);
        }

        [Fact]
        [Trait("Entity", "Equals Operator")]
        public void ComparingTwoNullEntitiesUsingEqualsOperatorShouldReturnTrue()
        {
            Team entityA = null;
            Team entityB = null;

            Assert.True(entityA == entityB);
        }
        #endregion

        #region Different Operator
        [Fact]
        [Trait("Entity", "Different Operator")]
        public void ComparingTwoEqualsEntitiesUsingDifferentOperatorShouldReturnFalse()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var entityB = Team.TeamFactory.NewCompleteTeam(entityA.Id, "FLA", "Flamengo");

            Assert.False(entityA != entityB);
        }

        [Fact]
        [Trait("Entity", "Different Operator")]
        public void ComparingTwoDifferentEntitiesUsingDifferentOperatorShouldReturnTrue()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");
            var entityB = Team.TeamFactory.NewCompleteTeam(entityA.Id, "FLA", "Flamengo");

            Assert.True(entityA != entityB);
        }

        [Fact]
        [Trait("Entity", "Different Operator")]
        public void ComparingLeftNullEntityUsingDifferentOperatorShouldReturnFalsTrue()
        {
            var entityA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");
            Team entityB = null;

            Assert.True(entityA != entityB);
        }

        [Fact]
        [Trait("Entity", "Different Operator")]
        public void ComparingRightNullEntityUsingDifferentOperatorShouldReturnTrue()
        {
            Team entityA = null;
            var entityB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FAA", "Flamengo");

            Assert.True(entityA != entityB);
        }

        [Fact]
        [Trait("Entity", "Different Operator")]
        public void ComparingTwoNullEntitiesUsingDifferentOperatorShouldReturnFalse()
        {
            Team entityA = null;
            Team entityB = null;

            Assert.False(entityA != entityB);
        }
        #endregion
    }
}
