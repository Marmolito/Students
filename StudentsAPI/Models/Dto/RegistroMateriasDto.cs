namespace StudetnsAPI.Models.Dto
{
    public class RegistroMateriasDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public List<int> materiasIds { get; set; }
    }
}
