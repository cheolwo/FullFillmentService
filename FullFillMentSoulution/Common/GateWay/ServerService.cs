using Microsoft.Extensions.Configuration;

namespace Common.GateWay
{
    public class Server
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Subject { get; set; }
    }
    public interface IQueConfigurationService
    {
        List<Server> GetServers();
    }
    public enum ServerSubject { 물류, 판매, 마켓, 주문 }

    public class QueConfigurationService
    {
        private readonly IConfiguration _configuration;

        public QueConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Server> GetServers(ServerSubject serverSubject)
        {
            List<Server> servers = _configuration.GetSection("Servers")
                                                    .Get<List<Server>>()
                                        ?? throw new Exception("서버 목록을 가져올 수 없습니다.");

            List<Server> filteredServers = servers.FindAll(server => server.Subject == serverSubject.ToString());
            return filteredServers;
        }
    }
}
