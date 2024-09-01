using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace курсовая_приложение
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread t1 = new Thread(ServerOn);
            t1.IsBackground = true;
            t1.Start();
        }
        private void ServerOn()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ep);
            socket.Listen(10);
            while (true)
            {
                Socket ns = socket.Accept();
                Console.WriteLine();
                StringBuilder sb = new StringBuilder();
                int count = 0;
                int count1 = 0;
                byte[] data = new byte[1024];
                byte[] data1 = new byte[1024];
                int count2 = 0;

                byte[] data2 = new byte[1024];

                do
                {
                    count = ns.Receive(data);
                    count1 = ns.Receive(data1);
                    count2 = ns.Receive(data2);
                    listBox1.Items.Add(Encoding.Unicode.GetString(data2, 0, count2) + Encoding.Unicode.GetString(data1, 0, count1) + Encoding.Unicode.GetString(data, 0, count) + "\t");
                } while (socket.Available > 0);
 
                ns.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ep);
            string message1 = textBox5.Text;
            string message2 = ":";

            string message = textBox1.Text;
            byte[] data = Encoding.Unicode.GetBytes(message1);
            socket.Send(data);
            byte[] data2 = Encoding.Unicode.GetBytes(message2);
            socket.Send(data2);
            byte[] data1 = Encoding.Unicode.GetBytes(message);
            socket.Send(data1);
            listBox1.Items.Add("Я: " + message);
            socket.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var query = db.GetTable<patients>();
            listBox2.Items.Clear();

            

            var res2 = from c in query
                       where c.FIO == $"{textBox2.Text}"&& c.diagnosis==$"{textBox3.Text}"
                       select c; 

            foreach (var word in res2)
            {
                listBox2.Items.Add(word);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var query = db.GetTable<patients>();

            var res2 = from c in query
                       where c.FIO == $"{textBox2.Text}" && c.diagnosis == $"{textBox3.Text}"
                       select c;

            foreach (var word in res2)
            {
                if (word.diagnosis == $"{textBox3.Text}")
                {
                    word.medicine = $"{res2.FirstOrDefault().medicine},{textBox4.Text}";
                }
            }

            db.SubmitChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var query = db.GetTable<dischargedpatient>();
            listBox3.Items.Clear();



            var res2 = from c in query
                       where c.FIO == $"{textBox2.Text}" && c.diagnosis == $"{textBox3.Text}"
                       select c;

            foreach (var word in res2)
            {
                listBox3.Items.Add(word);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var query = db.GetTable<analysises>();
            listBox4.Items.Clear();



            var res2 = from c in query
                       where c.FIO == $"{textBox2.Text}" && c.diagnosis == $"{textBox3.Text}"
                       select c;

            foreach (var word in res2)
            {
                listBox4.Items.Add(word);
            }
        }

         
    }
}
