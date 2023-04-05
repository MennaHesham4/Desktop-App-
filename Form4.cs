using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace Testing40_DB
{
    public partial class Form4 : Form
    {
        string x;
        string y;
        string h;
      

        public Form4()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataSet ds=new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            mycon.Open();
            //Select * from tbl_employees;
            SqlCommand emp = new SqlCommand("select * from Employee", mycon);
            SqlCommand dep = new SqlCommand("select * from Department", mycon);
            SqlCommand work = new SqlCommand("select * from works_on", mycon);
            SqlCommand pro = new SqlCommand("select * from project", mycon);
            //SqlCommand mycmds = new SqlCommand(" select count(*) from tbl_employees", mycon);
            //int count = Convert.ToInt32(mycmds.ExecuteScalar());
            //label1.Text = count.ToString();

            SqlDataReader rdr = emp.ExecuteReader();
            while (rdr.Read())
            {
                listBox1.Items.Add(rdr["EmpNo"].ToString() + "   " + rdr["Emp_Fname"].ToString() + "   " + rdr["Emp_Lname"].ToString());
               
            }
            rdr.Close();

            SqlDataReader rd = dep.ExecuteReader();
            while (rd.Read())
             {
                 listBox2.Items.Add(rd["DeptNo"].ToString() + "   " + rd["DeptName"].ToString());

             }
             rd.Close();

            SqlDataReader r = work.ExecuteReader();
            while (r.Read())
             {
                 listBox3.Items.Add(r["EmpNo"].ToString() + "   " + r["ProjectNo"].ToString()+"   "+ r["job"].ToString());

             }
             r.Close();

            SqlDataReader rdrr = pro.ExecuteReader();
            while (rdrr.Read())
             {
                 listBox4.Items.Add(rdrr["ProjectNo"].ToString() + "   " + rdrr["ProjectName"].ToString() );

             }
             rdrr.Close(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            x = this.textBox3.Text; 
            y = this.textBox4.Text;
            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Department_add", mycon);
            //ask question does the sp take paramaters 
            cmd.CommandType = CommandType.StoredProcedure;
            //decalring the sp input parameters (key, value , direction, datatype)
            SqlParameter myparam = new SqlParameter("@DeptNo", x);
            myparam.Direction = ParameterDirection.Input; // specfiy the input keyword
            myparam.DbType = DbType.String; // more strong validation on datatype
            cmd.Parameters.Add(myparam); // add the decalred param on command

            SqlParameter myparam1 = new SqlParameter("@DeptName", y);
            myparam1.Direction = ParameterDirection.Input;
            myparam1.DbType = DbType.String;
            cmd.Parameters.Add(myparam1);
            SqlParameter myparam2 = new SqlParameter("@Location","NY");
            myparam1.Direction = ParameterDirection.Input;
            myparam1.DbType = DbType.String;
            cmd.Parameters.Add(myparam2);
            mycon.Open();

            cmd.ExecuteNonQuery();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            x = this.textBox7.Text;
            y = this.textBox1.Text;
            h = this.textBox2.Text;
            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand add = new SqlCommand("insert into Employee (EmpNo, Emp_Fname, Emp_Lname, DeptNo, Salary)values(@EmpNo, @Emp_Fname, @Emp_Lname, 'd2' ,2900)", mycon);
            mycon.Open();
            add.Parameters.AddWithValue("@EmpNo", x);
            add.Parameters.AddWithValue("@Emp_Fname", y);
            add.Parameters.AddWithValue("@Emp_Lname", h);
            add.ExecuteNonQuery();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            y = this.textBox1.Text;
            h = this.textBox2.Text;

            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand update = new SqlCommand("update Employee set  Emp_Fname=@Emp_Fname, Emp_Lname=@Emp_Lname  where EmpNo=@EmpNo", mycon);
            mycon.Open();

            update.Parameters.AddWithValue("@Emp_Fname", y);
            update.Parameters.AddWithValue("@Emp_Lname", h);
            update.Parameters.AddWithValue("@EmpNo", 5481);
            update.ExecuteNonQuery();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand del = new SqlCommand("Delete from Employee  where EmpNo=@EmpNo", mycon);
            mycon.Open();

            del.Parameters.AddWithValue("@EmpNo", 2581);
            del.ExecuteNonQuery();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            y = this.textBox4.Text;
            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Department_update", mycon);
            //ask question does the sp take paramaters 
            cmd.CommandType = CommandType.StoredProcedure;
            //decalring the sp input parameters (key, value , direction, datatype)
            SqlParameter myparam = new SqlParameter("@DeptNo", "d1");
            myparam.Direction = ParameterDirection.Input; // specfiy the input keyword
            myparam.DbType = DbType.String; // more strong validation on datatype
            cmd.Parameters.Add(myparam); // add the decalred param on command

            SqlParameter myparam1 = new SqlParameter("@DeptName", y);
            myparam1.Direction = ParameterDirection.Input;
            myparam1.DbType = DbType.String;
            cmd.Parameters.Add(myparam1);
            SqlParameter myparam2 = new SqlParameter("@Location", "NY");
            myparam1.Direction = ParameterDirection.Input;
            myparam1.DbType = DbType.String;
            cmd.Parameters.Add(myparam2);
            mycon.Open();

            cmd.ExecuteNonQuery();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            x = this.textBox3.Text;
            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Department_delete", mycon);
            //ask question does the sp take paramaters 
            cmd.CommandType = CommandType.StoredProcedure;
            //decalring the sp input parameters (key, value , direction, datatype)
            SqlParameter myparam = new SqlParameter("@DeptNo", x);
            myparam.Direction = ParameterDirection.Input; // specfiy the input keyword
            myparam.DbType = DbType.String; // more strong validation on datatype
            cmd.Parameters.Add(myparam); // add the decalred param on command

            mycon.Open();

            cmd.ExecuteNonQuery();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd = new SqlCommand("select* from v_works_on", mycon);

            SqlDataReader rdr = cmd.ExecuteReader(); //read only to retreive several rows
            while (rdr.Read())//as long as there are rows.
            {
                listBox6.Items.Add(rdr["EmpNo"].ToString() + "   " + rdr["ProjectNo"].ToString() + "   " + rdr["job"].ToString() );
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ProjectNo = this.textBox5.Text;  
            string ProjectName = this.textBox6.Text;
            
            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("project_add", mycon);//how to call sp inside C#
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter myparam2 = new SqlParameter("@ProjectNo", ProjectNo);
            myparam2.Direction = ParameterDirection.Input;
            myparam2.DbType = DbType.String;
            cmd.Parameters.Add(myparam2);

            SqlParameter myparam = new SqlParameter("@ProjectName", ProjectName);
            myparam.Direction = ParameterDirection.Input; // specfiy the input keyword
            myparam.DbType = DbType.String; // more strong validation on datatype
            cmd.Parameters.Add(myparam);

            SqlParameter myparam4 = new SqlParameter("@budjet", 256478);
            myparam4.Direction = ParameterDirection.Input; // specfiy the input keyword
            myparam4.DbType = DbType.String; // more strong validation on datatype
            cmd.Parameters.Add(myparam4);

            mycon.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("no data");
            }

            dataGridView1.DataSource = ds; //bind datasource with the datagrid control
            dataGridView1.DataMember = ds.Tables[0].ToString();
            DataTableMapping tableMapping = new DataTableMapping("project_add", "project_add");
            da.TableMappings.Add(tableMapping);
            da.Update(ds, "project_add"); //update in real database
            ds.AcceptChanges();

           
        }

        private void button13_Click(object sender, EventArgs e)

        {
            // dataGridView1.Clear();

            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from project", mycon);
            mycon.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("no data");
            }

            dataGridView1.DataSource = ds; 
            dataGridView1.DataMember = ds.Tables[0].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ProjectNo = this.textBox5.Text;
            string ProjectName = this.textBox6.Text;

            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("project_updatee", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@ProjectNo", ProjectNo);
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.String;
            cmd.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@ProjectName", ProjectName);
            param2.Direction = ParameterDirection.Input;
            param2.DbType = DbType.String;
            cmd.Parameters.Add(param2);
            
            mycon.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("no data");
            }

            dataGridView1.DataSource = ds; //bind datasource with the datagrid control
            dataGridView1.DataMember = ds.Tables[0].ToString();
            DataTableMapping tableMapping = new DataTableMapping("project_updatee", "project_updatee");
            da.TableMappings.Add(tableMapping);
            da.Update(ds, "project_updatee"); //update in real database
            ds.AcceptChanges();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ProjectNo = this.textBox5.Text;

            SqlConnection mycon = new SqlConnection("Data Source=DELL;Initial Catalog=QA40-Company;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Project_delete", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@ProjectNo", ProjectNo);
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.String;
            cmd.Parameters.Add(param1);

            mycon.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("no data");
            }

            dataGridView1.DataSource = ds; //bind datasource with the datagrid control
            dataGridView1.DataMember = ds.Tables[0].ToString();
            DataTableMapping tableMapping = new DataTableMapping("Project_delete", "Project_delete");
            da.TableMappings.Add(tableMapping);
            da.Update(ds, "Project_delete"); //update in real database
            ds.AcceptChanges();

        }
    }
}
