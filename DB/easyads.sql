-- MySQL dump 10.13  Distrib 5.5.17, for Win32 (x86)
--
-- Host: localhost    Database: easyads
-- ------------------------------------------------------
-- Server version	5.5.17

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
-- Table structure for table `platforminfo`
--

DROP TABLE IF EXISTS `platforminfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `platforminfo` (
  `SessionKey` varchar(128) NOT NULL,
  `Refresh_token` varchar(128) NOT NULL,
  `Nick` varchar(64) NOT NULL,
  `PlatformUserId` varchar(32) NOT NULL,
  `Platform` int(10) unsigned NOT NULL,
  `ExpireDate` datetime NOT NULL,
  `AuthDate` datetime NOT NULL,
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`,`UserId`),
  KEY `UserId_idx` (`UserId`),
  CONSTRAINT `PK_UserId` FOREIGN KEY (`UserId`) REFERENCES `userinfo` (`UserId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=gbk;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `platforminfo`
--

LOCK TABLES `platforminfo` WRITE;
/*!40000 ALTER TABLE `platforminfo` DISABLE KEYS */;
INSERT INTO `platforminfo` VALUES ('2.00BieeRDPMcUFB1e4258d2be179OCD','','五环外外地人','3009285817',1,'2013-07-30 06:45:21','2013-07-28 10:57:20',1,8);
/*!40000 ALTER TABLE `platforminfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userinfo`
--

DROP TABLE IF EXISTS `userinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userinfo` (
  `UserId` int(10) unsigned NOT NULL DEFAULT '0',
  `TB_UserId` varchar(64) NOT NULL,
  `AccessToken` varchar(128) NOT NULL,
  `RefreshToken` varchar(128) NOT NULL,
  `Nick` varchar(64) CHARACTER SET gbk COLLATE gbk_bin NOT NULL,
  `LastLogin` datetime NOT NULL,
  `ExpireTime` datetime NOT NULL,
  `AuthDate` datetime NOT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=gbk;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userinfo`
--

LOCK TABLES `userinfo` WRITE;
/*!40000 ALTER TABLE `userinfo` DISABLE KEYS */;
INSERT INTO `userinfo` VALUES (6,'3598702902','6101925c77e6ac6b8ddaa3606de6fd7d21401fc18e51eb43598702902','6101925c77e6ac6b8ddaa3606de6fd7d21401fc18e51eb43598702902','sandbox_cabbage200','2013-07-19 00:52:45','2013-07-20 00:52:46','2013-07-19 00:52:46'),(7,'70005592','62010152767e4506be26edace1e314480684a643648a3f070005592','620021582348f90983fe2cdfhca966dae7b5367e6c4e28170005592','cabbage200','2013-07-19 00:54:59','2013-07-20 00:56:15','2013-07-19 00:54:53'),(8,'64352291','6201413e4271dc056b658ZZ6553fefebc31553437ddc28264352291','6200713a4781912b420a8ZZec5c691d136b8fdfbeddbce764352291','jxzly229190','2013-07-28 10:55:34','2013-07-29 10:55:34','2013-07-28 10:55:34');
/*!40000 ALTER TABLE `userinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'easyads'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-28 11:18:22
