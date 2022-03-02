namespace B_lotus.Models
{
    public class Connection
    {
        private DBContext _dal;
        public Connection(DBContext dal)
        {
            _dal = dal;
        }
        public string ConfigurnewConnectionString(int CompanyId)
            {
            var Company = _dal.Companys.Where(x => x.CompanyId == CompanyId).Select(cmp => new Company()
            {
                CompanyId = cmp.CompanyId,
                CompanyName = cmp.CompanyName,
                Servers = cmp.Servers

            }).FirstOrDefault();


            var ConnectionString = "server={1};database={2};uid={3};password={4};Convert Zero Datetime=True;";
             var Connections = ConnectionString.ToString().Replace("{0}", Company.Servers.ServerName);
                Connections = ConnectionString.ToString().Replace("{1}", Company.Servers.DatabaseName);
                Connections = ConnectionString.ToString().Replace("{2}", Company.Servers.UserName);
                Connections = ConnectionString.ToString().Replace("{3}", Company.Servers.Password);
            return Connections;
        }
        
    }
}
