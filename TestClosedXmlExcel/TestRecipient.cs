namespace TestClosedXmlExcel
{
    public class TestRecipient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public TestRecipient(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}