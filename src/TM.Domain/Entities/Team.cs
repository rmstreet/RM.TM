
namespace TM.Domain.Entities
{
    using FluentValidation;
    using System;
    using Core.Models;

    public class Team : Entity<Team>
    {
        public string Acronyms { get; private set; }
        public string Name { get; private set; }

        private Team() { }

        public Team(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Team SetAcronyms(string acronyms)
        {
            Acronyms = acronyms;
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
            ValidateName();
            ValidateAcronyms();

            ValidationResult = Validate(this);
        }

        private void ValidateName()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("O nome do time deve ser obrigatório.")
                .MaximumLength(25).WithMessage("O Nome deve ter no máximo 25 caracteres.")
                .MinimumLength(5).WithMessage("O Nome deve ter no mínimo 5 caracteres.");

        }
        private void ValidateAcronyms()
        {
            if (!string.IsNullOrEmpty(Acronyms))
                RuleFor(t => t.Acronyms)
                    .MaximumLength(4).WithMessage("A Sigla deve ter no máximo 4 caracteres.")
                    .MinimumLength(2).WithMessage("A Sigla deve ter no mínimo 2 caracteres.");
        }
        #endregion

        #region EntityMethodOverride
        public override bool Equals(object obj)
        {
            return base.Equals(obj) &&
                   Name.Equals(((Team)obj).Name) &&
                   Acronyms.Equals(((Team)obj).Acronyms);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Factory
        public class TeamFactory
        {
            public static Team NewCompleteTeam(Guid id, string acronyms, string name) => new Team() { Id = id, Name = name, Acronyms = acronyms };
        }
        #endregion

    }
}
