namespace RecordTest.Models
{
    public class MiniClass : IMini
    {
        private static readonly List<String> factions = new()
        {
            "Orcs", "Vampires"
        };
        private string? _faction;

        public int Id { get; set; }

        public string? Faction
        {
            get { return _faction; }
            set
            {
                if (value != null && factions.Contains(value))
                { 
                    this._faction = value;
                } else
                {
                    throw new ArgumentException("Invalid Faction!");
                }
            }
        }

        public string? Name { get; set; }

        public MiniClass()
        {
        }

        public MiniClass(MiniRecord record)
        {
            this.Id = record.Id;
            this.Faction = record.Faction;
            this.Name = record.Name;
        }
    }
}
