using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace lab_8
{
    public partial class Form1 : Form
    {
        List<int> notastempo = new List<int>();
        List<NotasAlumno> listaNotas = new List<NotasAlumno>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            int nota = Convert.ToInt32(textBox2.Text);
            notastempo.Add(nota);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Guardar a un alumno con sus notas
            NotasAlumno notasAlumno = new NotasAlumno();
            notasAlumno.Nombre = textBox1.Text;
            notasAlumno.Notas = notastempo.GetRange(0, notastempo.Count);
            //Guarda a ese alumno en el listado de notas de alumnos
            listaNotas.Add(notasAlumno);
            //Borrar las notas temporales para el proximo
            Grabar();
            notastempo.Clear();


        }
        private void Grabar()
        {
            string json = JsonConvert.SerializeObject(listaNotas);
            string archivo = "Datos.json";
            System.IO.File.WriteAllText(archivo, json);
        }
    }
}
