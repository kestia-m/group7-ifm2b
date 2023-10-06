using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Group7_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public int RegisterUser(string name, string surname, string phone,string email, string password, int usertype)
        {
            var checkUser = (from u in data.Users
                             where u.Email.Equals(email)
                             select u).FirstOrDefault();
            if (checkUser == null)
            {
                User newUser = new User()
                {
                    Name = name,
                    Surname = surname,
                    Phone = phone,
                    Email = email,
                    Password = password,
                    Type = usertype,
                };
                data.Users.InsertOnSubmit(newUser);

                try
                {
                    data.SubmitChanges();
                    return 1;//created a new user
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return -1;//error occurred
                }
            }
            else
            {
                return 0; //user already exists
            }
        }

        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
