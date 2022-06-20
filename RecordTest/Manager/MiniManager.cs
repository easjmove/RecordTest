using RecordTest.Models;

namespace RecordTest.Manager
{
    public class MiniManager
    {
        private static int _nextID = 1;
        private static readonly List<MiniClass> minis = new()
        {
            new MiniClass(){Id=_nextID++,Faction="Orcs",Name= "Boys"},
            new MiniClass(){Id=_nextID++,Faction="Orcs", Name="Wazboom" },
            new MiniClass(){Id=_nextID++,Faction= "Orcs", Name="Ghazra" }
        };

        public List<MiniClass> GetAll()
        {
            return new List<MiniClass>(minis);
        }

        public MiniClass? GetByID(int id)
        {
            return minis.Find(x => x.Id == id);
        }

        public MiniClass Add(MiniClass newMini)
        {
            newMini.Id = _nextID++;
            minis.Add(newMini);
            return newMini;
        }
    }
}
