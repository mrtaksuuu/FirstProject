namespace FirstProject.Entities
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string OgrenciNo { get; set; }

        public int SinifId { get; set; }
        public Sinif sinif { get; set; }
    }
}
