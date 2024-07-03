using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades; // Asumiendo que aquí está definida la clase Serie y AccesoDatos

namespace Vista
{
    public partial class FrmBacklog : Form
    {
        private List<Serie> backLog;
        private List<Serie> seriesParaVer;
        private Serializadora serializadora;
        private ManejadorBackLog manejador;

        public FrmBacklog()
        {
            InitializeComponent();

            // Inicialización de atributos
            seriesParaVer = new List<Serie>();
            serializadora = new Serializadora();
            manejador = new ManejadorBackLog();

            try
            {
                // Obtener el backlog desde AccesoDatos
                backLog = AccesoDatos.ObtenerBackLog();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones al obtener el backlog
                MessageBox.Show($"Error al obtener el backlog desde la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Puedes decidir cerrar el formulario o manejar la excepción de otra manera según tu lógica de aplicación
                this.Close();
            }
        }

        private void FrmBacklog_Load(object sender, EventArgs e)
        {
            // Asignar manejador al evento NuevaSerieParaVer
            manejador.NuevaSerieParaVer += CambiarEstadoSerie;

            // Asignar DataSource a lstbBacklog
            lstbBacklog.DataSource = backLog;

            // Iniciar el manejador con el backlog actual
            manejador.IniciarManejador(backLog);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaJson = Path.Combine(rutaEscritorio, "SeriesParaVer.json");
            string rutaXml = Path.Combine(rutaEscritorio, "Backlog.xml");

            try
            {
                // Serializar a XML el backlog
                serializadora.GuardarEnXML(backLog, rutaXml);

                // Serializar a JSON las series para ver
                serializadora.Guardar(seriesParaVer, rutaJson);

                MessageBox.Show("Serialización exitosa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones al serializar
                MessageBox.Show($"Error al serializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarEstadoSerie(Serie serie)
        {
            seriesParaVer.Add(serie);
            backLog.Remove(serie);

            ActualizarListBox(lstbBacklog, backLog);
            ActualizarListBox(lstbParaVer, seriesParaVer);
        }

        private void ActualizarListBox(ListBox lb, List<Serie> lista)
        {
            lb.DataSource = null;
            lb.DataSource = lista;
        }
    }
}
