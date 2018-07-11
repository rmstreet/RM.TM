
namespace TM.Domain.Entities
{
    using System;
    using Core.Models;

    public class Match : Entity<Match>
    {
        public Team TeamA { get; private set; }
        public Team TeamB { get; private set; }
        public Team TeamWinner { get; private set; }

        private Match() { }

        public Match(Team teamA, Team teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
        }

        public Match TeamAWinner()
        {
            TeamWinner = TeamA;
            return this;
        }

        public Match TeamBWinner()
        {
            TeamWinner = TeamB;
            return this;
        }

        public override bool IsValid()
        {
            MinimumValidate();

            return ValidationResult.IsValid;
        }

        #region Validate
        private void MinimumValidate()
        {
            ValidationResult = Validate(this);

            ValidateTeamA();
            ValidateTeamB();
        }

        private void ValidateTeamA()
        {
            if (TeamA.IsValid()) return;
            foreach (var error in TeamA.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        private void ValidateTeamB()
        {
            if (TeamB.IsValid()) return;
            foreach (var error in TeamB.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }
        #endregion

        #region Factory
        public class MatchFactory
        {
            public static Match NewCompleteMatch(Guid id, Team teamA, Team teamB) => new Match() { Id = id, TeamA = teamA, TeamB = teamB };
        }


        #endregion
    }
}
