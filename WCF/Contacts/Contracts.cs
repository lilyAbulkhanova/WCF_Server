using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        void Insert(Astronaut astronaut);
        [OperationContract]
        void Update(Astronaut astronaut);
        [OperationContract]
        void Delete(int id);
        [OperationContract]
        Astronaut Load(int id);

        [OperationContract]
        DataTable RefreshView(string name);
    }

    [DataContract]
    public class Astronaut
    {
        public Astronaut()
        {

        }

        public Astronaut(int id, string firstName, string secondName, int age, char idNumber, double resultMathTest, decimal resultSportTest, int astronautId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
            IdNumber = idNumber;
            ResultMathTest = resultMathTest;
            ResultSportTest = resultSportTest;
            AstronautId = astronautId;
        }

        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string FirstName { set; get; }
        [DataMember]
        public string SecondName { set; get; }
        [DataMember]
        public int Age { set; get; }
        [DataMember]
        public char IdNumber { set; get; }
        [DataMember]
        public double ResultMathTest { get; set; }
        [DataMember]
        public decimal ResultSportTest { get; set; }
        [DataMember]
        public int AstronautId { get; set; }

    }


    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        int Log_in(string username, string password);
        [OperationContract]
        int Registration(string username, string password);
    }
}
