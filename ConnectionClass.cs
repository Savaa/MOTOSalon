namespace MOTOSalon
{
    internal class ConnectionClass
    {
        public string ConnectString;
        public void Connection_Options(string DS_NAME,
            string INIT_CATALOG)
        {
            ConnectString = "Data Source="
                + DS_NAME + ";" + "Initial Catalog="
                + INIT_CATALOG + ";" + 
                "Integrated Security=True;User ID=\"\";Password=\"\"";
        }
    }
}