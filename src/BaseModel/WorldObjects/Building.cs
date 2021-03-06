using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModel.WorldObjects
{
    public class Building : WorldObject
    {
        public Building(Type type) : base(type)
        {
            validate();
        }

        protected override Type[] AllowedTypes => new Type[] {
            Type.GARAGE
        };

        public override Tag Tags => Tag.BUILDING;
    }
}
