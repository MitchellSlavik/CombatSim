using System;
using System.Collections.Generic;

using SimRunner.Enums;
using SimRunner.Interfaces;
using WebAssembly;

namespace SimRunner.Entities {
  class Class : IJSSerializable {
    int hitDice;
    List<SaveTypes> savingThrows = new List<SaveTypes>();
    CasterTypes castingType;
    AbilityTypes spellCastingAbility;

    public Class(JSObject obj) {
      this.FromJSObject(obj);
    }

    public void FromJSObject(JSObject obj) {
      
    }
  }
}
