using Microsoft.VisualBasic;

namespace Trabajo_Practico_1
{
    public partial class Form1 : Form
    {
        List<Alumno> Lista = new List<Alumno>();


        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            Lista.Add(new Alumno(1, "Tomas", "Lockett", Convert.ToDateTime("07/10/2003"), Convert.ToDateTime("1/01/2024"), true, 4));
            Lista.Add(new Alumno(2, "Agustin", "Soria", Convert.ToDateTime("27/10/2003"), Convert.ToDateTime("1/01/2021"), false, 15));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Lista;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Legajo = Lista.Count + 1;

                string Nombre = textBox1.Text.ToString();
                if (!(Nombre.GetType() == typeof(string)))
                {
                    throw new Exception("No estas poniendo un nombre");
                }
                string Apellido = textBox2.Text.ToString();
                if (!(Apellido.GetType() == typeof(string)))
                {
                    throw new Exception("No estas poniendo un Apellido");
                }
                DateTime Fecha_Nacimiento = dateTimePicker1.Value;
                if (!(Fecha_Nacimiento.GetType() == typeof(DateTime)))
                {
                    throw new Exception("No es una fecha valida");
                }
                DateTime Fecha_Ingreso = dateTimePicker2.Value;
                bool activo;
                string Activo = comboBox1.SelectedItem.ToString();
                if (Activo == "Si")
                {
                    activo = true;
                }
                else
                {
                    activo = false;
                }
                int Cant_Materias_Aprobadas = (int)numericUpDown1.Value;
                if (!Information.IsNumeric(Cant_Materias_Aprobadas))
                {
                    throw new Exception("Tiene que ser un numero");
                }
                Lista.Add(new Alumno(Legajo, Nombre, Apellido, Fecha_Nacimiento, Fecha_Ingreso, activo, Cant_Materias_Aprobadas));

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Lista;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hay nada para modificar");
                }
                var LegajoAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var AlumnoModificado = Lista.Find(x => x.Legajo.ToString() == LegajoAux);

                if (AlumnoModificado != null)
                {
                    AlumnoModificado.Nombre = Interaction.InputBox("Nombre", "Nombre", AlumnoModificado.Nombre);
                    AlumnoModificado.Apellido = Interaction.InputBox("Apellido", "Apellido", AlumnoModificado.Apellido);

                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Lista;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hay nada para Eliminar");
                }
                var LegajoAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var AlumnoEliminado = Lista.Find(x => x.Legajo.ToString() == LegajoAux);

                if (AlumnoEliminado != null)
                {
                    Lista.Remove(AlumnoEliminado);
                    AlumnoEliminado=null;
                    GC.Collect();
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Lista;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var LegajoAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var AlumnoAux = Lista.Find(x => x.Legajo.ToString() == LegajoAux);
                if (AlumnoAux == null)
                {
                    throw new Exception("Error no hay alumno");
                }
                textBox3.Text = $"{AlumnoAux.Antiguedad.ToString()} Dias";
                textBox4.Text = AlumnoAux.Materias_No_Aprobadas.ToString();
                textBox5.Text = $"{AlumnoAux.Edad_De_Ingreso.ToString()} Años";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

     
    }
}
