namespace FirstProject.Entities
{
    public class Sinif
    {
        public int Id { get; set; }
        public string SinifAdi { get; set; }

        public List<Ogrenci> Ogrenciler { get; set; }
    }
}
