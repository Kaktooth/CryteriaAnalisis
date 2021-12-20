using System;
using System.Data;
using System.Windows.Forms;

namespace CryteriaAnalisis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = GetDataGridViewAsDataTable(dataGridView1);

            double price = Convert.ToDouble(textBox1.Text);
            double interest = Convert.ToDouble(textBox2.Text);
            double graphics = Convert.ToDouble(textBox3.Text);

            double[] alternatives = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                var priceWeight = Convert.ToDouble(dt.Rows[i].ItemArray[0]);
                var interestWeight = Convert.ToDouble(dt.Rows[i].ItemArray[1]);
                var graphicsWeight = Convert.ToDouble(dt.Rows[i].ItemArray[2]);
                
                alternatives[i] =
                    price * priceWeight
                    + interest * interestWeight
                    + graphics * graphicsWeight;
                listBox1.Items.Add($"{i}: {alternatives[i]} price: {priceWeight} " +
                    $"interest: {interestWeight} graphics: {graphicsWeight}");
            }
        }
        private DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {
            try
            {
                if (_DataGridView.ColumnCount == 0) return null;
                DataTable dtSource = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null) dtSource.Columns.Add(col.Name, typeof(string));
                    else dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = GetDataGridViewAsDataTable(dataGridView1);

            double price = Convert.ToDouble(textBox1.Text);
            double interest = Convert.ToDouble(textBox2.Text);
            double graphics = Convert.ToDouble(textBox3.Text);

            double price2 = Convert.ToDouble(textBox4.Text);
            double interest2 = Convert.ToDouble(textBox5.Text);
            double graphics2 = Convert.ToDouble(textBox6.Text);

            double weight1 = Convert.ToDouble(textBox7.Text);
            double weight2 = Convert.ToDouble(textBox8.Text);

            double[] alternatives = new double[dt.Rows.Count];
            

            for (int i = 0; i < Convert.ToInt32(dt.Rows.Count / 2); i++)
            {
                var priceWeight = Convert.ToDouble(dt.Rows[i].ItemArray[0]);
                var interestWeight = Convert.ToDouble(dt.Rows[i].ItemArray[1]);
                var graphicsWeight = Convert.ToDouble(dt.Rows[i].ItemArray[2]);

                var priceWeight2 = Convert.ToDouble(dt.Rows[i + 3].ItemArray[0]);
                var interestWeight2 = Convert.ToDouble(dt.Rows[i + 3].ItemArray[1]);
                var graphicsWeight2 = Convert.ToDouble(dt.Rows[i + 3].ItemArray[2]);
                double gamer1Alternatives =
                    price * priceWeight
                    + interest * interestWeight
                    + graphics * graphicsWeight;
                double gamer2Alternatives =
                    price2 * priceWeight2
                    + interest2 * interestWeight2
                    + graphics2 * graphicsWeight2;


                alternatives[i] = (weight1 * gamer1Alternatives) + (weight2 * gamer2Alternatives);

                listBox1.Items.Add($"{i}: {alternatives[i]} price: {priceWeight} " +
                    $"interest: {interestWeight} graphics: {graphicsWeight}");
            }
        }
    }
}
