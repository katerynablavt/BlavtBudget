using System;
using System.Collections.Generic;
using System.Text;

namespace BlavtBudget
{
    public enum EntityState
    {
        Active,
        Deleted
    }
    public abstract class EntityBase
    {
        public bool IsNew { get; protected set; }
        public bool HasChanges { get; protected set; }
        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }
        public EntityState State { get; set; }

        public abstract bool Validate();
    }
}
