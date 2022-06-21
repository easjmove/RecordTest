namespace RecordTest.Models
{
    public record MiniRecord : IMini
    //(int id, string faction, string name)
    {
        public int Id { get; init; }
        public string? Faction { get; init; }
        public string? Name { get; init; }

        public MiniRecord()
        {
        }

        public MiniRecord(MiniClass fromObject)
        {
            Id = fromObject.Id;
            Faction = fromObject.Faction;
            Name = fromObject.Name;
        }
    }
}
