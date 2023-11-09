namespace Interactive_moive
{
    public class VariantType
    {
        public string TypeName { get; set; }
        public readonly string Type;

        public VariantType(string type, string typeName)
        {
            Type = type;
            TypeName = typeName;
        }
    }
}
