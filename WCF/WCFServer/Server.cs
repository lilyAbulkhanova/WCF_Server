using Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
   
    public class Server
    {
        /// <summary>
        //!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        private ServiceHost host;
        private ServiceHost host2;
        public Server()
        {
            host = new ServiceHost(typeof(Contract));
            host2 = new ServiceHost(typeof(Login));
        }
        public void Start()
        {
            host.Open();
            host2.Open();
        }
    }
}
