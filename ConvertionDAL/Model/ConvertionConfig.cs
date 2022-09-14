namespace ConvertionDAL.Model
{
    public class ConvertionInput
    {
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public decimal FromValue { get; set; }
    }


    public class ConvertionConfig
    {
        public string ConvertionType { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public decimal ToValue { get; set; }
    }
}
