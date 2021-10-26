using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace WpfApp2
{
    class Connection
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prog_task2;Integrated Security=True");
        public SqlConnection active()
        {
            if(con.State== ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

    }

}
