namespace Application.IO.Site.Models.SystemModels.GeoCep
{
    public class GeoCepModel
    {
        public int Id { get; set; }
        public int IdGeoCidade { get; set; }
        public int IdGeoEstado { get; set; }
        public string Codigo { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
