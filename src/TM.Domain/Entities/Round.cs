
namespace TM.Domain.Entities
{
    using FluentValidation;
    using System.Collections.Generic;
    using System.Linq;
    using TM.Domain.Core.Models;
    using TM.Domain.Extensions;

    public class Round : Entity<Round>
    {

        public List<Match> Matchs { get; private set; }

        private Round AddTeams(List<Team> teams)
        {
            Matchs = new List<Match>();
            Matchs = teams.
                        SelectWithCurrentAndPreviouItem((teamB, teamA) => new Match(teamA, teamB)).
                        ToList();
            return this;
        }

        private Round() { }


        public bool EndRound()
        {
            return Matchs.All(m => m.TeamWinner != null);
        }

        public Round NextRound()
        {
            if (this.EndRound())
                return AddTeams(Matchs.Select(m => m.TeamWinner).ToList());
            return null;
        }

        public override bool IsValid()
        {
            ValidadeMatchs();

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        #region Validate
        private void ValidadeMatchs()
        {
            RuleFor(r => r.Matchs)
                .NotNull().WithMessage("A lista de partidas não deve está vazia.");
        }
        #endregion

        #region Factory
        public class RoundFactory
        {
            public static Round NewRound(List<Team> teams)
            {
                return new Round().
                    AddTeams(teams);
            }
        }
        #endregion
    }
}
