using Newtonsoft.Json;

namespace Entidades
{
    public class Serializadora : IGuardar<List<Serie>>
    {
        //explícita
        void IGuardar<List<Serie>>.Guardar(List<Serie> series, string ruta)
        {
            try
            {
                string json = JsonConvert.SerializeObject(series, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(ruta, json);
            }
            catch (Exception ex)
            {

                throw new BackLogException("Error al guardar las series para ver en formato JSON", ex);
            }
        }


        public void GuardarEnXML(List<Serie> series, string ruta)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Serie>));
                    serializer.Serialize(writer, series);
                }
            }
            catch (Exception ex)
            {
                throw new BackLogException("Error al guardar las series en formato XML", ex);
            }
        }
    }
}