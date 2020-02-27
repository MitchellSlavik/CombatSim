using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAssembly;
using SimRunner.Utilities;

namespace SimRunner.Entities {
  class Character : CreatureBase {
    public Race race { get; private set; }
    public List<ClassLevel> classes { get; private set; } = new List<ClassLevel>();
    public List<Spell> spells { get; private set; } = new List<Spell>();

    public Character(JSObject obj, Dictionary<string, Race> races, Dictionary<string, Class> classes, Dictionary<string, Spell> spells) : base(obj) {
      this.FromJSObject(obj, races, classes, spells);
    }

    private void FromJSObject(JSObject obj, Dictionary<string, Race> races, Dictionary<string, Class> classes, Dictionary<string, Spell> spells) {
      string race = JSObjectHelper.GetString(obj, "race", "Human");

      Race r;
      if (races.TryGetValue(race, out r)) {
        this.race = r;
      }

      string c = JSObjectHelper.GetString(obj, "classes", "");

      string[] split = c.Split(',');

      for (int i = 0; i < split.Length; i++) {
        string[] classSplit = split[i].Split('|');
        if (classSplit.Length == 2) {
          Class cl;
          if (classes.TryGetValue(classSplit[0], out cl)) {
            try {
              this.classes.Add(new ClassLevel(Int32.Parse(classSplit[1]), cl));
            } catch (FormatException e) {
              Console.Error.WriteLine($"Error parsing class integer for '{name}' class '{classSplit[0]}'. {e.Message}");
            }
          }
        }
      }

      string s = JSObjectHelper.GetString(obj, "spells", "");

      split = s.Split(',');

      for (int i = 0; i < split.Length; i++) {
        Spell spell;

        if(spells.TryGetValue(split[i], out spell)) {
          this.spells.Add(spell);
        }
      }
    }
  }
}
