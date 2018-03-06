
namespace TM.DomainTests.Models
{
    using System;
    using TM.Domain.Entities;
    using Xunit;

    public class TeamTests
    {

        #region Creation Tests
        [Fact]
        [Trait("Team", "Creation Tests")]
        public void TeamCreatedByConstructorWithValuesMinimumMustBeValid()
        {
            Team team;

            team = new Team("Flamengo");

            Assert.NotEqual(Guid.Empty, team.Id);
            Assert.Equal("Flamengo", team.Name);
            Assert.True(team.IsValid());
        }

        [Fact]
        [Trait("Team", "Creation Tests")]
        public void TeamCreatedByConstructorWithAllValuesMinimumMustBeValid()
        {
            Team team;

            team = new Team("Flamengo");
            team.SetAcronyms("FLA");

            Assert.NotEqual(Guid.Empty, team.Id);
            Assert.Equal("Flamengo", team.Name);
            Assert.Equal("FLA", team.Acronyms);
            Assert.True(team.IsValid());
        }

        [Fact]
        [Trait("Team", "Creation Tests")]
        public void TeamCreatedByFactoryWithAllValuesMustBeValid()
        {
            Team team;

            team = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");

            Assert.NotEqual(Guid.Empty, team.Id);
            Assert.Equal("Flamengo", team.Name);
            Assert.Equal("FLA", team.Acronyms);
            Assert.True(team.IsValid());
        }
        #endregion

        #region Validation Tests
        [Fact]
        [Trait("Team", "Validation Tests")]
        public void WhenNumberOdCharactersNameIsLessThenFiveTeamMustBeInvalid()
        {
            Team team;

            team = new Team("Vaco");

            Assert.Equal("Vaco", team.Name);
            Assert.False(team.IsValid());
            Assert.Equal(1, team.ValidationResult.Errors.Count);
            Assert.Equal("O Nome deve ter no mínimo 5 caracteres.", team.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact]
        [Trait("Team", "Validation Tests")]
        public void WhenNumberOdCharactersNameIsGreaterThenTwentyFiveTeamMustBeInvalid()
        {
            Team team;

            team = new Team("Independent del Soledad Jail");

            Assert.Equal("Independent del Soledad Jail", team.Name);
            Assert.False(team.IsValid());
            Assert.Equal(1, team.ValidationResult.Errors.Count);
            Assert.Equal("O Nome deve ter no máximo 25 caracteres.", team.ValidationResult.Errors[0].ErrorMessage);
        }
        #endregion

    }
}
