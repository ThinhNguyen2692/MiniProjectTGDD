namespace ModelProject
{
    public class Status
    {
        public List<string> GetStatus()
        {
            List<string> status = new List<string>
            {

                new string("Tạm ngưng doanh"),
                new string("Kinh doanh")
            };
            return status;
        }
    }
}
