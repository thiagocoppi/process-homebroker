using System;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public void AlterarIdentificador(Guid id)
        {
            Id = id;
        }
    }
}