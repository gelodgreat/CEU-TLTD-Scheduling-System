CREATE DATABASE  IF NOT EXISTS `ceutltdscheduler` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ceutltdscheduler`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win32 (x86)
--
-- Host: TLTD5    Database: ceutltdscheduler
-- ------------------------------------------------------
-- Server version	5.6.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `borrowers_reg`
--

DROP TABLE IF EXISTS `borrowers_reg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `borrowers_reg` (
  `bor_id` varchar(20) NOT NULL,
  `bor_fname` varchar(45) NOT NULL,
  `bor_mname` varchar(45) NOT NULL,
  `bor_surname` varchar(45) NOT NULL,
  `bor_college` varchar(45) NOT NULL,
  PRIMARY KEY (`bor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `borrowers_reg`
--

LOCK TABLES `borrowers_reg` WRITE;
/*!40000 ALTER TABLE `borrowers_reg` DISABLE KEYS */;
INSERT INTO `borrowers_reg` VALUES ('11-05234','Brenz','Villanueva','Buenaventura','Scitech'),('13-02321','Angelo','Reyes','Umali','Scitech');
/*!40000 ALTER TABLE `borrowers_reg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compute`
--

DROP TABLE IF EXISTS `compute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compute` (
  `totalunits` int(12) DEFAULT NULL,
  `equipmenttype` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compute`
--

LOCK TABLES `compute` WRITE;
/*!40000 ALTER TABLE `compute` DISABLE KEYS */;
INSERT INTO `compute` VALUES (51,'Laptop'),(52,'Laptop'),(53,'Laptop');
/*!40000 ALTER TABLE `compute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipments`
--

DROP TABLE IF EXISTS `equipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equipments` (
  `equipmentno` varchar(20) NOT NULL,
  `equipment` varchar(100) NOT NULL,
  `equipmentsn` varchar(50) NOT NULL,
  `equipmentowner` varchar(45) DEFAULT NULL,
  `equipmentlocation` varchar(100) DEFAULT NULL,
  `equipmentstatus` varchar(45) DEFAULT NULL,
  `equipmenttype` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`equipmentno`,`equipmentsn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipments`
--

LOCK TABLES `equipments` WRITE;
/*!40000 ALTER TABLE `equipments` DISABLE KEYS */;
INSERT INTO `equipments` VALUES ('1','Nady Wireless Mic. 101XL','101145349','TLTD','TLT Main','Good Condition','Microphone'),('1','Sony Shotgun Mic. ECM-672','xxx31','TLTD','L.A Auditorium','Good Condition','Microphone'),('11','Mitsubishi XD420 ','1703085','TLTD','DS sub-center','Good Condition','DLP/LCD'),('11','Lenovo','L3-B3655','TLTD','LA Auditorium','Good Condition','Laptop'),('12','Mitsubishi EX100U','8715','TLTD','DS sub-center','Good Condition','DLP/LCD'),('123','3','3','3','23','123','Laptop'),('15','Thinkpad','L3-L9215','TLTD','LAH Sub-center','Good Condition','Laptop'),('16','Mitsubishi XD500U','7337','TLTD','DS sub-center','Good Condition','DLP/LCD'),('17','Lenovo R61','L3-N8464','TLTD','LAH Sub-center','Good Condition','Laptop'),('18','Lenovo R61','L3-N8536','TLTD','LAH Sub-center','Good Condition','Laptop'),('19','Mitsubishi XD510U','7494','TLTD','DS sub-center','Good Condition','DLP/LCD'),('19','HP Compaq CQ45','CND-9142XTV','TLTD','TLTD Main','Good Condition','Laptop'),('2','Sony Shotgun Mic. ECM-672','xxx32','TLTD','L.A Auditorium','Good Condition','Microphone'),('2','Shure Mic. SM 58','xxx33','TLTD','Radio Booth','Endorsed to MASSCOM','Microphone'),('20','Mitsubishi XD510U','7486','TLTD','DS sub-center','Good Condition','DLP/LCD'),('22','Mitsubishi XL255OU','1081','TLTD','FFH 201','Good Condition','DLP/LCD'),('22','HP SHIT','123wq','TLTD','eqweqw','Good Condtion','Laptop'),('22235','HP MADAFAKA','taee111','TLTD','TLTD','Good Condtion','Laptop'),('24','Mitsubishi XD28OU','5888','TLTD','LAH Sub-center','Good Condition','DLP/LCD'),('24','Lenovo G450','CBB0457324','TLTD','DS Sub-center','Good Condition','Laptop'),('25','Mitsubishi XD28OU','5887','TLTD','LAH Sub-center','Good Condition','DLP/LCD'),('25','Lenovo G430','EB12616443','TLTD','TLTD Main','Good Condition','Laptop'),('26','Mitsubishi XD28OU','5910','TLTD','DS sub-center','Good Condition','DLP/LCD'),('26','Compaq 511','CNU01320H0','TLTD','TLTD Main','Good Condition','Laptop'),('27','Mitsubishi XD28OU','5886','TLTD','LA Auditorium','Good Condition','DLP/LCD'),('27','Toshiba Satellite L745','6B333427W','TLTD','TLTD Main','Good Condition','Laptop'),('28','Toshiba Satellite L745','6B313519W','TLTD','TLTD Main','Good Condition','Laptop'),('29','Toshiba Satellite L745','6B333399W','TLTD','TLTD Main','Good Condition','Laptop'),('29','Hitachi CP-X302U','FICHO2517','TLTD','Training Room','Good Condition','DLP/LCD'),('3','IBM Thinkpad 1834','KV-K1583','TLTD','LAH Sub-center','Good Condition','Laptop'),('3','Shure Mic. SM 58','xxx34','TLTD','Radio Booth','Endorsed to MASSCOM','Microphone'),('30','Toshiba Satellite L745','6B333433W','TLTD','TLTD Main','Good Condition','Laptop'),('31','Toshiba Satellite Pro L840','6C173477W','TLTD','LAH Sub-center','Good Condition','Laptop'),('32','Toshiba Satellite Pro L840','6C173495W','TLTD','DS Sub-center','Good Condition','Laptop'),('32','Hitachi CP-X302U','F1JE01645','TLTD','Chapel','Good Condition','DLP/LCD'),('33','Toshiba Satellite Pro L840','6C173301W','TLTD','TLTD Main','Good Condition','Laptop'),('33','Hitachi CP-X302U','F1JE01256','TLTD','TLTD Main','Good Condition','DLP/LCD'),('34','Hitachi CP-X3021WN','F2BE50152','TLTD','TLTD Main','Good Condition','DLP/LCD'),('35','Hitachi CP-X3021WN','F2AE04192','TLTD','TLTD Main','Good Condition','DLP/LCD'),('36','Toshiba Satellite Pro L840','6C173665W','TLTD','TLTD Main','Good Condition','Laptop'),('36','Hitachi CP-X3021WN','F2AE04189','TLTD','TLTD Main','Good Condition','DLP/LCD'),('37','Toshiba Satellite Pro L840','4D072547C','TLTD','TLTD Main','Good Condition','Laptop'),('37','Hitachi CP-X3021WN','F2AE04207','TLTD','TLTD Main','Good Condition','DLP/LCD'),('38','Toshiba Satellite Pro L840','4D072495C','TLTD','TLTD Main','Good Condition','Laptop'),('38','Hitachi CP-X3021WN','F2BE50134','TLTD','LAH Sem. Rm. 1','Good Condition','DLP/LCD'),('39','Toshiba Satellite Pro L840','4D072548C','TLTD','TLTD Main','Good Condition','Laptop'),('39','Hitachi CP-X3021WN','F2AE04213','TLTD','LAH Sem. Rm. 2 & 3','Good Condition','DLP/LCD'),('4','DLP U5-132(plus)','UD5EA4B20791','TLTD','LAH Sub-center','Good Condition','DLP/LCD'),('4','Shure Mic. SM 58','xxx35','TLTD','Radio Booth','Endorsed to MASSCOM','Microphone'),('40','Toshiba Satellite Pro L840','4D072469C','TLTD','TLTD Main','Good Condition','Laptop'),('40','Hitachi CP-X3021','F2BE61516','TLTD','TLTD Main','Good Condition','DLP/LCD'),('41','Toshiba Satellite Pro L840','4D072577C','TLTD','TLTD Main','Good Condition','Laptop'),('41','Hitachi CP-X3021','F3BE61506','TLTD','TLTD Main','Good Condition','DLP/LCD'),('42','Toshiba Satellite Pro L840','4D072496C','TLTD','TLTD Main','Good Condition','Laptop'),('42','Hitachi CP-X3021','F3BE61581','TLTD','TLTD Main','Good Condition','DLP/LCD'),('43','Toshiba Satellite Pro L840','4D072461C','TLTD','TLTD Main','Good Condition','Laptop'),('43','Hitachi CP-X3021','F3BE61533','TLTD','TLTD Main','Good Condition','DLP/LCD'),('44','Toshiba Satellite Pro L840','4D072529C','TLTD','TLTD Main','Good Condition','Laptop'),('44','Hitachi CP-X4015','F21H01598','TLTD','FFH 201','Good Condition','DLP/LCD'),('45','Toshiba Satellite Pro L840','4D072497C','TLTD','DS Sub-center','Good Condition','Laptop'),('45','Epson EB-X14H434C','PTUK3600615','TLTD','TLTD Main','Good Condition','DLP/LCD'),('46','Toshiba Satellite Pro L840','4D072550C','TLTD','LAH Sub-center','Good Condition','Laptop'),('46','Epson EB-X14H434C','PTUK3600284','TLTD','MIR','Good Condition','DLP/LCD'),('46','Shure Mic. SM 58','xxx36','TLTD','MIR','Good Condition','Microphone'),('47','Toshiba Tecra C50-B107E','9F054881H','TLTD','LAH Sub-center','Good Condition','Laptop'),('47','Epson EB-X14H434C','PTUK3600677','TLTD','LA Auditorium','Good Condition','DLP/LCD'),('47','Shure Mic. SM 58','xxx37','TLTD','MIR','Good Condition','Microphone'),('48','Toshiba Tecra C50-B107E','9F054893H','TLTD','LAH Sub-center','Good Condition','Laptop'),('48','Epson EB-X14H434C','PTUK3600661','TLTD','LA Auditorium','Good Condition','DLP/LCD'),('48','Shure Mic. SM 58','xxx38','TLTD','MIR','Good Condition','Microphone'),('49','Toshiba Tecra C50-B107E','9F054891H','TLTD','LAH Sub-center','Good Condition','Laptop'),('49','Epson','RKFF350019L','TLTD','LA Auditorium','Good Condition','DLP/LCD'),('49','Shure Mic. SM 58','xxx39','TLTD','MIR','Good Condition','Microphone'),('50','Toshiba Tecra C50-B107E','9F054865H','TLTD','LAH Sub-center','Good Condition','Laptop'),('50','Hitachi CP-X3030WN','F4EH07994','TLTD','SDV Conference','Good Condition','DLP/LCD'),('50','Shure Mic. SM 58','xxx40','TLTD','LA Auditorium','Good Condition','Microphone'),('51','Toshiba Tecra C50-B107E','9F054867H','TLTD','LAH Sub-center','Good Condition','Laptop'),('51','Hitachi CP-X3030WN','F4EH08001','TLTD','TLTD Main','Good Condition','DLP/LCD'),('51','Mic. Dynamic Super cardiod lead vocal ','xxx41','TLTD','L.A Auditorium','Good Condition','Microphone'),('52','Toshiba Tecra C50-B107E','9F054858H','TLTD','LAH Sub-center','Good Condition','Laptop'),('52','Mic. Dynamic Super cardiod lead vocal ','xxx42','TLTD','L.A Auditorium','Good Condition','Microphone'),('52','Hitachi CP-X3030WN','xxx71','TLTD','LA Auditorium','Good Condition','DLP/LCD'),('53','Toshiba Tecra C50-B107E','9F054857H','TLTD','DS Sub-center','Good Condition','Laptop'),('53','Hitachi CP-X3030WN','F4EH08007','TLTD','LAH Sub-center','Good Condition','DLP/LCD'),('53','Mic. Dynamic Super cardiod lead vocal ','xxx43','TLTD','FFH 201','Good Condition','Microphone'),('54','Toshiba Tecra C50-B107E','9F054844H','TLTD','DS Sub-center','Good Condition','Laptop'),('54','Hitachi CP-X3030WN','F4EH08019','TLTD','LAH Sub-center','Good Condition','DLP/LCD'),('54','Mic. Dynamic Super cardiod lead vocal ','xxx44','TLTD','FFH 201','Good Condition','Microphone'),('55','Toshiba Tecra C50-B107E','9F054869H','TLTD','DS Sub-center','Good Condition','Laptop'),('55','Hitachi CP-X3030WN','F4EH08020','TLTD','LAH Sub-center','Good Condition','DLP/LCD'),('55','Mic. Dynamic Super cardiod lead vocal ','xxx45','TLTD','FFH 201','Good Condition','Microphone'),('56','Toshiba Tecra C50-B107E','9F054866H','TLTD','DS Sub-center','Good Condition','Laptop'),('56','Hitachi CP-X3030WN','F4EH08260','TLTD','DS sub-center','Good Condition','DLP/LCD'),('56','Mic. EV PL 24','xxx46','TLTD','L.A Auditorium','Good Condition','Microphone'),('57','Toshiba Tecra C50-B107E','9F054868H','TLTD','DS Sub-center','Good Condition','Laptop'),('57','Hitachi CP-X3030WN','F4EH08259','TLTD','DS sub-center','Good Condition','DLP/LCD'),('57','Mic. EV PL 24','xxx47','TLTD','L.A Auditorium','Good Condition','Microphone'),('58','Toshiba Tecra C50-B107E','9F054840H','TLTD','DS Sub-center','Good Condition','Laptop'),('58','Hitachi CP-X3030WN','F4EH08014','TLTD','DS sub-center','Good Condition','DLP/LCD'),('58','Mic. EV PL 24','xxx48','TLTD','L.A Auditorium','Good Condition','Microphone'),('59','Toshiba Tecra C50-B107E','9F054862H','TLTD','TLTD Main','Good Condition','Laptop'),('59','Hitachi CP-X 4030','F4HH00101','TLTD','FFH 201','Good Condition','DLP/LCD'),('59','Mic. EV PL 24','xxx49','TLTD','L.A Auditorium','Good Condition','Microphone'),('6','DLP U5-632H (plus)','U5GEA6220520','TLTD','DS sub-center','Good Condition','DLP/LCD'),('60','Toshiba Tecra C50-B107E','9F054880H','TLTD','TLTD Main','Good Condition','Laptop'),('60','Hitachi CP-X 3041 WN','F5FH00474','TLTD','TLTD Main','Good Condition','DLP/LCD'),('60','Mic. EV PL 24','xxx50','TLTD','L.A Auditorium','Good Condition','Microphone'),('61','Toshiba Tecra C50-B107E','9F054879H','TLTD','TLTD Main','Good Condition','Laptop'),('61','Hitachi CP-X 3041 WN','F5FH00307','TLTD','TLTD Main','Good Condition','DLP/LCD'),('61','Mic. EV PL 24','xxx51','TLTD','L.A Auditorium','Good Condition','Microphone'),('62','Toshiba Tecra C50-B107E','9F054851H','TLTD','TLTD Main','Good Condition','Laptop'),('62','Hitachi CP-X 3041 WN','F5FH00476','TLTD','TLTD Main','Good Condition','DLP/LCD'),('62','Mic. EV PL 24','xxx52','TLTD','FFH 201','Good Condition','Microphone'),('63','Toshiba Tecra C50-B107E','9F054859H','TLTD','TLTD Main','Good Condition','Laptop'),('63','Hitachi CP-X 3041 WN','F5FH00298','TLTD','TLTD Main','Good Condition','DLP/LCD'),('63','Mic. EV PL 24','xxx53','TLTD','FFH 201','Good Condition','Microphone'),('64','Toshiba Tecra C50-B107E','9F054915H','TLTD','TLTD Main','Good Condition','Laptop'),('64','Hitachi CP-X 3041 WN','F5FH00296','TLTD','TLTD Main','Good Condition','DLP/LCD'),('64','Mic. EV PL 24','xxx54','TLTD','FFH 202','Good Condition','Microphone'),('65','Toshiba Tecra C50-B107E','9F054914H','TLTD','TLTD Main','Good Condition','Laptop'),('65','Hitachi CP-X 3041 WN','F5FH0081','TLTD','TLTD Main','Good Condition','DLP/LCD'),('65','Mic. EV PL 24','xxx55','TLTD','FFH 203','Good Condition','Microphone'),('66','Toshiba Tecra C50-B107E','9F054873H','TLTD','TLTD Main','Good Condition','Laptop'),('66','Hitachi CP-X 3041 WN','F5FH00487','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD'),('66','Sennheiser E 385S','xxx56','TLTD','MIR','Good Condition','Microphone'),('67','Toshiba Tecra C50-B107E','9F054894H','TLTD','TLTD Main','Good Condition','Laptop'),('67','Hitachi CP-X 3041 WN','F5FH00306','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD'),('67','Sennheiser E 385S','xxx57','TLTD','MIR','Good Condition','Microphone'),('68','Toshiba Tecra C50-B107E','9F054898H','TLTD','TLTD Main','Good Condition','Laptop'),('68','Hitachi CP-X 3041 WN','F5FH0080','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD'),('68','Sennheiser E 385S','xxx58','TLTD','MIR','Good Condition','Microphone'),('69','Toshiba Tecra C50-B107E','9F054870H','TLTD','TLTD Main','Good Condition','Laptop'),('69','Hitachi CP-X 3041 WN','F5FH00301','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD'),('69','Sennheiser E 385S','xxx59','TLTD','MIR','Good Condition','Microphone'),('7','DLP U5-632H (plus)','U5GEA5620825','TLTD','DS sub-center','Good Condition','DLP/LCD'),('70','Toshiba Tecra C50-B107E','9F054895H','TLTD','TLTD Main','Good Condition','Laptop'),('70','Hitachi CP-X 3041 WN','F5FH00302','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD'),('70','Sennheiser E 385S','xxx60','TLTD','MIR','Good Condition','Microphone'),('71','Hitachi CP-X 3041 WN','F5FH00300','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD'),('71','Sennheiser E 385S','xxx61','TLTD','MIR','Good Condition','Microphone'),('72','Hitachi CP-X 3041 WN','F5FH00475','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD'),('72','Shure SM 58','xxx62','TLTD','LA Auditorium','Good Condition','Microphone'),('73','Hitachi CP-X 3041 WN','F5FH00486','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD'),('73','Shure SM 58','xxx63','TLTD','LA Auditorium','Good Condition','Microphone'),('74','Shure SM 58','xxx64','TLTD','LA Auditorium','Good Condition','Microphone'),('75','Shure SM 58','xxx65','TLTD','LA Auditorium','Good Condition','Microphone'),('76','Shure SM 58','xxx66','TLTD','LA Auditorium','Good Condition','Microphone'),('9','DLP EX100U','7749','TLTD','TLTD Main','Good Condition','DLP/LCD'),('Bardl Mic 01','Bardl Sf 22 600-2','xxx01','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 02','Bardl Sf 22 600-2','xxx02','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 03','Bardl Sf 22 600-2','xxx03','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 04','Bardl Sf 22 600-2','xxx04','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 05','Bardl Sf 22 600-2','xxx05','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 06','Bardl Sf 22 600-2','xxx06','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 07','Bardl Sf 22 600-2','xxx07','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 08','Bardl Sf 22 600-2','xxx08','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 09','Bardl Sf 22 600-2','xxx09','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 10','Bardl Sf 22 600-2','xxx10','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 11','Bardl Sf 22 600-2','xxx11','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 12','Bardl Sf 22 600-2','xxx12','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 13','Bardl Sf 22 600-2','xxx13','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 14','Bardl Sf 22 600-2','xxx14','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 15','Bardl Sf 22 600-2','xxx15','TLTD','TLT Main','Good Condition','Microphone'),('Bardl Mic 16','Bardl Sf 22 600-2','xxx16','TLTD','SDV Conference','Good Condition','Microphone'),('Bardl Mic 17','Bardl Sf 22 600-2','xxx17','TLTD','SDV Conference','Good Condition','Microphone'),('Bardl Mic 18','Bardl Sf 22 600-2','xxx18','TLTD','SDV Conference','Good Condition','Microphone'),('Bardl Mic 19','Bardl Sf 22 600-2','xxx19','TLTD','SDV Conference','Good Condition','Microphone'),('Bardl Mic 20','Bardl Sf 22 600-2','xxx20','TLTD','LAH Sub-center','Good Condition','Microphone'),('Bardl Mic 21','Bardl Sf 22 600-2','xxx21','TLTD','LAH Sub-center','Good Condition','Microphone'),('Bardl Mic 22','Bardl Sf 22 600-2','xxx22','TLTD','LAH Sub-center','Good Condition','Microphone'),('Bardl Mic 23','Bardl Sf 22 600-2','xxx23','TLTD','Dent. Sci Sub-center','Good Condition','Microphone'),('Bardl Mic 24','Bardl Sf 22 600-2','xxx24','TLTD','Dent. Sci Sub-center','Good Condition','Microphone'),('Bardl Mic 25','Bardl Sf 22 600-2','xxx25','TLTD','Dent. Sci Sub-center','Good Condition','Microphone'),('Bardl Mic 26','Bardl Sf 22 600-2','xxx26','TLTD','Dent. Sci Sub-center','Good Condition','Microphone'),('Bardl Mic 27','Bardl Sf 22 600-3','xxx27','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone'),('Bardl Mic 28','Bardl Sf 22 600-4','xxx28','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone'),('Bardl Mic 29','Bardl Sf 22 600-5','xxx29','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone'),('Bardl Mic 30','Bardl Sf 22 600-6','xxx30','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone'),('DLP #01','Hitachi CP-X3021WN','FILE03017','SNHM','TLT Main','Good condition','DLP/LCD'),('DLP #01','Plus-U2-132','HD5EA4B0788','Nursing','TLT Main','Good Condition','DLP/LCD'),('DLP #01','Taxan-U6-112','NA6EA6C20712','IDL','TLT Main','Good Condition ','DLP/LCD'),('DLP #02','Mitsubishi XD 510U','7514','MEDTECH','MT Dean\'s Office','Good Condition','DLP/LCD'),('DLP #02','Taxan-U6-112','NA6EA6C22004','IDL','TLT Main','Good Condition ','DLP/LCD'),('DLP #03','XD510U','5375','SNHM','DS sub-center','Good condition','DLP/LCD'),('DLP #03','Plus-U5-632H','S5CEA6820658','Nursing','Nursing Dean\'s Office','Good Condition','DLP/LCD'),('DLP #04','XD510U','7517','SNHM','DS sub-center','Good condition','DLP/LCD'),('DLP #04','Plus-U5-632H','S5AEA6921089','Nursing','DS Sub-center','Good Condition','DLP/LCD'),('DLP #05','XD280U','3005005','SNHM','DS sub-center','Good condition','DLP/LCD'),('DLP #05','Mitsubishi EX100U','7889','Nursing','TLT Main','Good Condition','DLP/LCD'),('DLP #06','Hitachi CP-X3021WN','F5FH00450','TLTD','TLT Main','Good condition','DLP/LCD'),('DLP #06','Premiere PD-S611','P41PILA06179000716','Nursing','TLT Main','Good Condition','DLP/LCD'),('DLP #07','Hitachi CP-X3021WN','F5FH00100','TLTD','TLT Main','Good condition','DLP/LCD'),('DLP #07','Taxan KG-PS100S','PSCAA7421096','Nursing','LAH Sub-center','Good Condition','DLP/LCD'),('DLP #08','Hitachi CP-X3021WN','F5FH00445','TLTD','TLT Main','Good condition','DLP/LCD'),('DLP #08','Taxan KG-PS100S','PSCAA7321219','Nursing','LAH Sub-center','Good Condition','DLP/LCD'),('DLP #10','Mitsubishi EX100U','8579','Nursing','GDL 202','Good Condition','DLP/LCD'),('DLP #10','Panasoniv/PT-LB75EA','SD8350214','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #11','Panasoniv/PT-LB75EA','SC8350356','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #12','Panasoniv/PT-LB75EA','SC8350188','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #13','Panasoniv/PT-LB75EA','SC8350186','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #14','Panasoniv/PT-LB75EA','SC8350185','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #15','Hitachi CP-X 3041 Wn','F5FH00440','TLTD','DS Sub-center','Good Condition','DLP/LCD'),('DLP #15','Panasonic PTLB75EA','SD8530170','Nursing','LAH Sub-center','Good Condition','DLP/LCD'),('DLP #16','Hitachi CP-X 3041 Wn','F5FH00308','TLTD','DS Sub-center','Good Condition','DLP/LCD'),('DLP #16','Panasonic PTLB75EA','SC8350183','Nursing','LAH Sub-center','Good Condition','DLP/LCD'),('DLP #17','Hitachi CP-X 3041 Wn','F5FH00451','TLTD','TLT Main','Good Condition','DLP/LCD'),('DLP #17','Hitachi CP-X 3041 Wn','F5FH0079','TLTD','DS Sub-center','Good Condition','DLP/LCD'),('DLP #18','Hitachi CP-X 3041 Wn','F5FH00488','TLTD','TLT Main','Good Condition','DLP/LCD'),('DLP #19','Hitachi CP-X 3041 Wn','F5FH00444','TLTD','TLT Main','Good Condition','DLP/LCD'),('DLP #20','Hitachi CP-X 3041 Wn','F5FH00452','TLTD','TLT Main','Good Condition','DLP/LCD'),('DLP #21','Hitachi CP-X 3041 Wn','F5FH00452','TLTD','TLT Main','Good Condition','DLP/LCD'),('DLP #5','Taxan-KG-PS1000S','PSCAA7520743','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #6','Hitachi CP-X 3041','F5FH00481','TLTD','LAH sub-center','Good Condition','DLP/LCD'),('DLP #6','Taxan-KG-PS1000S','PSCAA7520571','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #7','Hitachi CP-X 3041','F5FH00486','TLTD','LAH sub-center','Good Condition','DLP/LCD'),('DLP #7','Taxan-KG-PS1000S','PSCAA7421647','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #8','Hitachi CP-X 3041','F5FH00482','TLTD','LAH sub-center','Good Condition','DLP/LCD'),('DLP #8','Taxan-KG-PS120X','PSBAA7A20518','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('DLP #9','Taxan-KG-PS120X','PSBAA7A20533','Dentistry','DS Sub-center','Good Condition','DLP/LCD'),('KP #01','HR A290','658705','IDL','IDL Office','Good Condition ','Karaoke'),('KP #02','HR A290','658733','IDL','IDL Office','Good Condition ','Karaoke'),('KP #03','HR A290','658740','IDL','IDL Office','Good Condition ','Karaoke'),('KP #04','HR A290','658738','IDL','IDL Office','Good Condition ','Karaoke'),('KP #05','HR A290','658739','IDL','LAH Sub-center','Good Condition ','Karaoke'),('KP #06','HR A290','658706','IDL','LAH Sub-center','Good Condition ','Karaoke'),('KP #07','HR A290','658728','IDL','LAH Sub-center','Good Condition ','Karaoke'),('KP #08','HR A290','658735','IDL','TLT Main','Good Condition ','Karaoke'),('KP #09','HR A290','658704','IDL','TLT Main','Good Condition ','Karaoke'),('KP #10','HR A290','658734','IDL','TLT Main','Good Condition ','Karaoke'),('LCD #02','Hitachi CP-X3021WN','FILE02409','SNHM','TLT Main','Good condition','DLP/LCD'),('OHP #01','3M 1608','168501','IDL','SDV 501','Good Condition ','Overhead Projector'),('OHP #02','3M 1608','168459','IDL','SDV 502','Good Condition ','Overhead Projector'),('OHP #03','3M 1608','xxx87','IDL','SDV 503','Good Condition ','Overhead Projector'),('OHP #04','3M 1608','xxx88','IDL','SDV 504','Good Condition ','Overhead Projector'),('OHP #05','3M 1608','168450','IDL','SDV 505','Good Condition ','Overhead Projector'),('PCS-01','Altec Lansing 2420','xxx84','TLTD ','TLT Main','Good Condition','PC Speakers'),('PCS-02','Altec Lansing 2420','xxx85','TLTD ','LAH sub-center','Good Condition','PC Speakers'),('PCS-03','Altec Lansing 2420','xxx86','TLTD ','DS Sub-center','Good Condition','PC Speakers'),('PCS-04','Altec Lansing 2620','FDEU00056539','TLTD ','DS Sub-center','Good Condition','PC Speakers'),('PCS-05','Altec Lansing 2621','FDEU0005640','TLTD ','DS Sub-center','Good Condition','PC Speakers'),('PCS-06','Altec Lansing 2622','FDEU0005641','TLTD ','DS Sub-center','Good Condition','PC Speakers'),('PCS-07','Altec Lansing  ','xxx72','TLTD ','TLTD Main','Good Condition','PC Speakers'),('PCS-08','Altec Lansing ','xxx73','TLTD ','TLTD Main','Good Condition','PC Speakers'),('PCS-09','Altec Lansing ','xxx74','TLTD ','TLTD Main','Good Condition','PC Speakers'),('PCS-10','Altec Lansing ','xxx75','TLTD ','TLTD Main','Good Condition','PC Speakers'),('PCS-11 ','Altec Lansing ','xxx76','TLTD ','TLTD Main','Good Condition','PC Speakers'),('PCS-12','Altec Lansing ','xxx77','TLTD ','TLTD Main','Good Condition','PC Speakers'),('PCS-13','Altec Lansing BXR 1321','xxx78','TLTD ','DS Sub-center','Good Condition','PC Speakers'),('PCS-14','Altec Lansing BXR 1322','xxx79','TLTD ','DS Sub-center','Good Condition','PC Speakers'),('PCS-15','Altec Lansing BXR 1323','xxx80','TLTD ','DS Sub-center','Good Condition','PC Speakers'),('PCS-16','Altec Lansing BXR 1324','xxx81','TLTD ','LAH sub-center','Good Condition','PC Speakers'),('PCS-17','Altec Lansing BXR 1325','xxx82','TLTD ','LAH sub-center','Good Condition','PC Speakers'),('PCS-18','Altec Lansing BXR 1326','xxx83','TLTD ','LAH sub-center','Good Condition','PC Speakers'),('Speaker #1,2','Nomad 70 watts','xxx66','IDL','SDV 501','Good Condition ','Speaker'),('Speaker #3,4','Nomad 70 watts','xxx67','IDL','SDV 502','Good Condition ','Speaker'),('Speaker #5,6','Nomad 70 watts','xxx68','IDL','SDV 503','Good Condition ','Speaker'),('Speaker #7,8','Nomad 70 watts','xxx69','IDL','SDV 504','Good Condition ','Speaker'),('Speaker #9,10','Nomad 70 watts','xxx70','IDL','SDV 505','Good Condition ','Speaker'),('TD #01','DENNON DRW 585','2117608360','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #03','DENNON DRW 587','2117608391','IDL','FFH 201','Condemned','Tape Deck'),('TD #04','DENNON DRW 588','2117608220','IDL','FFH 201','Condemned','Tape Deck'),('TD #05','DENNON DRW 589','2117608382','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #06','DENNON DRW 590','2117608364','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #07','DENNON DRW 591','2117608333','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #08','DENNON DRW 592','2117608375','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #09','DENNON DRW 593','2117608390','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #10','DENNON DRW 594','2117608388','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #11','DENNON DRW 595','2117608322','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #12','DENNON DRW 596','2117608361','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #13','DENNON DRW 597','2117608386','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #14','DENNON DRW 598','2117608362','IDL','FFH 201','Good Condition ','Tape Deck'),('TD #15','DENNON DRW 599','2117608318','IDL','FFH 201','Good Condition ','Tape Deck'),('VHSP #01','HR-J791AM','098Q0844','IDL','FFH 201','Good Condition ','VHS Player'),('VHSP #02','HR-J791AM','108Q0094','IDL','FFH 202','Good Condition ','VHS Player'),('VHSP #03','HR-J791AM','098Q0902','IDL','FFH 203','Good Condition ','VHS Player'),('VHSP #04','HR-J791AM','098Q0875','IDL','FFH 204','Good Condition ','VHS Player'),('VHSP #05','HR-J791AM','098Q0851','IDL','FFH 205','Good Condition ','VHS Player');
/*!40000 ALTER TABLE `equipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `penalties`
--

DROP TABLE IF EXISTS `penalties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `penalties` (
  `bor_id` varchar(20) NOT NULL,
  `bor_fname` varchar(45) DEFAULT NULL,
  `bor_mname` varchar(45) DEFAULT NULL,
  `bor_lname` varchar(45) DEFAULT NULL,
  `bor_price` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`bor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `penalties`
--

LOCK TABLES `penalties` WRITE;
/*!40000 ALTER TABLE `penalties` DISABLE KEYS */;
INSERT INTO `penalties` VALUES ('11-05234','Brenz','Villanueva','Buenaventura',198.99),('13-02321','Angelo','Reyes','Umali',20.00);
/*!40000 ALTER TABLE `penalties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `released_info`
--

DROP TABLE IF EXISTS `released_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `released_info` (
  `rel_id_passnum` int(11) DEFAULT NULL,
  `rel_reservation_no` varchar(255) NOT NULL,
  `rel_borrower` varchar(200) NOT NULL,
  `rel_equipment_no` varchar(20) NOT NULL,
  `rel_equipment` varchar(100) NOT NULL,
  `rel_assign_date` date NOT NULL,
  `rel_starttime` time NOT NULL,
  `rel_endtime` time NOT NULL,
  `rel_status` varchar(45) NOT NULL,
  `rel_releasedby` varchar(100) NOT NULL,
  PRIMARY KEY (`rel_reservation_no`),
  KEY `reservationno_idx` (`rel_reservation_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `released_info`
--

LOCK TABLES `released_info` WRITE;
/*!40000 ALTER TABLE `released_info` DISABLE KEYS */;
INSERT INTO `released_info` VALUES (0,'08102016-14627165 ','Buenaventura, Brenz','08102016-14627165','Mitsubishi XD420 ','2016-09-10','10:30:00','11:00:00','Released','Umali Angelo'),(1,'36102016-97706189 ','Buenaventura, Brenz','36102016-97706189','HR A290','2016-09-10','10:30:00','01:00:00','Released','Umali Angelo');
/*!40000 ALTER TABLE `released_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservation` (
  `reservationno` varchar(255) NOT NULL,
  `equipmentno` varchar(20) NOT NULL,
  `equipment` varchar(100) NOT NULL,
  `equipmentsn` varchar(50) NOT NULL,
  `id` varchar(45) NOT NULL,
  `date` date NOT NULL,
  `starttime` time NOT NULL,
  `endtime` time NOT NULL,
  `borrower` varchar(200) NOT NULL,
  `location` varchar(200) NOT NULL,
  `reservedby` varchar(100) NOT NULL,
  `res_status` varchar(45) NOT NULL,
  `activitytype` varchar(45) NOT NULL,
  `actname` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`reservationno`,`equipmentno`,`equipment`,`equipmentsn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservation`
--

LOCK TABLES `reservation` WRITE;
/*!40000 ALTER TABLE `reservation` DISABLE KEYS */;
INSERT INTO `reservation` VALUES ('08102016-14627165','11','Mitsubishi XD420 ','1703085','11-05234','2016-09-10','10:30:00','11:00:00','Buenaventura, Brenz','ISC403','Umali Angelo','Released','Academic',''),('39102016-54473332','16','Mitsubishi XD500U','7337','11-05234','2016-09-10','01:30:00','11:00:00','Buenaventura, Brenz','LA Auditorium','Umali Angelo','Not Released','Academic',''),('53102016-77146936','KP #04','HR A290','658738','11-05234','2016-09-10','01:00:00','02:00:00','Buenaventura, Brenz','sccscs','Umali Angelo','scs','Academic','');
/*!40000 ALTER TABLE `reservation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservation_equipments`
--

DROP TABLE IF EXISTS `reservation_equipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservation_equipments` (
  `reservationno` varchar(255) NOT NULL,
  `equipmentno` varchar(20) NOT NULL,
  `equipment` varchar(100) NOT NULL,
  `equipmentsn` varchar(50) NOT NULL,
  KEY `reservation_equipments_ibfk_1` (`reservationno`),
  CONSTRAINT `reservation_equipments_ibfk_1` FOREIGN KEY (`reservationno`) REFERENCES `reservation` (`reservationno`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservation_equipments`
--

LOCK TABLES `reservation_equipments` WRITE;
/*!40000 ALTER TABLE `reservation_equipments` DISABLE KEYS */;
INSERT INTO `reservation_equipments` VALUES ('08102016-14627165','11','Mitsubishi XD420 ','1703085'),('39102016-54473332','16','Mitsubishi XD500U','7337'),('53102016-77146936','KP #04','HR A290','658738');
/*!40000 ALTER TABLE `reservation_equipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `returned_info`
--

DROP TABLE IF EXISTS `returned_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `returned_info` (
  `ret_id` int(11) NOT NULL,
  `ret_reservation_num` varchar(45) NOT NULL,
  `ret_id_passnum` int(11) DEFAULT NULL,
  `ret_borrower` varchar(45) NOT NULL,
  `ret_equipment_no` varchar(20) NOT NULL,
  `ret_equipment` varchar(100) NOT NULL,
  `ret_assign_date` date NOT NULL,
  `ret_starttime` time NOT NULL,
  `ret_endtime` time NOT NULL,
  `ret_status` varchar(45) NOT NULL,
  `ret_releasedby` varchar(100) NOT NULL,
  `ret_returnedto` varchar(100) NOT NULL,
  `ret_remarks` varchar(200) NOT NULL,
  `returned_infocol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ret_id`),
  KEY `ret_id_passnum_idx` (`ret_id_passnum`),
  KEY `rel_reservation_no_idx` (`ret_reservation_num`),
  CONSTRAINT `rel_reservation_no` FOREIGN KEY (`ret_reservation_num`) REFERENCES `released_info` (`rel_reservation_no`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `returned_info`
--

LOCK TABLES `returned_info` WRITE;
/*!40000 ALTER TABLE `returned_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `returned_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff_reg`
--

DROP TABLE IF EXISTS `staff_reg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `staff_reg` (
  `staff_id` varchar(20) NOT NULL,
  `staff_fname` varchar(45) NOT NULL,
  `staff_mname` varchar(45) NOT NULL,
  `staff_surname` varchar(45) NOT NULL,
  `staff_type` varchar(45) NOT NULL,
  `staff_username` varchar(45) NOT NULL,
  `staff_password` varchar(512) NOT NULL,
  PRIMARY KEY (`staff_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff_reg`
--

LOCK TABLES `staff_reg` WRITE;
/*!40000 ALTER TABLE `staff_reg` DISABLE KEYS */;
INSERT INTO `staff_reg` VALUES ('13-02321','Angelo','Reyes','Umali','User','admin','c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec');
/*!40000 ALTER TABLE `staff_reg` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-10 17:19:21
