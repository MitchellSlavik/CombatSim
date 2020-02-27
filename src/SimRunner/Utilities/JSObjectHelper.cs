using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAssembly;

namespace SimRunner.Utilities {
  class JSObjectHelper {
    public static int GetInt(JSObject obj, string property, int def) {
      if(obj.HasOwnProperty(property)){
        try {
          int ret = (int) obj.GetObjectProperty(property);
          return ret;
        }catch(JSException err) {
          Console.Error.WriteLine($"Error getting int propery '{property}'. {err.GetBaseException().Message}");
          return def;
        }
      } else {
        return def;
      }
    }
    public static string GetString(JSObject obj, string property, string def) {
      if (obj.HasOwnProperty(property)) {
        try {
          string ret = (string)obj.GetObjectProperty(property);
          return ret;
        } catch (JSException err) {
          Console.Error.WriteLine($"Error getting string propery '{property}'. {err.GetBaseException().Message}");
          return def;
        }
      } else {
        return def;
      }
    }
    public static bool GetBool(JSObject obj, string property, bool def) {
      if (obj.HasOwnProperty(property)) {
        try {
          bool ret = (bool)obj.GetObjectProperty(property);
          return ret;
        } catch (JSException err) {
          Console.Error.WriteLine($"Error getting string propery '{property}'. {err.GetBaseException().Message}");
          return def;
        }
      } else {
        return def;
      }
    }
  }
}
