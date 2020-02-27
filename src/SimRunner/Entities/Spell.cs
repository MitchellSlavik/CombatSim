using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimRunner.Interfaces;
using SimRunner.Enums;
using SimRunner.Utilities;
using WebAssembly;

namespace SimRunner.Entities {
  class Spell : IJSSerializable {
    public string name { get; private set; }
    public int level { get; private set; } // 0 = cantrip, 1 = 1st level ...
    public int duration { get; private set; } // in rounds
    public bool combatSpell { get; private set; } // is this regularly used in combat (damage or effect)
    public bool good { get; private set; } // Should it be used on allies?
    public bool castHigherLevel { get; private set; } // Can it be cast at higher levels?

    public int maxTargets { get; private set; }
    public int minTargets { get; private set; }
    public string damage { get; private set; } // eg 4d8+SCM Fire | 6d6[Fire,Cold,Lightning]
    public string extraDamagePerLevel { get; private set; }

    public void FromJSObject(JSObject obj) {
      name = JSObjectHelper.GetString(obj, "name", "<Default Name>");
      level = JSObjectHelper.GetInt(obj, "level", 0);
      duration = JSObjectHelper.GetInt(obj, "duration", 1);
      combatSpell = JSObjectHelper.GetBool(obj, "combatSpell", false);
      good = JSObjectHelper.GetBool(obj, "good", false);
      castHigherLevel = JSObjectHelper.GetBool(obj, "castHigherLevel", false);
      maxTargets = JSObjectHelper.GetInt(obj, "maxTargets", 1);
      minTargets = JSObjectHelper.GetInt(obj, "minTargets", 1);
      damage = JSObjectHelper.GetString(obj, "damage", "0");
      extraDamagePerLevel = JSObjectHelper.GetString(obj, "extraDamagePerLevel", "0");
    }
  }
}
