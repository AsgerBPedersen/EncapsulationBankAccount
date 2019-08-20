using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public abstract class Entity
    {
        protected int id;
        public Entity()
        {
            id = 0;
        }

        public Entity(int id)
        {
            Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
