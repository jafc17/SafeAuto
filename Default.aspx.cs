using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public double millas;
        public DateTime inicio;
        public DateTime fin;
        public string nombre;
        public DateTime difHrs;
        public TimeSpan diff;
        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            Byte[] Archivo = null;
            string nombreArchivo = string.Empty;
            string extensionArchivo = string.Empty;
            string pathGuardar = @"C:\Users\Jassiel\Documents\ejemplos proyectos varios\WebApplication1\WebApplication1\temp\";
            string nombreDrive = "";
            bool contador = false;
            string renglonNuevo = "";
            
            if (FileUpload1.HasFile == true)
            {
                nombreArchivo = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                extensionArchivo = Path.GetExtension(FileUpload1.FileName);
                FileUpload1.SaveAs(pathGuardar + FileUpload1.FileName);

                try
                {
                    using (StreamReader lector = new StreamReader(pathGuardar + FileUpload1.FileName))
                    {
                        string[] partidas;
                        string[] partidasAnt;

                        /*leer todas lineas del archivo*/
                        string[] lines = System.IO.File.ReadAllLines(pathGuardar + FileUpload1.FileName);

                        //recorrer el arreglo
                        for (int i = 0; i < lines.Length; i++)
                        {
                            //linea x linea
                            partidas = lines[i].Split(' ');

                            //primeros renglones
                            if (partidas.Length < 3)
                            {
                                //primer comando
                                if (partidas[0] == "Driver")
                                {
                                    nombreDrive += " " + partidas[1];
                                }
                            }
                            else
                            {
                                if (nombre == null)
                                {
                                    //es el primero
                                    nombre = partidas[1].ToString();
                                    inicio = DateTime.Parse(partidas[2].ToString());
                                    fin = DateTime.Parse(partidas[3].ToString());
                                    millas = double.Parse(partidas[4].ToString());
                                    diff = fin - inicio;
                                    string[] div = diff.ToString().Split(':');
                                    //Alex: 42 miles @ 34 mph renglonNuevo
                                    double hrs = double.Parse(div[1].ToString()) / 60;
                                    double mph = millas / hrs;
                                    renglonNuevo += nombre + ":" + millas.ToString() + " miles @ " + mph+"mph <br/>";
                                }
                                else
                                {
                                    //si es el mismo acumular, sino guardar
                                    if (nombre == partidas[1].ToString())
                                    {
                                        // nombre = partidas[1].ToString();
                                        inicio = DateTime.Parse(partidas[2].ToString());
                                        fin = DateTime.Parse(partidas[3].ToString());
                                        millas += double.Parse(partidas[4].ToString());
                                        TimeSpan diff1 = fin - inicio;
                                        //Alex: 42 miles @ 34 mph
                                        TimeSpan diff2 = diff + diff1;
                                        string[] div = diff.ToString().Split(':');
                                        //Alex: 42 miles @ 34 mph renglonNuevo
                                        double hrs = double.Parse(div[1].ToString()) / 60;
                                        double mph = millas / hrs;

                                        //preguntar si existe algun registro con el nombre del chofer antes
                                        if (renglonNuevo.Contains(nombre))
                                        {
                                            string[] res = renglonNuevo.Split('/');
                                            string resultado = "";
                                            for (int asd = 0; asd < res.Length; asd++)
                                            {
                                                if (res[asd].Contains(nombre))
                                                {
                                                    //existe registro
                                                }
                                                else
                                                {
                                                    resultado += res[asd-1].ToString() + ">";
                                                }
                                            }
                                            renglonNuevo = "";
                                            renglonNuevo = resultado;
                                        }
                                        else
                                        {
                                            renglonNuevo += nombre + ":" + millas.ToString() + " miles @ " + mph + "mph <br/>";
                                        }
                                    }
                                    else
                                    {
                                        //es nuevo
                                        nombre = partidas[1].ToString();
                                        inicio = DateTime.Parse(partidas[2].ToString());
                                        fin = DateTime.Parse(partidas[3].ToString());
                                        millas += double.Parse(partidas[4].ToString());
                                        diff = fin - inicio;
                                        //Alex: 42 miles @ 34 mph
                                        string[] div = diff.ToString().Split(':');
                                        //Alex: 42 miles @ 34 mph renglonNuevo
                                        double hrs = double.Parse(div[1].ToString()) / 60;
                                        double mph = millas / hrs;
                                        renglonNuevo += nombre + ":" + millas.ToString() + " miles @ " + mph + "mph <br/>";
                                    }
                                }
                            }
                        }
                       // checar nombres dentro de la cadena, si no hay agregar el nombre que falta y poner 0 Millas
                        string[] nombresPartes = nombreDrive.Split(' ');

                        for (int op = 0; op < nombresPartes.Length; op++)
                        {
                            if (renglonNuevo.Contains(nombresPartes[op]))
                            {
                                //contiene
                                string existe = "existe";
                            }
                            else
                            {
                                renglonNuevo += nombresPartes[op] + " 0 Millas <br/>";
                            }
                        }

                        lblResultado.Text = renglonNuevo;
                        
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}