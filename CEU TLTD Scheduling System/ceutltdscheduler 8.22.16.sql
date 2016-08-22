CREATE DATABASE  IF NOT EXISTS `ceutltdscheduler` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ceutltdscheduler`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
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
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `accounts` (
  `id` int(20) NOT NULL,
  `fname` varchar(100) DEFAULT NULL,
  `mname` varchar(100) DEFAULT NULL,
  `lname` varchar(100) DEFAULT NULL,
  `college` varchar(200) DEFAULT NULL,
  `accountscol` varchar(100) DEFAULT NULL,
  `usertype` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
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
  `isTaken` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`equipmentno`,`equipmentsn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipments`
--

LOCK TABLES `equipments` WRITE;
/*!40000 ALTER TABLE `equipments` DISABLE KEYS */;
INSERT INTO `equipments` VALUES ('1','Nady Wireless Mic. 101XL','101145349','TLTD','TLT Main','Good Condition','Microphone','false'),('1','Sony Shotgun Mic. ECM-672','xxx31','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('11','Mitsubishi XD420 ','1703085','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('11','Lenovo','L3-B3655','TLTD','LA Auditorium','Good Condition','Laptop','false'),('12','Mitsubishi EX100U','8715','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('123','3','3','3','23','123','Laptop','false'),('15','Thinkpad','L3-L9215','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('16','Mitsubishi XD500U','7337','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('17','Lenovo R61','L3-N8464','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('18','Lenovo R61','L3-N8536','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('19','Mitsubishi XD510U','7494','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('19','HP Compaq CQ45','CND-9142XTV','TLTD','TLTD Main','Good Condition','Laptop','false'),('2','Sony Shotgun Mic. ECM-672','xxx32','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('2','Shure Mic. SM 58','xxx33','TLTD','Radio Booth','Endorsed to MASSCOM','Microphone','false'),('20','Mitsubishi XD510U','7486','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('22','Mitsubishi XL255OU','1081','TLTD','FFH 201','Good Condition','DLP/LCD','false'),('22','HP SHIT','123wq','TLTD','eqweqw','Good Condtion','Laptop','false'),('22235','HP MADAFAKA','taee111','TLTD','TLTD','Good Condtion','Laptop','false'),('24','Mitsubishi XD28OU','5888','TLTD','LAH Sub-center','Good Condition','DLP/LCD','false'),('24','Lenovo G450','CBB0457324','TLTD','DS Sub-center','Good Condition','Laptop','false'),('25','Mitsubishi XD28OU','5887','TLTD','LAH Sub-center','Good Condition','DLP/LCD','false'),('25','Lenovo G430','EB12616443','TLTD','TLTD Main','Good Condition','Laptop','false'),('26','Mitsubishi XD28OU','5910','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('26','Compaq 511','CNU01320H0','TLTD','TLTD Main','Good Condition','Laptop','false'),('27','Mitsubishi XD28OU','5886','TLTD','LA Auditorium','Good Condition','DLP/LCD','false'),('27','Toshiba Satellite L745','6B333427W','TLTD','TLTD Main','Good Condition','Laptop','false'),('28','Toshiba Satellite L745','6B313519W','TLTD','TLTD Main','Good Condition','Laptop','false'),('29','Toshiba Satellite L745','6B333399W','TLTD','TLTD Main','Good Condition','Laptop','false'),('29','Hitachi CP-X302U','FICHO2517','TLTD','Training Room','Good Condition','DLP/LCD','false'),('3','IBM Thinkpad 1834','KV-K1583','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('3','Shure Mic. SM 58','xxx34','TLTD','Radio Booth','Endorsed to MASSCOM','Microphone','false'),('30','Toshiba Satellite L745','6B333433W','TLTD','TLTD Main','Good Condition','Laptop','false'),('31','Toshiba Satellite Pro L840','6C173477W','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('32','Toshiba Satellite Pro L840','6C173495W','TLTD','DS Sub-center','Good Condition','Laptop','false'),('32','Hitachi CP-X302U','F1JE01645','TLTD','Chapel','Good Condition','DLP/LCD','false'),('33','Toshiba Satellite Pro L840','6C173301W','TLTD','TLTD Main','Good Condition','Laptop','false'),('33','Hitachi CP-X302U','F1JE01256','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('34','Hitachi CP-X3021WN','F2BE50152','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('35','Hitachi CP-X3021WN','F2AE04192','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('36','Toshiba Satellite Pro L840','6C173665W','TLTD','TLTD Main','Good Condition','Laptop','false'),('36','Hitachi CP-X3021WN','F2AE04189','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('37','Toshiba Satellite Pro L840','4D072547C','TLTD','TLTD Main','Good Condition','Laptop','false'),('37','Hitachi CP-X3021WN','F2AE04207','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('38','Toshiba Satellite Pro L840','4D072495C','TLTD','TLTD Main','Good Condition','Laptop','false'),('38','Hitachi CP-X3021WN','F2BE50134','TLTD','LAH Sem. Rm. 1','Good Condition','DLP/LCD','false'),('39','Toshiba Satellite Pro L840','4D072548C','TLTD','TLTD Main','Good Condition','Laptop','false'),('39','Hitachi CP-X3021WN','F2AE04213','TLTD','LAH Sem. Rm. 2 & 3','Good Condition','DLP/LCD','false'),('4','DLP U5-132(plus)','UD5EA4B20791','TLTD','LAH Sub-center','Good Condition','DLP/LCD','false'),('4','Shure Mic. SM 58','xxx35','TLTD','Radio Booth','Endorsed to MASSCOM','Microphone','false'),('40','Toshiba Satellite Pro L840','4D072469C','TLTD','TLTD Main','Good Condition','Laptop','false'),('40','Hitachi CP-X3021','F2BE61516','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('41','Toshiba Satellite Pro L840','4D072577C','TLTD','TLTD Main','Good Condition','Laptop','false'),('41','Hitachi CP-X3021','F3BE61506','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('42','Toshiba Satellite Pro L840','4D072496C','TLTD','TLTD Main','Good Condition','Laptop','false'),('42','Hitachi CP-X3021','F3BE61581','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('43','Toshiba Satellite Pro L840','4D072461C','TLTD','TLTD Main','Good Condition','Laptop','false'),('43','Hitachi CP-X3021','F3BE61533','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('44','Toshiba Satellite Pro L840','4D072529C','TLTD','TLTD Main','Good Condition','Laptop','false'),('44','Hitachi CP-X4015','F21H01598','TLTD','FFH 201','Good Condition','DLP/LCD','false'),('45','Toshiba Satellite Pro L840','4D072497C','TLTD','DS Sub-center','Good Condition','Laptop','false'),('45','Epson EB-X14H434C','PTUK3600615','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('46','Toshiba Satellite Pro L840','4D072550C','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('46','Epson EB-X14H434C','PTUK3600284','TLTD','MIR','Good Condition','DLP/LCD','false'),('46','Shure Mic. SM 58','xxx36','TLTD','MIR','Good Condition','Microphone','false'),('47','Toshiba Tecra C50-B107E','9F054881H','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('47','Epson EB-X14H434C','PTUK3600677','TLTD','LA Auditorium','Good Condition','DLP/LCD','false'),('47','Shure Mic. SM 58','xxx37','TLTD','MIR','Good Condition','Microphone','false'),('48','Toshiba Tecra C50-B107E','9F054893H','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('48','Epson EB-X14H434C','PTUK3600661','TLTD','LA Auditorium','Good Condition','DLP/LCD','false'),('48','Shure Mic. SM 58','xxx38','TLTD','MIR','Good Condition','Microphone','false'),('49','Toshiba Tecra C50-B107E','9F054891H','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('49','Epson','RKFF350019L','TLTD','LA Auditorium','Good Condition','DLP/LCD','false'),('49','Shure Mic. SM 58','xxx39','TLTD','MIR','Good Condition','Microphone','false'),('50','Toshiba Tecra C50-B107E','9F054865H','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('50','Hitachi CP-X3030WN','F4EH07994','TLTD','SDV Conference','Good Condition','DLP/LCD','false'),('50','Shure Mic. SM 58','xxx40','TLTD','LA Auditorium','Good Condition','Microphone','false'),('51','Toshiba Tecra C50-B107E','9F054867H','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('51','Hitachi CP-X3030WN','F4EH08001','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('51','Mic. Dynamic Super cardiod lead vocal ','xxx41','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('52','Toshiba Tecra C50-B107E','9F054858H','TLTD','LAH Sub-center','Good Condition','Laptop','false'),('52','Mic. Dynamic Super cardiod lead vocal ','xxx42','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('52','Hitachi CP-X3030WN','xxx71','TLTD','LA Auditorium','Good Condition','DLP/LCD','false'),('53','Toshiba Tecra C50-B107E','9F054857H','TLTD','DS Sub-center','Good Condition','Laptop','false'),('53','Hitachi CP-X3030WN','F4EH08007','TLTD','LAH Sub-center','Good Condition','DLP/LCD','false'),('53','Mic. Dynamic Super cardiod lead vocal ','xxx43','TLTD','FFH 201','Good Condition','Microphone','false'),('54','Toshiba Tecra C50-B107E','9F054844H','TLTD','DS Sub-center','Good Condition','Laptop','false'),('54','Hitachi CP-X3030WN','F4EH08019','TLTD','LAH Sub-center','Good Condition','DLP/LCD','false'),('54','Mic. Dynamic Super cardiod lead vocal ','xxx44','TLTD','FFH 201','Good Condition','Microphone','false'),('55','Toshiba Tecra C50-B107E','9F054869H','TLTD','DS Sub-center','Good Condition','Laptop','false'),('55','Hitachi CP-X3030WN','F4EH08020','TLTD','LAH Sub-center','Good Condition','DLP/LCD','false'),('55','Mic. Dynamic Super cardiod lead vocal ','xxx45','TLTD','FFH 201','Good Condition','Microphone','false'),('56','Toshiba Tecra C50-B107E','9F054866H','TLTD','DS Sub-center','Good Condition','Laptop','false'),('56','Hitachi CP-X3030WN','F4EH08260','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('56','Mic. EV PL 24','xxx46','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('57','Toshiba Tecra C50-B107E','9F054868H','TLTD','DS Sub-center','Good Condition','Laptop','false'),('57','Hitachi CP-X3030WN','F4EH08259','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('57','Mic. EV PL 24','xxx47','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('58','Toshiba Tecra C50-B107E','9F054840H','TLTD','DS Sub-center','Good Condition','Laptop','false'),('58','Hitachi CP-X3030WN','F4EH08014','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('58','Mic. EV PL 24','xxx48','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('59','Toshiba Tecra C50-B107E','9F054862H','TLTD','TLTD Main','Good Condition','Laptop','false'),('59','Hitachi CP-X 4030','F4HH00101','TLTD','FFH 201','Good Condition','DLP/LCD','false'),('59','Mic. EV PL 24','xxx49','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('6','DLP U5-632H (plus)','U5GEA6220520','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('60','Toshiba Tecra C50-B107E','9F054880H','TLTD','TLTD Main','Good Condition','Laptop','false'),('60','Hitachi CP-X 3041 WN','F5FH00474','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('60','Mic. EV PL 24','xxx50','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('61','Toshiba Tecra C50-B107E','9F054879H','TLTD','TLTD Main','Good Condition','Laptop','false'),('61','Hitachi CP-X 3041 WN','F5FH00307','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('61','Mic. EV PL 24','xxx51','TLTD','L.A Auditorium','Good Condition','Microphone','false'),('62','Toshiba Tecra C50-B107E','9F054851H','TLTD','TLTD Main','Good Condition','Laptop','false'),('62','Hitachi CP-X 3041 WN','F5FH00476','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('62','Mic. EV PL 24','xxx52','TLTD','FFH 201','Good Condition','Microphone','false'),('63','Toshiba Tecra C50-B107E','9F054859H','TLTD','TLTD Main','Good Condition','Laptop','false'),('63','Hitachi CP-X 3041 WN','F5FH00298','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('63','Mic. EV PL 24','xxx53','TLTD','FFH 201','Good Condition','Microphone','false'),('64','Toshiba Tecra C50-B107E','9F054915H','TLTD','TLTD Main','Good Condition','Laptop','false'),('64','Hitachi CP-X 3041 WN','F5FH00296','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('64','Mic. EV PL 24','xxx54','TLTD','FFH 202','Good Condition','Microphone','false'),('65','Toshiba Tecra C50-B107E','9F054914H','TLTD','TLTD Main','Good Condition','Laptop','false'),('65','Hitachi CP-X 3041 WN','F5FH0081','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('65','Mic. EV PL 24','xxx55','TLTD','FFH 203','Good Condition','Microphone','false'),('66','Toshiba Tecra C50-B107E','9F054873H','TLTD','TLTD Main','Good Condition','Laptop','false'),('66','Hitachi CP-X 3041 WN','F5FH00487','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD','false'),('66','Sennheiser E 385S','xxx56','TLTD','MIR','Good Condition','Microphone','false'),('67','Toshiba Tecra C50-B107E','9F054894H','TLTD','TLTD Main','Good Condition','Laptop','false'),('67','Hitachi CP-X 3041 WN','F5FH00306','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD','false'),('67','Sennheiser E 385S','xxx57','TLTD','MIR','Good Condition','Microphone','false'),('68','Toshiba Tecra C50-B107E','9F054898H','TLTD','TLTD Main','Good Condition','Laptop','false'),('68','Hitachi CP-X 3041 WN','F5FH0080','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD','false'),('68','Sennheiser E 385S','xxx58','TLTD','MIR','Good Condition','Microphone','false'),('69','Toshiba Tecra C50-B107E','9F054870H','TLTD','TLTD Main','Good Condition','Laptop','false'),('69','Hitachi CP-X 3041 WN','F5FH00301','TLTD','TLTD LAH sub-center','Good Condition','DLP/LCD','false'),('69','Sennheiser E 385S','xxx59','TLTD','MIR','Good Condition','Microphone','false'),('7','DLP U5-632H (plus)','U5GEA5620825','TLTD','DS sub-center','Good Condition','DLP/LCD','false'),('70','Toshiba Tecra C50-B107E','9F054895H','TLTD','TLTD Main','Good Condition','Laptop','false'),('70','Hitachi CP-X 3041 WN','F5FH00302','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD','false'),('70','Sennheiser E 385S','xxx60','TLTD','MIR','Good Condition','Microphone','false'),('71','Hitachi CP-X 3041 WN','F5FH00300','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD','false'),('71','Sennheiser E 385S','xxx61','TLTD','MIR','Good Condition','Microphone','false'),('72','Hitachi CP-X 3041 WN','F5FH00475','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD','false'),('72','Shure SM 58','xxx62','TLTD','LA Auditorium','Good Condition','Microphone','false'),('73','Hitachi CP-X 3041 WN','F5FH00486','TLTD','TLTD DS sub-center','Good Condition','DLP/LCD','false'),('73','Shure SM 58','xxx63','TLTD','LA Auditorium','Good Condition','Microphone','false'),('74','Shure SM 58','xxx64','TLTD','LA Auditorium','Good Condition','Microphone','false'),('75','Shure SM 58','xxx65','TLTD','LA Auditorium','Good Condition','Microphone','false'),('76','Shure SM 58','xxx66','TLTD','LA Auditorium','Good Condition','Microphone','false'),('9','DLP EX100U','7749','TLTD','TLTD Main','Good Condition','DLP/LCD','false'),('Bardl Mic 01','Bardl Sf 22 600-2','xxx01','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 02','Bardl Sf 22 600-2','xxx02','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 03','Bardl Sf 22 600-2','xxx03','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 04','Bardl Sf 22 600-2','xxx04','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 05','Bardl Sf 22 600-2','xxx05','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 06','Bardl Sf 22 600-2','xxx06','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 07','Bardl Sf 22 600-2','xxx07','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 08','Bardl Sf 22 600-2','xxx08','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 09','Bardl Sf 22 600-2','xxx09','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 10','Bardl Sf 22 600-2','xxx10','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 11','Bardl Sf 22 600-2','xxx11','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 12','Bardl Sf 22 600-2','xxx12','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 13','Bardl Sf 22 600-2','xxx13','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 14','Bardl Sf 22 600-2','xxx14','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 15','Bardl Sf 22 600-2','xxx15','TLTD','TLT Main','Good Condition','Microphone','false'),('Bardl Mic 16','Bardl Sf 22 600-2','xxx16','TLTD','SDV Conference','Good Condition','Microphone','false'),('Bardl Mic 17','Bardl Sf 22 600-2','xxx17','TLTD','SDV Conference','Good Condition','Microphone','false'),('Bardl Mic 18','Bardl Sf 22 600-2','xxx18','TLTD','SDV Conference','Good Condition','Microphone','false'),('Bardl Mic 19','Bardl Sf 22 600-2','xxx19','TLTD','SDV Conference','Good Condition','Microphone','false'),('Bardl Mic 20','Bardl Sf 22 600-2','xxx20','TLTD','LAH Sub-center','Good Condition','Microphone','false'),('Bardl Mic 21','Bardl Sf 22 600-2','xxx21','TLTD','LAH Sub-center','Good Condition','Microphone','false'),('Bardl Mic 22','Bardl Sf 22 600-2','xxx22','TLTD','LAH Sub-center','Good Condition','Microphone','false'),('Bardl Mic 23','Bardl Sf 22 600-2','xxx23','TLTD','Dent. Sci Sub-center','Good Condition','Microphone','false'),('Bardl Mic 24','Bardl Sf 22 600-2','xxx24','TLTD','Dent. Sci Sub-center','Good Condition','Microphone','false'),('Bardl Mic 25','Bardl Sf 22 600-2','xxx25','TLTD','Dent. Sci Sub-center','Good Condition','Microphone','false'),('Bardl Mic 26','Bardl Sf 22 600-2','xxx26','TLTD','Dent. Sci Sub-center','Good Condition','Microphone','false'),('Bardl Mic 27','Bardl Sf 22 600-3','xxx27','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone','false'),('Bardl Mic 28','Bardl Sf 22 600-4','xxx28','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone','false'),('Bardl Mic 29','Bardl Sf 22 600-5','xxx29','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone','false'),('Bardl Mic 30','Bardl Sf 22 600-6','xxx30','TLTD','LAH Sem. Rm. 2&3','Good Condition','Microphone','false'),('DLP #01','Hitachi CP-X3021WN','FILE03017','SNHM','TLT Main','Good condition','DLP/LCD','false'),('DLP #01','Plus-U2-132','HD5EA4B0788','Nursing','TLT Main','Good Condition','DLP/LCD','false'),('DLP #01','Taxan-U6-112','NA6EA6C20712','IDL','TLT Main','Good Condition ','DLP/LCD','false'),('DLP #02','Mitsubishi XD 510U','7514','MEDTECH','MT Dean\'s Office','Good Condition','DLP/LCD','false'),('DLP #02','Taxan-U6-112','NA6EA6C22004','IDL','TLT Main','Good Condition ','DLP/LCD','false'),('DLP #03','XD510U','5375','SNHM','DS sub-center','Good condition','DLP/LCD','false'),('DLP #03','Plus-U5-632H','S5CEA6820658','Nursing','Nursing Dean\'s Office','Good Condition','DLP/LCD','false'),('DLP #04','XD510U','7517','SNHM','DS sub-center','Good condition','DLP/LCD','false'),('DLP #04','Plus-U5-632H','S5AEA6921089','Nursing','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #05','XD280U','3005005','SNHM','DS sub-center','Good condition','DLP/LCD','false'),('DLP #05','Mitsubishi EX100U','7889','Nursing','TLT Main','Good Condition','DLP/LCD','false'),('DLP #06','Hitachi CP-X3021WN','F5FH00450','TLTD','TLT Main','Good condition','DLP/LCD','false'),('DLP #06','Premiere PD-S611','P41PILA06179000716','Nursing','TLT Main','Good Condition','DLP/LCD','false'),('DLP #07','Hitachi CP-X3021WN','F5FH00100','TLTD','TLT Main','Good condition','DLP/LCD','false'),('DLP #07','Taxan KG-PS100S','PSCAA7421096','Nursing','LAH Sub-center','Good Condition','DLP/LCD','false'),('DLP #08','Hitachi CP-X3021WN','F5FH00445','TLTD','TLT Main','Good condition','DLP/LCD','false'),('DLP #08','Taxan KG-PS100S','PSCAA7321219','Nursing','LAH Sub-center','Good Condition','DLP/LCD','false'),('DLP #10','Mitsubishi EX100U','8579','Nursing','GDL 202','Good Condition','DLP/LCD','false'),('DLP #10','Panasoniv/PT-LB75EA','SD8350214','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #11','Panasoniv/PT-LB75EA','SC8350356','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #12','Panasoniv/PT-LB75EA','SC8350188','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #13','Panasoniv/PT-LB75EA','SC8350186','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #14','Panasoniv/PT-LB75EA','SC8350185','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #15','Hitachi CP-X 3041 Wn','F5FH00440','TLTD','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #15','Panasonic PTLB75EA','SD8530170','Nursing','LAH Sub-center','Good Condition','DLP/LCD','false'),('DLP #16','Hitachi CP-X 3041 Wn','F5FH00308','TLTD','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #16','Panasonic PTLB75EA','SC8350183','Nursing','LAH Sub-center','Good Condition','DLP/LCD','false'),('DLP #17','Hitachi CP-X 3041 Wn','F5FH00451','TLTD','TLT Main','Good Condition','DLP/LCD','false'),('DLP #17','Hitachi CP-X 3041 Wn','F5FH0079','TLTD','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #18','Hitachi CP-X 3041 Wn','F5FH00488','TLTD','TLT Main','Good Condition','DLP/LCD','false'),('DLP #19','Hitachi CP-X 3041 Wn','F5FH00444','TLTD','TLT Main','Good Condition','DLP/LCD','false'),('DLP #20','Hitachi CP-X 3041 Wn','F5FH00452','TLTD','TLT Main','Good Condition','DLP/LCD','false'),('DLP #21','Hitachi CP-X 3041 Wn','F5FH00452','TLTD','TLT Main','Good Condition','DLP/LCD','false'),('DLP #5','Taxan-KG-PS1000S','PSCAA7520743','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #6','Hitachi CP-X 3041','F5FH00481','TLTD','LAH sub-center','Good Condition','DLP/LCD','false'),('DLP #6','Taxan-KG-PS1000S','PSCAA7520571','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #7','Hitachi CP-X 3041','F5FH00486','TLTD','LAH sub-center','Good Condition','DLP/LCD','false'),('DLP #7','Taxan-KG-PS1000S','PSCAA7421647','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #8','Hitachi CP-X 3041','F5FH00482','TLTD','LAH sub-center','Good Condition','DLP/LCD','false'),('DLP #8','Taxan-KG-PS120X','PSBAA7A20518','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('DLP #9','Taxan-KG-PS120X','PSBAA7A20533','Dentistry','DS Sub-center','Good Condition','DLP/LCD','false'),('KP #01','HR A290','658705','IDL','IDL Office','Good Condition ','Karaoke','false'),('KP #02','HR A290','658733','IDL','IDL Office','Good Condition ','Karaoke','false'),('KP #03','HR A290','658740','IDL','IDL Office','Good Condition ','Karaoke','false'),('KP #04','HR A290','658738','IDL','IDL Office','Good Condition ','Karaoke','false'),('KP #05','HR A290','658739','IDL','LAH Sub-center','Good Condition ','Karaoke','false'),('KP #06','HR A290','658706','IDL','LAH Sub-center','Good Condition ','Karaoke','false'),('KP #07','HR A290','658728','IDL','LAH Sub-center','Good Condition ','Karaoke','false'),('KP #08','HR A290','658735','IDL','TLT Main','Good Condition ','Karaoke','false'),('KP #09','HR A290','658704','IDL','TLT Main','Good Condition ','Karaoke','false'),('KP #10','HR A290','658734','IDL','TLT Main','Good Condition ','Karaoke','false'),('LCD #02','Hitachi CP-X3021WN','FILE02409','SNHM','TLT Main','Good condition','DLP/LCD','false'),('OHP #01','3M 1608','168501','IDL','SDV 501','Good Condition ','Overhead Projector','false'),('OHP #02','3M 1608','168459','IDL','SDV 502','Good Condition ','Overhead Projector','false'),('OHP #03','3M 1608','','IDL','SDV 503','Good Condition ','Overhead Projector','false'),('OHP #04','3M 1608','','IDL','SDV 504','Good Condition ','Overhead Projector','false'),('OHP #05','3M 1608','168450','IDL','SDV 505','Good Condition ','Overhead Projector','false'),('PCS-01','Altec Lansing 2420','xxx84','TLTD ','TLT Main','Good Condition','PC Speakers','false'),('PCS-02','Altec Lansing 2420','xxx85','TLTD ','LAH sub-center','Good Condition','PC Speakers','false'),('PCS-03','Altec Lansing 2420','xxx86','TLTD ','DS Sub-center','Good Condition','PC Speakers','false'),('PCS-04','Altec Lansing 2620','FDEU00056539','TLTD ','DS Sub-center','Good Condition','PC Speakers','false'),('PCS-05','Altec Lansing 2621','FDEU0005640','TLTD ','DS Sub-center','Good Condition','PC Speakers','false'),('PCS-06','Altec Lansing 2622','FDEU0005641','TLTD ','DS Sub-center','Good Condition','PC Speakers','false'),('PCS-07','Altec Lansing  ','xxx72','TLTD ','TLTD Main','Good Condition','PC Speakers','false'),('PCS-08','Altec Lansing ','xxx73','TLTD ','TLTD Main','Good Condition','PC Speakers','false'),('PCS-09','Altec Lansing ','xxx74','TLTD ','TLTD Main','Good Condition','PC Speakers','false'),('PCS-10','Altec Lansing ','xxx75','TLTD ','TLTD Main','Good Condition','PC Speakers','false'),('PCS-11 ','Altec Lansing ','xxx76','TLTD ','TLTD Main','Good Condition','PC Speakers','false'),('PCS-12','Altec Lansing ','xxx77','TLTD ','TLTD Main','Good Condition','PC Speakers','false'),('PCS-13','Altec Lansing BXR 1321','xxx78','TLTD ','DS Sub-center','Good Condition','PC Speakers','false'),('PCS-14','Altec Lansing BXR 1322','xxx79','TLTD ','DS Sub-center','Good Condition','PC Speakers','false'),('PCS-15','Altec Lansing BXR 1323','xxx80','TLTD ','DS Sub-center','Good Condition','PC Speakers','false'),('PCS-16','Altec Lansing BXR 1324','xxx81','TLTD ','LAH sub-center','Good Condition','PC Speakers','false'),('PCS-17','Altec Lansing BXR 1325','xxx82','TLTD ','LAH sub-center','Good Condition','PC Speakers','false'),('PCS-18','Altec Lansing BXR 1326','xxx83','TLTD ','LAH sub-center','Good Condition','PC Speakers','false'),('Speaker #1,2','Nomad 70 watts','xxx66','IDL','SDV 501','Good Condition ','Speaker','false'),('Speaker #3,4','Nomad 70 watts','xxx67','IDL','SDV 502','Good Condition ','Speaker','false'),('Speaker #5,6','Nomad 70 watts','xxx68','IDL','SDV 503','Good Condition ','Speaker','false'),('Speaker #7,8','Nomad 70 watts','xxx69','IDL','SDV 504','Good Condition ','Speaker','false'),('Speaker #9,10','Nomad 70 watts','xxx70','IDL','SDV 505','Good Condition ','Speaker','false'),('TD #01','DENNON DRW 585','2117608360','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #03','DENNON DRW 587','2117608391','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #04','DENNON DRW 588','2117608220','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #05','DENNON DRW 589','2117608382','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #06','DENNON DRW 590','2117608364','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #07','DENNON DRW 591','2117608333','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #08','DENNON DRW 592','2117608375','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #09','DENNON DRW 593','2117608390','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #10','DENNON DRW 594','2117608388','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #11','DENNON DRW 595','2117608322','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #12','DENNON DRW 596','2117608361','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #13','DENNON DRW 597','2117608386','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #14','DENNON DRW 598','2117608362','IDL','FFH 201','Good Condition ','Tape Deck','false'),('TD #15','DENNON DRW 599','2117608318','IDL','FFH 201','Good Condition ','Tape Deck','false'),('VHSP #01','HR-J791AM','098Q0844','IDL','FFH 201','Good Condition ','VHS Player','false'),('VHSP #02','HR-J791AM','108Q0094','IDL','FFH 202','Good Condition ','VHS Player','false'),('VHSP #03','HR-J791AM','098Q0902','IDL','FFH 203','Good Condition ','VHS Player','false'),('VHSP #04','HR-J791AM','098Q0875','IDL','FFH 204','Good Condition ','VHS Player','false'),('VHSP #05','HR-J791AM','098Q0851','IDL','FFH 205','Good Condition ','VHS Player','false');
/*!40000 ALTER TABLE `equipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prof_reg`
--

DROP TABLE IF EXISTS `prof_reg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `prof_reg` (
  `prof_id` int(11) NOT NULL,
  `prof_fname` varchar(45) DEFAULT NULL,
  `prof_mname` varchar(45) DEFAULT NULL,
  `prof_surname` varchar(45) DEFAULT NULL,
  `prof_college` varchar(45) DEFAULT NULL,
  `prof_type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`prof_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prof_reg`
--

LOCK TABLES `prof_reg` WRITE;
/*!40000 ALTER TABLE `prof_reg` DISABLE KEYS */;
/*!40000 ALTER TABLE `prof_reg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `released_info`
--

DROP TABLE IF EXISTS `released_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `released_info` (
  `rel_idnum` varchar(45) NOT NULL,
  `rel_borrower` varchar(200) NOT NULL,
  `rel_type` varchar(45) NOT NULL,
  `rel_startdate` date NOT NULL,
  `rel_enddate` date NOT NULL,
  `rel_starttime` time NOT NULL,
  `rel_endtime` time NOT NULL,
  `rel_college` varchar(45) NOT NULL,
  `rel_location` varchar(200) NOT NULL,
  `rel_status` varchar(45) NOT NULL,
  `rel_releasedby` varchar(100) NOT NULL,
  `rel_equipment` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `released_info`
--

LOCK TABLES `released_info` WRITE;
/*!40000 ALTER TABLE `released_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `released_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `releasing`
--

DROP TABLE IF EXISTS `releasing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `releasing` (
  `startdate` date NOT NULL,
  `enddate` date NOT NULL,
  `starttime` time NOT NULL,
  `endtime` time NOT NULL,
  `borrower` varchar(200) NOT NULL,
  `location` varchar(200) NOT NULL,
  `equipment` varchar(100) NOT NULL,
  `releasedby` varchar(100) NOT NULL,
  `status` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `releasing`
--

LOCK TABLES `releasing` WRITE;
/*!40000 ALTER TABLE `releasing` DISABLE KEYS */;
/*!40000 ALTER TABLE `releasing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservation` (
  `startdate` date NOT NULL,
  `enddate` date NOT NULL,
  `starttime` time NOT NULL,
  `endtime` time NOT NULL,
  `borrower` varchar(200) NOT NULL,
  `location` varchar(200) NOT NULL,
  `reservedby` varchar(100) NOT NULL,
  `status` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservation`
--

LOCK TABLES `reservation` WRITE;
/*!40000 ALTER TABLE `reservation` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservation_equipment`
--

DROP TABLE IF EXISTS `reservation_equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservation_equipment` (
  `equipmentsn` varchar(50) DEFAULT NULL,
  `equipmentno` varchar(20) DEFAULT NULL,
  `equipment` varchar(100) DEFAULT NULL,
  `equipmenttype` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservation_equipment`
--

LOCK TABLES `reservation_equipment` WRITE;
/*!40000 ALTER TABLE `reservation_equipment` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservation_equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `returned_info`
--

DROP TABLE IF EXISTS `returned_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `returned_info` (
  `ret_idnum` varchar(45) NOT NULL,
  `ret_borrower` varchar(45) NOT NULL,
  `ret_type` varchar(200) NOT NULL,
  `ret_startdate` date NOT NULL,
  `ret_enddate` date NOT NULL,
  `ret_starttime` time NOT NULL,
  `ret_endtime` time NOT NULL,
  `ret_college` varchar(45) NOT NULL,
  `ret_location` varchar(200) NOT NULL,
  `ret_status` varchar(45) NOT NULL,
  `ret_releasedby` varchar(100) NOT NULL,
  `ret_equipment` varchar(100) NOT NULL,
  `ret_returnedto` varchar(100) NOT NULL
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
  `staff_id` int(11) NOT NULL,
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
INSERT INTO `staff_reg` VALUES (1105234,'Brenz','Villanueva','Buenaventura','Staff','developer','7fcf4ba391c48784edde599889d6e3f1e47a27db36ecc050cc92f259bfac38afad2c68a1ae804d77075e8fb722503f3eca2b2c1006ee6f6c7b7628cb45fffd1d'),(1105345,'Red','Blue','Violet','Staff','red123','b4369e53d1c8bcde9cda3e54e6aca65607c3e43bb0f61630c598b5dbc49d49ff37597958d3032a5e2022f4b36e03160450ff046399443f900a9e7e482cd8a0e0'),(1302321,'Christian','Reyes','Umali','Staff','admin','c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec');
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

-- Dump completed on 2016-08-22  9:31:36
