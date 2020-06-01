-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jan 18, 2020 at 02:40 AM
-- Server version: 5.7.11
-- PHP Version: 5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `groupesbd`
--

-- --------------------------------------------------------

--
-- Table structure for table `adhesion`
--

CREATE TABLE `adhesion` (
  `ID` varchar(63) DEFAULT NULL,
  `nomGroupe` varchar(50) DEFAULT NULL,
  `status` int(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `adhesion`
--

INSERT INTO `adhesion` (`ID`, `nomGroupe`, `status`) VALUES
('1', 'foot', 40),
('10', 'tennis', 2),
('96fd87a2-19ad-4bd8-a952-a7e9fadc943c', 'natation', 2),
('96fd87a2-19ad-4bd8-a952-a7e9fadc943c', 'hockey', 1),
('96fd87a2-19ad-4bd8-a952-a7e9fadc943c', 'golf', 4),
('5', 'golf', 1),
('5', 'tennis', 4),
('5', 'foot', 1),
('5', 'hockey', 5),
('5', 'natation', 2),
('2aa3e3e0-a71b-440a-8527-7dfe22427476', 'natation', 1),
('2aa3e3e0-a71b-440a-8527-7dfe22427476', 'TI', 1),
('b30468a5-dd9d-4199-9e7c-fc87ce51357e', 'TI', 1),
('b30468a5-dd9d-4199-9e7c-fc87ce51357e', 'arts', 1),
('23', 'arts', 1),
('23', 'foot', 4),
('23', 'natation', 2),
('23', 'physique', 2),
('test24', 'physique', 2),
('test25', 'physique', 3),
('test26', 'physique', 2),
('5', 'baseball', 2),
('272627bd-b6fa-4216-a3ba-ba2cdba1542c', 'baseball', 4),
('562e6d33-2e8f-4f4f-849c-08e922e9429a', 'tennis', 4),
('562e6d33-2e8f-4f4f-849c-08e922e9429a', 'baseball', 4),
('5', 'course', 4),
('23', 'golf', 4),
('20', 'test99', 4),
('5', 'test99', 4),
('66', 'TI', 1),
('20', 'groupe2021', 1),
('5', 'groupe2022', 4),
('5', 'groupe2024', 4),
('5', 'groupe2026', 4),
('5', 'groupe2027', 4),
('5', 'groupe2028', 4),
('5', 'groupe2029', 4),
('1', 'groupe2030', 1),
('20', 'groupe2031', 1),
('1', 'groupe2032', 4),
('1', 'groupe2034', 2),
('5', 'groupe2035', 1),
('1', 'groupe40', 2),
('5', 'groupe103', 4),
('5', 'groupe105', 2),
('1', 'groupe110', 1),
('5', 'groupe222', 4);

-- --------------------------------------------------------

--
-- Table structure for table `groupe`
--

CREATE TABLE `groupe` (
  `nomGroupe` varchar(50) DEFAULT NULL,
  `admin` varchar(63) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `groupe`
--

INSERT INTO `groupe` (`nomGroupe`, `admin`) VALUES
('foot', 'c0f538e7-c7f3-4c82-9aeb-6d631200b348'),
('tennis', '6ade1f5c-77cd-456d-b24c-9d34499db221'),
('hockey', '4712a529-068f-4a8e-ba0b-9b56583b26f4'),
('natation', '1'),
('golf', '1'),
('golf', '1'),
('judo', '1'),
('TI', '5'),
('TIT', '5'),
('Maths', '5'),
('physique', '5'),
('dessin', '5'),
('AS54', '5'),
('AAA', '5'),
('arts', '5'),
('baseball', '7e818fea-6031-43f0-ae52-5c5509610bd0'),
('danse', '272627bd-b6fa-4216-a3ba-ba2cdba1542c'),
('nothing', '5'),
('sport', '5'),
('musique', '10'),
('course', '20'),
('test99', '5'),
('groupe261', '5'),
('groupe 262', '5'),
('groupe2020', '5'),
('google', '5'),
('groupe2021', '5'),
('groupe2022', '1'),
('groupe2023', '5'),
('groupe2024', '1'),
('groupe2025', '5'),
('groupe2026', '1'),
('groupe2027', '1'),
('groupe2028', '1'),
('groupe2029', '1'),
('groupe2030', '5'),
('groupe2031', '5'),
('groupe2032', '5'),
('groupe2034', '5'),
('groupe2035', '1'),
('groupewise', '5'),
('groupe40', '5'),
('groupe41', '5'),
('groupe50', '5'),
('groupe111', 'c27d5fe0-6fd7-4617-8bbc-440edebd7d85'),
('groupe100', '5'),
('groupe101', '5'),
('groupe103', '1'),
('groupe104', '1'),
('groupe105', '1'),
('groupe110', '5'),
('groupe222', '1'),
('groupe333', '5');

-- --------------------------------------------------------

--
-- Table structure for table `personne`
--

CREATE TABLE `personne` (
  `ID` varchar(63) NOT NULL,
  `courriel` varchar(50) DEFAULT NULL,
  `passWord` varchar(50) DEFAULT NULL,
  `userName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `personne`
--

INSERT INTO `personne` (`ID`, `courriel`, `passWord`, `userName`) VALUES
('1', 'aaa@yahoo.fr', 'aaapw', 'aaa'),
('13beed58-e6f7-4f2c-a4b0-68771f672e99', 'ahmed@yahoo.fr', '333', 'ahmed'),
('1be660c6-92df-4dff-b7f3-bc7950a896ba', 'kouki@yahoo.fr', 'koukipw', 'kouki'),
('20', 'steve@yahoo.fr', 'stevepw', 'steve'),
('23', 'test23@yahoo.fr', 'test23', 'test23'),
('2489b8be-26fa-4260-8c8a-fd54e85b446e', 'farouk@yahoo.fr', 'farouk', 'farouk'),
('272627bd-b6fa-4216-a3ba-ba2cdba1542c', 'yousra@yahoo.fr', 'yousra', 'yousra'),
('2aa3e3e0-a71b-440a-8527-7dfe22427476', 'bilel@yahoo.fr', '123', 'bilel'),
('3488deaf-9072-4fbc-8629-9a67272b8445', 'user1@yahoo.fr', 'user1', 'user1'),
('439873ee-6911-438c-b851-31248f2cb82c', 'personne2@yahoo.fr', 'personne2', 'personne2'),
('4bb601c1-de9a-4f93-92a1-7d69c46ccbf6', 'youcef@yahoo.fr', '123', 'youcef'),
('5', 'smail@yahoo.fr', 'smailpw', 'smail'),
('562e6d33-2e8f-4f4f-849c-08e922e9429a', 'kenza@yahoo.fr', 'kenza', 'kenza'),
('61e51d76-5d6c-46cc-b80b-dce3dc4399c9', 'zaki@yahoo.fr', 'zakipw', 'zaki'),
('66', 'zzz@yahoo.fr', 'zzz', 'zzz'),
('6ef9f2df-46df-4da8-84f5-896eb48b0082', 'aziz@yahoo.fr', 'aziz', 'aziz'),
('7e818fea-6031-43f0-ae52-5c5509610bd0', 'amine@yahoo.fr', 'amine', 'amine'),
('814b4fde-74d0-41a4-bc82-1b9fdb9b70ed', 'user3@yahoo.fr', 'user3', 'user3'),
('96fd87a2-19ad-4bd8-a952-a7e9fadc943c', 'ali@yahoo.fr', '123', 'ali'),
('9c1440e4-19aa-473d-96b9-6b9df10a79cf', 'khaled@yahoo.fr', 'khaled', 'khaled'),
('b30468a5-dd9d-4199-9e7c-fc87ce51357e', 'selma@yahoo.fr', '333', 'selma'),
('c27d5fe0-6fd7-4617-8bbc-440edebd7d85', 'user10@yahoo.fr', 'user10', 'user10'),
('cc53b6c0-2cb2-419c-9ca7-a892cb430946', 'user4@yahoo.fr', 'user4', 'user4'),
('daed1c23-c53c-4ed9-8040-980460c4318a', 'houda@yahoo.fr', 'houdapw', 'houda'),
('f2b50711-0daf-4ba5-bcfb-07fbdb846c9f', 'prince@yahoo.fr', 'prince', 'prince'),
('fe3d0ff9-cff7-4cba-a7e6-213645b4baf7', 'test@yahoo.fr', 'testpw', 'test'),
('ff8531fb-b5fa-4c15-9692-8316c9bcd4b3', 'mail@yahoo.fr', '     bgg', 'fds'),
('test24', 'test24@yahoo.fr', 'test24', 'test24'),
('test25', 'test25@yahoo.fr', 'test25', 'test25'),
('test26', 'test26@yahoo.fr', 'test26', 'test26');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `courriel` (`courriel`),
  ADD UNIQUE KEY `userName` (`userName`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
