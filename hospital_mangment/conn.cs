using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_mangment
{
    internal class conn
    {
        public static DataClasses1DataContext connect()
        {
            DataClasses1DataContext data=new DataClasses1DataContext("Data Source=DESKTOP-6ITGS10\\SQLEXPRESS;Initial Catalog=hospital;Integrated Security=True; TrustServerCertificate=True ");
            return data;
        }
    }
}
