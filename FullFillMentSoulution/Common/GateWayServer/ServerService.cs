using Microsoft.Extensions.Configuration;

namespace Common.GateWay
{
    public class Server
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Subject { get; set; }
    }
    public interface IQueConfigurationService
    {
        List<Server> GetServers();
    }
    public enum ServerSubject { 물류, 판매, 마켓, 주문 }

    public interface ICommandServerConfiguringService
    {
        List<Server> GetCommandServers(ServerSubject serverSubject);
    }
    public interface IQueryServerConfiguringServcie
    {
        List<Server> GetQueryServers(ServerSubject serverSubject);
    }
    public class QueConfigurationService
    {
        private readonly IConfiguration _configuration;

        public QueConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Server> GetCommandServers(ServerSubject serverSubject)
        {
            List<Server> servers = _configuration.GetSection("CommandServers")
                                                    .Get<List<Server>>()
                                        ?? throw new Exception("서버 목록을 가져올 수 없습니다.");

            List<Server> filteredServers = servers.FindAll(server => server.Subject == serverSubject.ToString());
            return filteredServers;
        }
        public List<Server> GetQueryServers(ServerSubject serverSubject) 
        {
            List<Server> servers = _configuration.GetSection("QueryServers")
                                                    .Get<List<Server>>()
                                        ?? throw new Exception("서버 목록을 가져올 수 없습니다.");

            List<Server> filteredServers = servers.FindAll(server => server.Subject == serverSubject.ToString());
            return filteredServers;
        }
    }
}
