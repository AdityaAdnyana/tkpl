using System;
using System.Collections.Generic;
using System.Text;




public static class RepoLevel
{
    public static List<Module> MasterTable = new List<Module> {
        new Module("Mekanika Klasik", new List<Lesson>
        {
            new Lesson("Kinematika", "Studi tentang gerak benda tanpa mempedulikan penyebabnya.", "Satuan internasional dari kecepatan?", "m/s"),
            new Lesson("Hukum Newton I", "Benda cenderung mempertahankan keadaannya (Inersia).", "Sifat kecenderungan benda mempertahankan posisinya disebut?", "inersia"),
            new Lesson("Hukum Newton II", "Percepatan sebanding dengan gaya dan berbanding terbalik dengan massa (F=ma).", "Gaya yang diperlukan untuk menggerakkan 1kg benda sebesar 1m/s² adalah ... Newton", "1"),
            new Lesson("Hukum Newton III", "Setiap ada gaya aksi, pasti ada gaya reaksi yang sama besar dan berlawanan arah.", "Jika gaya aksi ke kanan, maka arah gaya reaksi ke?", "kiri"),
            new Lesson("Gaya Gesek", "Gaya yang berlawanan arah dengan kecenderungan arah gerak benda.", "Gaya gesek saat benda belum bergerak sama sekali disebut gaya gesek?", "statis"),
            new Lesson("Usaha", "Hasil kali antara gaya dengan perpindahan benda (W = F x s).", "Satuan internasional untuk Usaha atau Energi?", "joule"),
            new Lesson("Energi Kinetik", "Energi yang dimiliki oleh benda karena sifat geraknya.", "Energi yang bergantung pada massa dan kecepatan benda adalah energi?", "kinetik"),
            new Lesson("Energi Potensial", "Energi yang dimiliki benda karena kedudukan atau ketinggiannya terhadap acuan.", "Energi potensial gravitasi bumi sangat dipengaruhi oleh variabel massa, gravitasi, dan?", "ketinggian"),
            new Lesson("Hukum Kekekalan Energi", "Energi tidak dapat diciptakan atau dimusnahkan, melainkan hanya bisa berubah bentuk.", "Energi mekanik adalah penjumlahan energi kinetik dan energi?", "potensial"),
            new Lesson("Momentum", "Ukuran kesukaran untuk memberhentikan suatu benda yang sedang bergerak (p = m x v).", "Hasil kali antara massa benda dengan kecepatan benda disebut?", "momentum"),
            new Lesson("Impuls", "Perubahan momentum yang terjadi pada rentang waktu tertentu (I = F x delta_t).", "Hasil perkalian antara gaya dengan selang waktu gaya bekerja disebut?", "impuls"),
            new Lesson("Tumbukan Lenting Sempurna", "Tumbukan di mana energi kinetik total sebelum dan sesudah tumbukan adalah sama.", "Nilai koefisien restitusi (e) pada tumbukan lenting sempurna adalah?", "1")
        }),
        new Module("Termodinamika & Gas", new List<Lesson>
        {
            new Lesson("Suhu & Kalor", "Kalor mengalir secara alami dari benda bersuhu tinggi ke rendah.", "Satuan standar internasional (SI) untuk suhu?", "kelvin"),
            
            new Lesson("Hukum Termodinamika I", "Prinsip kekekalan energi yang disesuaikan pada sistem termodinamika.", "Bentuk energi yang berpindah karena adanya perbedaan suhu disebut?", "kalor")
        }),
        new Module("Gelombang & Optik", new List<Lesson>
        {
            new Lesson("Gelombang Transversal", "Gelombang yang arah getarnya tegak lurus dengan arah rambatnya.", "Contoh gelombang transversal yang bisa dilihat langsung oleh mata adalah gelombang?", "cahaya"),
            new Lesson("Gelombang Longitudinal", "Gelombang yang arah getarnya sejajar dengan arah rambatnya.", "Contoh gelombang longitudinal yang biasa kita dengar sehari-hari adalah gelombang?", "bunyi"),
            new Lesson("Frekuensi", "Jumlah getaran yang terjadi dalam satu detik.", "Satuan internasional dari frekuensi?", "hertz"),
            new Lesson("Periode", "Waktu yang diperlukan untuk menempuh satu getaran penuh.", "Hubungan periode (T) berbanding terbalik dengan?", "frekuensi"),
            new Lesson("Amplitudo", "Simpangan terjauh atau maksimum dari titik kesetimbangan pada gelombang.", "Kuat lemahnya suara bunyi sangat dipengaruhi oleh variabel?", "amplitudo"),
            new Lesson("Refleksi Cahaya", "Peristiwa pemantulan kembali cahaya yang mengenai permukaan benda.", "Sudut datang akan selalu sama dengan sudut ...", "pantul"),
            new Lesson("Refraksi Cahaya", "Peristiwa pembelokan arah rambat cahaya karena melewati dua medium berbeda kerapatan optiknya.", "Refraksi sering disebut juga dengan istilah?", "pembiasan"),
            new Lesson("Cermin Datar", "Cermin yang permukaan pantulnya berbentuk bidang datar.", "Sifat bayangan pada cermin datar adalah maya, tegak, dan berbentuk?", "sama besar"),
            new Lesson("Cermin Cekung", "Cermin yang permukaan pantulnya melengkung ke dalam dan bersifat mengumpulkan cahaya.", "Cermin cekung memiliki sifat mengumpulkan cahaya yang disebut juga bersifat?", "konvergen"),
            new Lesson("Cermin Cembung", "Cermin yang permukaan pantulnya melengkung ke luar dan bersifat menyebarkan cahaya.", "Kaca spion kendaraan bermotor memanfaatkan teknologi dari cermin?", "cembung"),
            new Lesson("Lensa Cembung", "Lensa yang bagian tengahnya lebih tebal daripada bagian tepinya.", "Penderita rabun dekat (hipermetropi) dapat dibantu menggunakan kacamata lensa?", "cembung"),
            new Lesson("Lensa Cekung", "Lensa yang bagian tengahnya lebih tipis daripada bagian tepinya.", "Penderita rabun jauh (miopi) dapat dibantu menggunakan kacamata lensa?", "cekung"),
            new Lesson("Dispersi", "Peristiwa penguraian cahaya polikromatik (putih) menjadi cahaya monokromatik (pelangi).", "Alat optik berbentuk segitiga kaca yang biasa digunakan untuk mendispersi cahaya disebut?", "prisma"),
            new Lesson("Interferensi Cahaya", "Perpaduan antara dua atau lebih gelombang cahaya yang koheren.", "Interferensi yang saling menguatkan disebut dengan interferensi?", "konstruktif"),
            new Lesson("Difraksi Cahaya", "Peristiwa pelenturan cahaya saat melewati celah yang sangat sempit.", "Peristiwa pembelokan atau pelenturan gelombang saat melewati celah disebut?", "difraksi")
        })
    };
}
