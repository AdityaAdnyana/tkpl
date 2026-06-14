-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 14 Jun 2026 pada 14.05
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `befi`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `essay_quiz`
--

CREATE TABLE `essay_quiz` (
  `Essay_Quiz_ID` int(11) NOT NULL,
  `Quiz_ID` int(11) DEFAULT NULL,
  `quiz` text DEFAULT NULL,
  `correct_answer` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `essay_quiz`
--

INSERT INTO `essay_quiz` (`Essay_Quiz_ID`, `Quiz_ID`, `quiz`, `correct_answer`) VALUES
(1, 1, 'Dua vektor gaya masing-masing besarnya 10 N dan 4 N. Tentukan besar resultan kedua vektor tersebut yang tidak mungkin terjadi!', '5 N'),
(2, 2, 'Balok digantung dengan tali sebagai berikut. Gaya tarik tali masing-masing besarnya F1 = 30 N dan F2 = 40 N saling tegak lurus. Tentukan resultan gaya tarik yang dialami balok!', '50 N'),
(3, 3, 'Seseorang berjalan ke timur sejauh 80 m kemudian berbelok ke selatan dan berjalan sejauh 60 m. Tentukan arah perpindahan orang tersebut!', '37° dari timur ke selatan'),
(4, 5, 'Dua vektor perpindahan sama besar yaitu S meter. Jika resultan kedua vektor perpindahan tersebut besarnya juga S meter, berapakah sudut antara kedua vektor tersebut?', '120°'),
(5, 8, 'Dua gaya masing-masing besarnya 20 N dan 10 N. Jika resultan kedua gaya tersebut 10√7 N, tentukan sudut apit kedua gaya!', '60°'),
(6, 10, 'Di titik P terdapat dua vektor medan magnet yang besarnya masing-masing B1 = 8 tesla dan B2 = 5 tesla. Tentukan resultan medan magnet tersebut!', '5 tesla'),
(7, 11, 'Sebuah vektor F membentuk sudut a terhadap sumbu y positif seperti pada gambar. Komponen vektor itu dapat ditentukan dengan persamaan apa?', 'Fx = F sin a dan Fy = F cos a');

-- --------------------------------------------------------

--
-- Struktur dari tabel `lesson`
--

CREATE TABLE `lesson` (
  `Lesson_ID` int(11) NOT NULL,
  `Module_ID` int(11) DEFAULT NULL,
  `lesson_name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `lesson`
--

INSERT INTO `lesson` (`Lesson_ID`, `Module_ID`, `lesson_name`) VALUES
(1, 1, 'Lesson 2: Penjumlahan Vektor'),
(2, 1, 'Lesson 3: Mengurai Vektor'),
(3, 1, 'Lesson 4: Menjumlahkan Vektor dengan Metode Urai Vektor');

-- --------------------------------------------------------

--
-- Struktur dari tabel `level`
--

CREATE TABLE `level` (
  `Level_ID` int(11) NOT NULL,
  `level_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `level_module_detail`
--

CREATE TABLE `level_module_detail` (
  `Detail_ID` int(11) NOT NULL,
  `Module_ID` int(11) DEFAULT NULL,
  `Level_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `module`
--

CREATE TABLE `module` (
  `Module_ID` int(11) NOT NULL,
  `module_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `module`
--

INSERT INTO `module` (`Module_ID`, `module_name`) VALUES
(1, 'Fisika Kelas X: Vektor');

-- --------------------------------------------------------

--
-- Struktur dari tabel `module_image`
--

CREATE TABLE `module_image` (
  `Module_Image_ID` int(11) NOT NULL,
  `Module_ID` int(11) DEFAULT NULL,
  `image_url` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `objective_quiz`
--

CREATE TABLE `objective_quiz` (
  `Objective_Quiz_ID` int(11) NOT NULL,
  `Quiz_ID` int(11) DEFAULT NULL,
  `quiz` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `objective_quiz`
--

INSERT INTO `objective_quiz` (`Objective_Quiz_ID`, `Quiz_ID`, `quiz`) VALUES
(1, 4, 'Balok ditarik dengan dua gaya besarnya sama yaitu 10 N seperti pada gambar. Besar dan arah resultan gaya tersebut adalah....'),
(2, 6, 'Bola dilempar ke lantai dan terpantul dengan kecepatan seperti pada gambar. Selisih vektor kecepatan bola sebelum dan sesudah terpantul adalah....'),
(3, 7, 'Perhatikan 2 buah vektor kecepatan berikut! Resultan kedua vektor tersebut adalah....'),
(4, 9, 'Dua vektor gaya besarnya sama yaitu 16 N ditunjukkan seperti pada gambar. Resultan kedua vektor tersebut adalah'),
(5, 12, 'Vektor kecepatan yang besarnya 20 m/s membentuk sudut 30° terhadap sumbu x positif. Komponen vektor kecepatan itu memiliki nilai....'),
(6, 13, 'Perhatikan gambar berikut! Jika sin 53° = 4/5, komponen-komponen vektor F adalah .....'),
(7, 14, 'Perhatikan gambar berikut! Jika sin 53° = 4/5, komponen-komponen vektor S adalah....'),
(8, 15, 'Vektor kecepatan 10 m/s yang memiliki arah -210° terhadap sumbu x (+). Komponen vektor tersebut adalah....'),
(9, 16, 'Perhatikan gambar gaya-gaya berikut ini! Resultan ketiga gaya tersebut adalah ....'),
(10, 17, 'Tiga vektor perpindahan seperti pada gambar. Jika luas tiap kotak 4 m², resultan tiga vektor tersebut adalah....'),
(11, 18, 'Di titik pusat diagonal persegi terdapat empat vektor gaya seperti pada gambar berikut: Besar masing-masing vektor, F1 = 4 N, F2 = 1 N, F3 = 1 N, F4 = 4 N. Resultan empat vektor tersebut adalah....'),
(12, 19, 'Tiga buah vektor gaya seperti pada gambar: Resultan vektor tersebut adalah....'),
(13, 20, 'Perhatikan gambar gaya-gaya berikut ini! Resultaan ketiga gaya tersebut adalah'),
(14, 21, 'Arnov berjalan ke timur sejauh 16 m kemudian berbelok 143° (sin 37° = 0,6) dari timur ke barat dan berjalan sejauh 10 m kemudian berhenti. Berdasarkan data tersebut maka: 1) Komponen pergeseran Arnov ke arah utara sejauh 6 m. 2) Komponen pergeseran Arnov ke arah timur sejauh 8 m. 3) Pergeseran Arnov dari posisi awalnya sejauh 10 m. 4) Pergeseran Arnov dari posisi awalnya sejauh 14 m. 5) Arah pegeseran Arnov dari posisi awalnya 37° dari timur ke utara. Pernyataan yang benar adalah....'),
(15, 22, 'Tiga vektor perpindahan seperti pada gambar. Jika tiap persegi luasnya 4 m², resultan vektor tersebut adalah....'),
(16, 23, 'Tiga buah vektor besar dan arahnya ditunjukkan seperti gambar berikut. Resultan ketiga vektor tersebut adalah'),
(17, 24, 'Seorang anak bermain mobil remote. Sambil duduk, mobil yang semula diam didekat kakinya digerakkan ke timur sejauh 5 m, kemudian dibelokkan ke selatan sejauh 5√3 m dan akhirnya dibelokkan ke barat sejauh 10 m. Perpindahan mobil remote tersebut dari tempat duduk anak sejauh....'),
(18, 25, 'Sebuah benda dikenai gaya seperti seperti pada gambar. Besar dan arah gaya yang dialami benda tersebut adalah');

-- --------------------------------------------------------

--
-- Struktur dari tabel `objective_quiz_options`
--

CREATE TABLE `objective_quiz_options` (
  `Objective_Answer_ID` int(11) NOT NULL,
  `Objective_Quiz_ID` int(11) DEFAULT NULL,
  `answer` text DEFAULT NULL,
  `is_correct` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `objective_quiz_options`
--

INSERT INTO `objective_quiz_options` (`Objective_Answer_ID`, `Objective_Quiz_ID`, `answer`, `is_correct`) VALUES
(1, 1, 'A. 10 N, 30° terhadap lantai', 0),
(2, 1, 'B. 10√3 N, 30° terhadap lantai', 1),
(3, 1, 'C. 20 N, 30° terhadap lantai', 0),
(4, 1, 'D. 10 N, 60° terhadap lantai', 0),
(5, 1, 'E. 10√3 N, 60° terhadap lantai', 0),
(6, 2, 'A. 10 m/s', 0),
(7, 2, 'B. 10√2 m/s', 0),
(8, 2, 'C. 10√3 m/s', 1),
(9, 2, 'D. 10√5 m/s', 0),
(10, 2, 'E. 10√7 m/s', 0),
(11, 3, 'A. 2 m/s', 0),
(12, 3, 'B. 2√3 m/s', 1),
(13, 3, 'C. 2√7 m/s', 0),
(14, 3, 'D. 5 m/s', 0),
(15, 3, 'E. 6 m/s', 0),
(16, 4, 'A. 8 N', 0),
(17, 4, 'B. 10 N', 0),
(18, 4, 'C. 12 N', 0),
(19, 4, 'D. 16 N', 1),
(20, 4, 'E. 18 N', 0),
(21, 5, 'A. vx = 10 m/s dan vy = 20 m/s', 0),
(22, 5, 'B. vx = 10√3 m/s dan vy = 20 m/s', 1),
(23, 5, 'C. vx = 10 m/s dan vy = 10 m/s', 0),
(24, 5, 'D. vx = 10 m/s dan vy = 10√3 m/s', 0),
(25, 5, 'E. vx = 10√3 m/s dan vy = 10 m/s', 0),
(26, 6, 'A. Fx = 6 N dan Fy = 8 N', 0),
(27, 6, 'B. Fx = 8 N dan Fy = 6 N', 0),
(28, 6, 'C. Fx = -6 N dan Fy = 8 N', 1),
(29, 6, 'D. Fx = -8 N dan Fy = 6 N', 0),
(30, 6, 'E. Fx = -8 N dan Fy = -6 N', 0),
(31, 7, 'A. Sx = 6 N dan Sy = 8 N', 0),
(32, 7, 'B. Sx = 8 N dan Sy = 6 N', 1),
(33, 7, 'C. Sx = -6 N dan Sy = 8 N', 0),
(34, 7, 'D. Sx = -8 N dan Sy = 6 N', 0),
(35, 7, 'E. Sx = -8 N dan Sy = -6 N', 0),
(36, 8, 'A. vx = -5√3 m/s, vy = 5 m/s', 1),
(37, 8, 'B. vx = -5√3 m/s, vy = -5 m/s', 0),
(38, 8, 'C. vx = -5√2 m/s, vy = 5√2 m/s', 0),
(39, 8, 'D. vx = -5 m/s, vy = 5√3 m/s', 0),
(40, 8, 'E. vx = -5 m/s, vy = 5√3 m/s', 0),
(41, 9, 'A. 200 N', 0),
(42, 9, 'B. 100 N', 0),
(43, 9, 'C. 50√3 N', 0),
(44, 9, 'D. 50√2 N', 1),
(45, 9, 'E. 0 N', 0),
(46, 10, 'A. 3√2 m ke arah 37° dari timur ke utara', 0),
(47, 10, 'B. 5 m ke arah 37° dari timur ke utara', 0),
(48, 10, 'C. 5 m ke arah 53° dari timur ke utara', 0),
(49, 10, 'D. 10 m ke arah 37° dari timur ke utara', 1),
(50, 10, 'E. 10 m ke arah 53° dari timur ke utara', 0),
(51, 11, 'A. 3 N ke arah sumbu x (+)', 0),
(52, 11, 'B. 3 N ke arah sumbu x (-)', 0),
(53, 11, 'C. 3√2 N ke arah sumbu x (+)', 0),
(54, 11, 'D. 3√2 N ke arah sumbu x (-)', 1),
(55, 11, 'E. 5 N ke arah sumbu x (-)', 0),
(56, 12, 'A. √20 N ke sumbu x (-)', 0),
(57, 12, 'B. 20 N ke sumbu x (+)', 0),
(58, 12, 'C. 20 N ke sumbu x (-)', 0),
(59, 12, 'D. 30 N ke sumbu x (-)', 1),
(60, 12, 'E. 30 N ke sumbu x (+)', 0),
(61, 13, 'A. 0 N', 1),
(62, 13, 'B. 2 N', 0),
(63, 13, 'C. 2√3 N', 0),
(64, 13, 'D. 3 N', 0),
(65, 13, 'E. 3√3 N', 0),
(66, 14, 'A. 1) dan 2)', 0),
(67, 14, 'B. 4) dan 5)', 0),
(68, 14, 'C. 3) dan 5)', 0),
(69, 14, 'D. 1), 2), dan 4)', 0),
(70, 14, 'E. 1), 2), 3), dan 5)', 1),
(71, 15, 'A. 6 m', 0),
(72, 15, 'B. 8 m', 0),
(73, 15, 'C. 10 m', 0),
(74, 15, 'D. 20 m', 1),
(75, 15, 'E. 25 m', 0),
(76, 16, 'A. 125 N', 0),
(77, 16, 'B. 100 N', 0),
(78, 16, 'C. 75 N', 0),
(79, 16, 'D. 50 N', 1),
(80, 16, 'E. 25 N', 0),
(81, 17, 'A. 5√3 m', 0),
(82, 17, 'B. 8 m', 0),
(83, 17, 'C. 10 m', 1),
(84, 17, 'D. 20 m', 0),
(85, 17, 'E. 25 m', 0),
(86, 18, 'A. 10 N dengan arah 60° dari barat ke utara', 0),
(87, 18, 'B. 10√3 N dengan arah 30° dari barat ke utara', 0),
(88, 18, 'C. 20 N dengan arah 30° dari timur ke utara', 0),
(89, 18, 'D. 20 N dengan arah 60° dari utara ke barat', 0),
(90, 18, 'E. 20 N dengan arah 60° dari barat ke utara', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `quiz`
--

CREATE TABLE `quiz` (
  `Quiz_ID` int(11) NOT NULL,
  `Lesson_ID` int(11) DEFAULT NULL,
  `quiz_type` varchar(50) DEFAULT NULL,
  `score_weight` decimal(5,2) DEFAULT NULL,
  `quiz_difficulty` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `quiz`
--

INSERT INTO `quiz` (`Quiz_ID`, `Lesson_ID`, `quiz_type`, `score_weight`, `quiz_difficulty`) VALUES
(1, 1, 'Essay', 10.00, 2),
(2, 1, 'Essay', 6.00, 1),
(3, 1, 'Essay', 6.00, 1),
(4, 1, 'Objective', 10.00, 2),
(5, 1, 'Essay', 10.00, 2),
(6, 1, 'Objective', 20.00, 3),
(7, 1, 'Objective', 10.00, 2),
(8, 1, 'Essay', 10.00, 2),
(9, 1, 'Objective', 10.00, 2),
(10, 1, 'Essay', 6.00, 1),
(11, 2, 'Essay', 6.00, 1),
(12, 2, 'Objective', 6.00, 1),
(13, 2, 'Objective', 10.00, 2),
(14, 2, 'Objective', 10.00, 2),
(15, 2, 'Objective', 10.00, 2),
(16, 3, 'Objective', 10.00, 2),
(17, 3, 'Objective', 20.00, 3),
(18, 3, 'Objective', 20.00, 3),
(19, 3, 'Objective', 20.00, 3),
(20, 3, 'Objective', 20.00, 3),
(21, 3, 'Objective', 20.00, 3),
(22, 3, 'Objective', 20.00, 3),
(23, 3, 'Objective', 20.00, 3),
(24, 3, 'Objective', 20.00, 3),
(25, 3, 'Objective', 20.00, 3);

-- --------------------------------------------------------

--
-- Struktur dari tabel `quiz_image`
--

CREATE TABLE `quiz_image` (
  `Quiz_Image_ID` int(11) NOT NULL,
  `Quiz_ID` int(11) DEFAULT NULL,
  `image_url` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `quiz_image`
--

INSERT INTO `quiz_image` (`Quiz_Image_ID`, `Quiz_ID`, `image_url`) VALUES
(1, 2, 'https://drive.google.com/file/d/16L8rpBXeaQzft1B3HYZBc-ugPjed8Spy/view?usp=sharing'),
(2, 4, 'https://drive.google.com/file/d/1FgD2FWdT9e7jAD_FJYGOThylBbPVrxPW/view?usp=drive_link'),
(3, 6, 'https://drive.google.com/file/d/1ZySPPM4mYvE-tZ3Zq5E1Yh-Lk8sk5D0O/view?usp=drive_link'),
(4, 7, 'https://drive.google.com/file/d/1flpckzy4YUSGjlNCdHQcJt73stLgHuH5/view?usp=drive_link'),
(5, 9, 'https://drive.google.com/file/d/1YBGFWRMUZBag3FE6DuSSpRdBQO0-NOHk/view?usp=drive_link'),
(6, 10, 'https://drive.google.com/file/d/1gZx5_OS5SOejmxXfN_1AOAIXq1eu-cnx/view?usp=drive_link'),
(7, 11, 'https://drive.google.com/file/d/1wGQjB3Wql4PuCnswsn90EnJoqB3O-_E1/view?usp=drive_link'),
(8, 12, 'https://drive.google.com/file/d/1Z2JaKhm6eLXXuDB1Bc_Il0ZznKy7a4L0/view?usp=drive_link'),
(9, 13, 'https://drive.google.com/file/d/1dRLRi2DQen4Pe1KUnyP1uVbyFFxenFVL/view?usp=drive_link'),
(10, 14, 'https://drive.google.com/file/d/1itYJgtijwxU0B5GNDXmhBnf4xxBcNHmI/view?usp=drive_link'),
(11, 16, 'https://drive.google.com/file/d/1siFguYM9oCR86Tceom1jbkXHTh1s4pEP/view?usp=drive_link'),
(12, 17, 'https://drive.google.com/file/d/1kH9WVS5B-WCTYZGAq_mCLRR9REAoe5u9/view?usp=drive_link'),
(13, 18, 'https://drive.google.com/file/d/1h4-S3PtgVU2WbUUG8q5b7w2HOUglC_8p/view?usp=drive_link'),
(14, 19, 'https://drive.google.com/file/d/1TTrV0TYttLe9JdfxJZKeYqqQ53jJswBr/view?usp=drive_link'),
(15, 20, 'https://drive.google.com/file/d/1WXtD67oz3dPEBxZQCinW0R0j5P3INdec/view?usp=drive_link'),
(16, 21, 'https://drive.google.com/file/d/1oKvV7VPV54i5PnPM24MyIn1THXIHqUr4/view?usp=drive_link'),
(17, 22, 'https://drive.google.com/file/d/1uY1GOzCqATNKQ-8XF1vlw_DlKREMYI5C/view?usp=drive_link'),
(18, 23, 'https://drive.google.com/file/d/19KVyaKze9L9nghCTwcBbkG6ToeHJ3wCW/view?usp=drive_link'),
(19, 25, 'https://drive.google.com/file/d/1_-1lrvYnIX8ppmtEMsY8-3bhESQ8mO1M/view?usp=drive_link');

-- --------------------------------------------------------

--
-- Struktur dari tabel `reading_material`
--

CREATE TABLE `reading_material` (
  `Reading_Material_ID` int(11) NOT NULL,
  `Module_ID` int(11) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `string_material` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `reading_material_image`
--

CREATE TABLE `reading_material_image` (
  `Reading_Material_Image_ID` int(11) NOT NULL,
  `Reading_Material_ID` int(11) DEFAULT NULL,
  `image_url` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `report_quiz`
--

CREATE TABLE `report_quiz` (
  `Report_Quiz_ID` int(11) NOT NULL,
  `User_ID` int(11) DEFAULT NULL,
  `Quiz_ID` int(11) DEFAULT NULL,
  `Level_ID` int(11) DEFAULT NULL,
  `user_answer` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `User_ID` int(11) NOT NULL,
  `Current_Level_ID` int(11) DEFAULT NULL,
  `Report_Quiz` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `essay_quiz`
--
ALTER TABLE `essay_quiz`
  ADD PRIMARY KEY (`Essay_Quiz_ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`);

--
-- Indeks untuk tabel `lesson`
--
ALTER TABLE `lesson`
  ADD PRIMARY KEY (`Lesson_ID`),
  ADD KEY `Module_ID` (`Module_ID`);

--
-- Indeks untuk tabel `level`
--
ALTER TABLE `level`
  ADD PRIMARY KEY (`Level_ID`);

--
-- Indeks untuk tabel `level_module_detail`
--
ALTER TABLE `level_module_detail`
  ADD PRIMARY KEY (`Detail_ID`),
  ADD KEY `Module_ID` (`Module_ID`),
  ADD KEY `Level_ID` (`Level_ID`);

--
-- Indeks untuk tabel `module`
--
ALTER TABLE `module`
  ADD PRIMARY KEY (`Module_ID`);

--
-- Indeks untuk tabel `module_image`
--
ALTER TABLE `module_image`
  ADD PRIMARY KEY (`Module_Image_ID`),
  ADD KEY `Module_ID` (`Module_ID`);

--
-- Indeks untuk tabel `objective_quiz`
--
ALTER TABLE `objective_quiz`
  ADD PRIMARY KEY (`Objective_Quiz_ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`);

--
-- Indeks untuk tabel `objective_quiz_options`
--
ALTER TABLE `objective_quiz_options`
  ADD PRIMARY KEY (`Objective_Answer_ID`),
  ADD KEY `Objective_Quiz_ID` (`Objective_Quiz_ID`);

--
-- Indeks untuk tabel `quiz`
--
ALTER TABLE `quiz`
  ADD PRIMARY KEY (`Quiz_ID`),
  ADD KEY `Lesson_ID` (`Lesson_ID`);

--
-- Indeks untuk tabel `quiz_image`
--
ALTER TABLE `quiz_image`
  ADD PRIMARY KEY (`Quiz_Image_ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`);

--
-- Indeks untuk tabel `reading_material`
--
ALTER TABLE `reading_material`
  ADD PRIMARY KEY (`Reading_Material_ID`),
  ADD KEY `Module_ID` (`Module_ID`);

--
-- Indeks untuk tabel `reading_material_image`
--
ALTER TABLE `reading_material_image`
  ADD PRIMARY KEY (`Reading_Material_Image_ID`),
  ADD KEY `Reading_Material_ID` (`Reading_Material_ID`);

--
-- Indeks untuk tabel `report_quiz`
--
ALTER TABLE `report_quiz`
  ADD PRIMARY KEY (`Report_Quiz_ID`),
  ADD KEY `User_ID` (`User_ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`),
  ADD KEY `Level_ID` (`Level_ID`);

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`User_ID`),
  ADD KEY `Current_Level_ID` (`Current_Level_ID`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `essay_quiz`
--
ALTER TABLE `essay_quiz`
  MODIFY `Essay_Quiz_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT untuk tabel `lesson`
--
ALTER TABLE `lesson`
  MODIFY `Lesson_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT untuk tabel `level`
--
ALTER TABLE `level`
  MODIFY `Level_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `level_module_detail`
--
ALTER TABLE `level_module_detail`
  MODIFY `Detail_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `module`
--
ALTER TABLE `module`
  MODIFY `Module_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT untuk tabel `module_image`
--
ALTER TABLE `module_image`
  MODIFY `Module_Image_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `objective_quiz`
--
ALTER TABLE `objective_quiz`
  MODIFY `Objective_Quiz_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT untuk tabel `objective_quiz_options`
--
ALTER TABLE `objective_quiz_options`
  MODIFY `Objective_Answer_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=91;

--
-- AUTO_INCREMENT untuk tabel `quiz`
--
ALTER TABLE `quiz`
  MODIFY `Quiz_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT untuk tabel `quiz_image`
--
ALTER TABLE `quiz_image`
  MODIFY `Quiz_Image_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT untuk tabel `reading_material`
--
ALTER TABLE `reading_material`
  MODIFY `Reading_Material_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `reading_material_image`
--
ALTER TABLE `reading_material_image`
  MODIFY `Reading_Material_Image_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `report_quiz`
--
ALTER TABLE `report_quiz`
  MODIFY `Report_Quiz_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `User_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `essay_quiz`
--
ALTER TABLE `essay_quiz`
  ADD CONSTRAINT `essay_quiz_ibfk_1` FOREIGN KEY (`Quiz_ID`) REFERENCES `quiz` (`Quiz_ID`);

--
-- Ketidakleluasaan untuk tabel `lesson`
--
ALTER TABLE `lesson`
  ADD CONSTRAINT `lesson_ibfk_1` FOREIGN KEY (`Module_ID`) REFERENCES `module` (`Module_ID`);

--
-- Ketidakleluasaan untuk tabel `level_module_detail`
--
ALTER TABLE `level_module_detail`
  ADD CONSTRAINT `level_module_detail_ibfk_1` FOREIGN KEY (`Module_ID`) REFERENCES `module` (`Module_ID`),
  ADD CONSTRAINT `level_module_detail_ibfk_2` FOREIGN KEY (`Level_ID`) REFERENCES `level` (`Level_ID`);

--
-- Ketidakleluasaan untuk tabel `module_image`
--
ALTER TABLE `module_image`
  ADD CONSTRAINT `module_image_ibfk_1` FOREIGN KEY (`Module_ID`) REFERENCES `module` (`Module_ID`);

--
-- Ketidakleluasaan untuk tabel `objective_quiz`
--
ALTER TABLE `objective_quiz`
  ADD CONSTRAINT `objective_quiz_ibfk_1` FOREIGN KEY (`Quiz_ID`) REFERENCES `quiz` (`Quiz_ID`);

--
-- Ketidakleluasaan untuk tabel `objective_quiz_options`
--
ALTER TABLE `objective_quiz_options`
  ADD CONSTRAINT `objective_quiz_options_ibfk_1` FOREIGN KEY (`Objective_Quiz_ID`) REFERENCES `objective_quiz` (`Objective_Quiz_ID`);

--
-- Ketidakleluasaan untuk tabel `quiz`
--
ALTER TABLE `quiz`
  ADD CONSTRAINT `quiz_ibfk_1` FOREIGN KEY (`Lesson_ID`) REFERENCES `lesson` (`Lesson_ID`);

--
-- Ketidakleluasaan untuk tabel `quiz_image`
--
ALTER TABLE `quiz_image`
  ADD CONSTRAINT `quiz_image_ibfk_1` FOREIGN KEY (`Quiz_ID`) REFERENCES `quiz` (`Quiz_ID`);

--
-- Ketidakleluasaan untuk tabel `reading_material`
--
ALTER TABLE `reading_material`
  ADD CONSTRAINT `reading_material_ibfk_1` FOREIGN KEY (`Module_ID`) REFERENCES `module` (`Module_ID`);

--
-- Ketidakleluasaan untuk tabel `reading_material_image`
--
ALTER TABLE `reading_material_image`
  ADD CONSTRAINT `reading_material_image_ibfk_1` FOREIGN KEY (`Reading_Material_ID`) REFERENCES `reading_material` (`Reading_Material_ID`);

--
-- Ketidakleluasaan untuk tabel `report_quiz`
--
ALTER TABLE `report_quiz`
  ADD CONSTRAINT `report_quiz_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `users` (`User_ID`),
  ADD CONSTRAINT `report_quiz_ibfk_2` FOREIGN KEY (`Quiz_ID`) REFERENCES `quiz` (`Quiz_ID`),
  ADD CONSTRAINT `report_quiz_ibfk_3` FOREIGN KEY (`Level_ID`) REFERENCES `level` (`Level_ID`);

--
-- Ketidakleluasaan untuk tabel `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`Current_Level_ID`) REFERENCES `level` (`Level_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
