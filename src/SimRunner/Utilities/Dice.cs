using System;

namespace SimRunner.Utilities {
  class Dice {
    static Random rand = new Random();
    public static int roll(int numDice, int sides) {
      return roll(numDice, sides, 0);
    }
    public static int roll(int numDice, int sides, int modifer) {
      return roll(numDice, sides, modifer, false);
    }
    public static int roll(int numDice, int sides, int modifier, bool crit) {
      int total = 0;
      for (int i = 0; i < numDice; i++) {
        total += rand.Next(1, sides + 1);
      }
      if(crit) {
        total *= 2;
      }
      return total + modifier;
    }
  }
}
