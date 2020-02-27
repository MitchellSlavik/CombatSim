using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimRunner.Interfaces;
using SimRunner.Utilities;
using WebAssembly;

namespace SimRunner.Entities {
  class Race: IJSSerializable {
    string name { get; set; }
    int strengthAbilityBonus { get; set; }
    int constitutionAbilityBonus { get; set; }
    int dexterityAbilityBonus { get; set; }
    int wisdomAbilityBonus { get; set; }
    int intelligenceAbilityBonus { get; set; }
    int charismaAbilityBonus { get; set; }

    public Race(JSObject obj) {
      this.FromJSObject(obj);
    }

    public void FromJSObject(JSObject obj) {
      name = JSObjectHelper.GetString(obj, "name", "<Default Name>");
      strengthAbilityBonus = JSObjectHelper.GetInt(obj, "strengthAbilityBonus", 0);
      constitutionAbilityBonus = JSObjectHelper.GetInt(obj, "constitutionAbilityBonus", 0);
      dexterityAbilityBonus = JSObjectHelper.GetInt(obj, "dexterityAbilityBonus", 0);
      wisdomAbilityBonus = JSObjectHelper.GetInt(obj, "wisdomAbilityBonus", 0);
      intelligenceAbilityBonus = JSObjectHelper.GetInt(obj, "intelligenceAbilityBonus", 0);
      charismaAbilityBonus = JSObjectHelper.GetInt(obj, "charismaAbilityBonus", 0);
    }
  }
}
