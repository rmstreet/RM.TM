
namespace TM.DomainTests.Models
{
    using System;
    using TM.Domain.Entities;
    using Xunit;

    public class MatchTests
    {
        [Fact]
        [Trait("Match", "Who Won Method")]
        public void WhenChooseTheTeamAAsTheWinnerThenTheMatchMustHaveTheWinnerEqualTeamA()
        {
            var teamA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "VAS", "Vasco");
            Match match = Match.MatchFactory.NewCompleteMatch(Guid.NewGuid(), teamA, teamB);

            match.TeamAWinner();

            Assert.Equal(teamA, match.TeamWinner);
        }

        [Fact]
        [Trait("Match", "Who Won Method")]
        public void WhenChooseTheTeamBAsTheWinnerThenTheMatchMustHaveTheWinnerEqualTeamB()
        {
            var teamA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "VAS", "Vasco");
            Match match = Match.MatchFactory.NewCompleteMatch(Guid.NewGuid(), teamA, teamB);

            match.TeamBWinner();

            Assert.Equal(teamB, match.TeamWinner);
        }

        #region Creation Tests
        [Fact]
        [Trait("Match", "Creation Tests")]
        public void MatchCreatedByFactoryWithAllValuesMustBeValid()
        {
            var teamA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "VAS", "Vasco");
            Match match = Match.MatchFactory.NewCompleteMatch(Guid.NewGuid(), teamA, teamB);

            Assert.NotNull(match.TeamA);
            Assert.NotNull(match.TeamB);
            Assert.Equal(teamA, match.TeamA);
            Assert.Equal(teamB, match.TeamB);
            Assert.True(match.IsValid());
        }

        [Fact]
        [Trait("Match", "Creation Tests")]
        public void WhenMatchCreatedWithInvalidTeamATheMatchMustBeInvalid()
        {
            var teamA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "F", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "VAS", "Vasco");
            Match match = Match.MatchFactory.NewCompleteMatch(Guid.NewGuid(), teamA, teamB);

            Assert.NotNull(match.TeamA);
            Assert.NotNull(match.TeamB);
            Assert.Equal(teamA, match.TeamA);
            Assert.Equal(teamB, match.TeamB);
            Assert.False(match.IsValid());
        }

        [Fact]
        [Trait("Match", "Creation Tests")]
        public void WhenMatchCreatedWithInvalidTeamBTheMatchMustBeInvalid()
        {
            var teamA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "V", "Vasco");
            Match match = Match.MatchFactory.NewCompleteMatch(Guid.NewGuid(), teamA, teamB);

            Assert.NotNull(match.TeamA);
            Assert.NotNull(match.TeamB);
            Assert.Equal(teamA, match.TeamA);
            Assert.Equal(teamB, match.TeamB);
            Assert.False(match.IsValid());
        }

        [Fact]
        [Trait("Match", "Creation Tests")]
        public void MatchCreatedByConstructorWithAllValuesMinimumMustBeValid()
        {
            var teamA = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "FLA", "Flamengo");
            var teamB = Team.TeamFactory.NewCompleteTeam(Guid.NewGuid(), "VAS", "Vasco");
            Match match = new Match(teamA, teamB);

            Assert.NotNull(match.TeamA);
            Assert.NotNull(match.TeamB);
            Assert.Equal(teamA, match.TeamA);
            Assert.Equal(teamB, match.TeamB);
            Assert.True(match.IsValid());
        }
        #endregion
    }
}
