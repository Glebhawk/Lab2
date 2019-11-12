// This is our main storage for rooms, pastures and statement day/night
namespace Suitcase
{
    static class Case
    {
        public static Room room = new Room();          // This is actually list. I could have used normal lists and foreach, but
        public static Pasture pasture = new Pasture(); // I had to implement chain of responsibility
        public static DayTime dayTime = new Day();
    }
}
// You can rework it into real lists, for this you have to move logic from Habitat and it`s subclasses
// to biologist, where you will make it all anew with cycles and without chain of responsibility.
// OR you can save chain logic and use lists for everything else! I should try it myself.