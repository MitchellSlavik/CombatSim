using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAssembly;

namespace SimRunner.Entities {
  class Creature : CreatureBase {
    public int proficiencyBonus { get; private set; }

    public Creature(JSObject obj) : base(obj) {

    }
  }
}
