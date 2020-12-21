namespace MQLDatabase.Common.Attribute
{
    public class NameAttr : System.Attribute
    {
        private readonly string _name;
        public NameAttr(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } }
    }
}
