using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModel.WorldObjects
{
    public class Tree : WorldObject
    {
        public Tree() : base(Type.TREE)
        {
            validate();
        }

        protected override Type[] AllowedTypes => new[] { Type.TREE };

        public override Tag Tags => Tag.NATURE;
    }
}
