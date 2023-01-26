using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    public class Client
    {
        private IContract contract;
        private ILogin login;
        public Client()
        {
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>("ClientPoint1");
            ChannelFactory<ILogin> factory2 = new ChannelFactory<ILogin>("ClientPoint2");
            contract = factory.CreateChannel();
            login = factory2.CreateChannel();
        }

        public void InsertAstronaut(Astronaut astronaut)
        {
            contract.Insert(astronaut);
        }

        public void UpdateAstronaut(Astronaut astronaut)
        {
            contract.Update(astronaut);
        }

        public void DeleteAstronaut(int id)
        {
            contract.Delete(id);
        }
        public Astronaut LoadAstronaut(int id)
        {
            return contract.Load(id);
        }

        public DataTable RefreshView(string name)
        {
            return contract.RefreshView(name);
        }
        public int LoginClient(string username, string password)
        {
            return login.Log_in(username, password);
        }
        public int RegistrationClient(string username, string password)
        {
            return login.Registration(username, password);
        }

        public void Astronaut(int id)
        {
            contract.Delete(id);
        }

    }
}
