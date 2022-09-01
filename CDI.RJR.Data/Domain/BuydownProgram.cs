namespace CDI.RJR.Data.Domain
{
    public class BuydownProgram
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgramOption { get; set; }
        public bool IsMenthol { get; set; }
        public bool IsNational { get; set; }
    }
}