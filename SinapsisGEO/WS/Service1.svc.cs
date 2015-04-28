using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SinapsisGEO.WS
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        // Para usar HTTP GET, agregue el atributo [WebGet]. (El valor predeterminado de ResponseFormat es WebMessageFormat.Json)
        // Para crear una operación que devuelva XML,
        //     agregue [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     e incluya la siguiente línea en el cuerpo de la operación:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Agregue aquí la implementación de la operación
            return;
        }

    

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<Person> GetPlayers()
        {
            List<Person> players = new List<Person>();
            players.Add(new Person { FirstName = "Peyton", LastName = "Manning", Age = 35 });
            players.Add(new Person { FirstName = "Drew", LastName = "Brees", Age = 31 });
            players.Add(new Person { FirstName = "Brett", LastName = "Favre", Age = 58 });

            return players;


            // Agregue aquí más operaciones y márquelas con [OperationContract]
        }
    }

        [DataContract]
        public class Person
        {
            [DataMember]
            public string FirstName { get; set; }

            [DataMember]
            public string LastName { get; set; }

            [DataMember]
            public int Age { get; set; }

            public Person(string firstName, string lastName, int age)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
            }

            public Person()
            {
                // TODO: Complete member initialization
            }
        }
}
