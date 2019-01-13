using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace turism
{
    public partial class Form1 : Form
    {

        public turismEntities entering;

        public Form1()
        {
            InitializeComponent();
            MarshLoad();
            PutLoad();
            TurLoad();
            OtelLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entering = new turismEntities();
            Turist turist;
            turist = new Turist();

            turist.FIO = textBox1.Text;
            turist.pasportNum = textBox2.Text;
            turist.pasportSer = textBox3.Text;
            turist.age = Convert.ToInt32(textBox4.Text);
            turist.address = textBox5.Text;

            entering.Turist_ET.Add(turist);
            entering.SaveChanges();

            var id_cl = (from Turist in entering.Turist_ET
                         where Turist.FIO == textBox1.Text
                         select Turist.idTurist).First();
            Putevka put;
            put = new Putevka();

            put.idMarsh = Convert.ToInt32(textBox6.Text);
            put.idTurist = id_cl;
            put.dateStart = Convert.ToDateTime(textBox7.Text);
            put.dateFinish = Convert.ToDateTime(textBox8.Text);
            put.sumStoimost = 0;

            entering.Putevka_ET.Add(put);
            entering.SaveChanges();
            PutLoad();
        }

        private void MarshLoad()
        {
            entering = new turismEntities();

            var bel = from Marshrut in entering.Marshrut_ET select Marshrut;

            DataTable dt_marshrut = new DataTable("Marshrut");

            dt_marshrut.Columns.Add("ID", typeof(Int32));
            dt_marshrut.Columns.Add("Название отеля", typeof(String));
            dt_marshrut.Columns.Add("Город", typeof(String));
            dt_marshrut.Columns.Add("Стоимость перелета", typeof(Double));
            dt_marshrut.Columns.Add("Стоимость трансфера", typeof(Double));
            dt_marshrut.Columns.Add("Продолжительность", typeof(Int32));
            dt_marshrut.Columns.Add("Примечание", typeof(String));

            foreach (var be in bel)
                dt_marshrut.Rows.Add(
                    be.idMarsh,
                    be.Otel.name,
                    be.city,
                    be.stoimPerelet,
                    be.stoimTransfer,
                    be.prodolgitSutok,
                    be.prim
                   );

            dataGridView3.DataSource = dt_marshrut;
            dataGridView5.DataSource = dt_marshrut;
        }

        private void PutLoad()
        {
            entering = new turismEntities();

            var bel = from Putevka in entering.Putevka_ET select Putevka;

            DataTable dt_putevka = new DataTable("Putevka");

            dt_putevka.Columns.Add("ID", typeof(Int32));
            dt_putevka.Columns.Add("Название отеля", typeof(String));
            dt_putevka.Columns.Add("Город", typeof(String));
            dt_putevka.Columns.Add("Фамилия клиента", typeof(String));
            dt_putevka.Columns.Add("Стоимость", typeof(Double));
            dt_putevka.Columns.Add("Дата начала", typeof(DateTime));
            dt_putevka.Columns.Add("Дата окончания", typeof(DateTime));

            foreach (var be in bel)
                dt_putevka.Rows.Add(
                    be.idPut,
                    be.Marshrut.Otel.name,
                    be.Marshrut.city,
                    be.Turist.FIO,
                    be.sumStoimost,
                    be.dateStart,
                    be.dateFinish
                   );

            dataGridView1.DataSource = dt_putevka;
           }

        private void TurLoad()
        {
            entering = new turismEntities();

            var bel = from Turist in entering.Turist_ET select Turist;

            DataTable dt_turist = new DataTable("Turist");

            dt_turist.Columns.Add("ID", typeof(Int32));
            dt_turist.Columns.Add("ФИО", typeof(String));
            dt_turist.Columns.Add("Возраст", typeof(Int32));
            dt_turist.Columns.Add("Паспортный номер", typeof(String));
            dt_turist.Columns.Add("Паспортная серия", typeof(String));
            dt_turist.Columns.Add("Адрес", typeof(String));
        

            foreach (var be in bel)
                dt_turist.Rows.Add(
                    be.idTurist,
                    be.FIO,
                    be.age,
                    be.pasportNum,
                    be.pasportSer,
                    be.address
                   );

            dataGridView2.DataSource = dt_turist;
        }

        private void OtelLoad()
        {
            entering = new turismEntities();

            var bel = from Otel in entering.Otel_ET select Otel;

            DataTable dt_otel = new DataTable("Otel");

            dt_otel.Columns.Add("ID", typeof(Int32));
            dt_otel.Columns.Add("Название отеля", typeof(String));
            dt_otel.Columns.Add("Страна", typeof(String));
            dt_otel.Columns.Add("Город", typeof(String));
            dt_otel.Columns.Add("Стоимость в сутки", typeof(Double));
           

            foreach (var be in bel)
                dt_otel.Rows.Add(
                    be.idOtel,
                    be.name,
                    be.strana,
                    be.city,
                    be.stoimSut
                  );

            dataGridView4.DataSource = dt_otel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            entering = new turismEntities();
            Otel otel;
            otel = new Otel();

            otel.name = textBox9.Text;
            otel.strana = textBox12.Text;
            otel.city = textBox10.Text;
            otel.stoimSut = Convert.ToDouble(textBox11.Text);
            
            entering.Otel_ET.Add(otel);
            entering.SaveChanges();
            OtelLoad();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            entering = new turismEntities();
            Marshrut marshrut;
            marshrut = new Marshrut();

            int id_s = dataGridView4.CurrentRow.Index;

            int id =
              System.Convert.ToInt32(dataGridView4.Rows[id_s].Cells[0].Value);


            marshrut.city = textBox16.Text;
            marshrut.prim = textBox13.Text;
            marshrut.stoimPerelet = Convert.ToDouble(textBox15.Text);
            marshrut.stoimTransfer = Convert.ToDouble(textBox14.Text);
           marshrut.prodolgitSutok = Convert.ToInt32(textBox17.Text);
            marshrut.idOtel = id;

            entering.Marshrut_ET.Add(marshrut);
            entering.SaveChanges();
            MarshLoad();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            entering = new turismEntities();

            int id_d = dataGridView4.CurrentRow.Index;

            int id_dd =
             System.Convert.ToInt32(dataGridView4.Rows[id_d].Cells[0].Value);

            var bel = from Marshrut in entering.Marshrut_ET 
            where Marshrut.idOtel == id_dd
                      select Marshrut;
            DataTable dt_zaps = new DataTable("Zarplata");

            DataTable dt_marshrut = new DataTable("Marshrut");

            dt_marshrut.Columns.Add("ID", typeof(Int32));
            dt_marshrut.Columns.Add("Название отеля", typeof(String));
            dt_marshrut.Columns.Add("Город", typeof(String));
            dt_marshrut.Columns.Add("Стоимость перелета", typeof(Double));
            dt_marshrut.Columns.Add("Стоимость трансфера", typeof(Double));
            dt_marshrut.Columns.Add("Продолжительность", typeof(Int32));
            dt_marshrut.Columns.Add("Примечание", typeof(String));

            foreach (var be in bel)
                dt_marshrut.Rows.Add(
                    be.idMarsh,
                    be.Otel.name,
                    be.city,
                    be.stoimPerelet,
                    be.stoimTransfer,
                    be.prodolgitSutok,
                    be.prim
                   );

            
            dataGridView5.DataSource = dt_marshrut;
        }
    }
}
