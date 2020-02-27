using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimRunner.Entities {
  class ClassLevel {
    public int level { get; private set; }
    public Class classObj { get; private set; }

    public ClassLevel(int level, Class classObj){
      this.level = level;
      this.classObj = classObj;
    }
  }
}
