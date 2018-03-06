
namespace TM.Domain.Core.Models
{
    using FluentValidation;
    using FluentValidation.Results;
    using System;

    public abstract class Entity<TEntity> : AbstractValidator<TEntity> where TEntity : Entity<TEntity>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TEntity>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<TEntity> a, Entity<TEntity> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TEntity> a, Entity<TEntity> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 1647) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + $"[Id = {Id} ]";
        }
    }
}
