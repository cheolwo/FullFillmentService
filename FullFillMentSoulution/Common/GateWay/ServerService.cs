using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GateWay
{
    public class Server
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Subject { get; set; }
    }

    public class QueConfigurationService
    {
        private readonly IConfiguration _configuration;

        public QueConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Server> GetLogisticsServers()
        {
            List<Server> servers = _configuration.GetSection("Servers")
                                                    .Get<List<Server>>()
                                        ?? throw new Exception("서버 목록을 가져올 수 없습니다.");

            List<Server> filteredServers = servers.FindAll(server => server.Subject == "물류");
            return filteredServers;
        }
    }
}
