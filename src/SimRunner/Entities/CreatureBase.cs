using WebAssembly;
using System;
using System.Collections.Generic;

using SimRunner.Interfaces;
using SimRunner.Utilities;
using SimRunner.Enums;

namespace SimRunner.Entities {
  class CreatureBase : IJSSerializable {
    static int CreatureIdCounter = 0;
    public int id { get; private set; }
    public string name { get; private set; }
    public string team { get; private set; }
    public int maxHitPoints { get; private set; }

    public int baseStrengthScore { get; private set; }
    public int baseDexterityScore { get; private set; }
    public int baseConstitutionScore { get; private set; }
    public int baseIntelligenceScore { get; private set; }
    public int baseWisdomScore { get; private set; }
    public int baseCharismaScore { get; private set; }

    public int baseArmorClass { get; private set; }

    public List<DamageTypes> resistences { get; private set; } = new List<DamageTypes>();
    public List<DamageTypes> immunities { get; private set; } = new List<DamageTypes>();
    public List<DamageTypes> weaknesses { get; private set; } = new List<DamageTypes>();

    public CreatureBase(JSObject obj){
      this.FromJSObject(obj);
    }

    public void FromJSObject(JSObject obj) {
      id = ++CreatureIdCounter;
      name = JSObjectHelper.GetString(obj, "name", "<Default Name>");
      team = JSObjectHelper.GetString(obj, "team", "good");
      maxHitPoints = JSObjectHelper.GetInt(obj, "maxHitPoints", 1);
      baseStrengthScore = JSObjectHelper.GetInt(obj, "baseStrengthScore", 1);
      baseDexterityScore = JSObjectHelper.GetInt(obj, "baseDexterityScore", 1);
      baseConstitutionScore = JSObjectHelper.GetInt(obj, "baseConstitutionScore", 1);
      baseIntelligenceScore = JSObjectHelper.GetInt(obj, "baseIntelligenceScore", 1);
      baseWisdomScore = JSObjectHelper.GetInt(obj, "baseWisdomScore", 1);
      baseCharismaScore = JSObjectHelper.GetInt(obj, "baseCharismaScore", 1);
      baseArmorClass = JSObjectHelper.GetInt(obj, "baseArmorClass", 1);

      string[] resistences = JSObjectHelper.GetString(obj, "resistences", "").Split(',');

      if(resistences.Length >= 1 && !resistences[0].Equals("")) {
        for(int i = 0; i < resistences.Length; i++) {
          DamageTypes damageType;
          if(Enum.TryParse<DamageTypes>(resistences[i], out damageType)){
            this.resistences.Add(damageType);
          }
        }
      }

      string[] immunities = JSObjectHelper.GetString(obj, "immunities", "").Split(',');

      if (immunities.Length >= 1 && !immunities[0].Equals("")) {
        for (int i = 0; i < immunities.Length; i++) {
          DamageTypes damageType;
          if (Enum.TryParse<DamageTypes>(immunities[i], out damageType)) {
            this.immunities.Add(damageType);
          }
        }
      }

      string[] weaknesses = JSObjectHelper.GetString(obj, "weaknesses", "").Split(',');

      if (weaknesses.Length >= 1 && !weaknesses[0].Equals("")) {
        for (int i = 0; i < weaknesses.Length; i++) {
          DamageTypes damageType;
          if (Enum.TryParse<DamageTypes>(weaknesses[i], out damageType)) {
            this.weaknesses.Add(damageType);
          }
        }
      }
    }
  }
}