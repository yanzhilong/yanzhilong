-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: yanzhilong
-- ------------------------------------------------------
-- Server version	5.7.17

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
-- Table structure for table `article`
--

DROP TABLE IF EXISTS `article`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `article` (
  `ArticleID` char(36) NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Content` mediumtext,
  `ImageUrl` varchar(255) DEFAULT NULL,
  `Disc` varchar(255) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `CreateAt` datetime NOT NULL,
  `UpdateAt` datetime DEFAULT NULL,
  `CategoryId` char(36) NOT NULL,
  `UserId` char(36) NOT NULL,
  PRIMARY KEY (`ArticleID`),
  KEY `User_ID_idx` (`UserId`),
  KEY `FK_ARTICLE_Category_ID_idx` (`CategoryId`),
  CONSTRAINT `FK_ARTICLE_Category_ID` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`CategoryID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ARTICLE_User_ID` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `CategoryID` char(36) NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`CategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `note`
--

DROP TABLE IF EXISTS `note`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `note` (
  `NoteID` char(36) NOT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Content` mediumtext,
  `CreateAt` datetime DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL,
  PRIMARY KEY (`NoteID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pageviewcount`
--

DROP TABLE IF EXISTS `pageviewcount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pageviewcount` (
  `PageViewCountID` char(36) NOT NULL,
  `ResourceID` char(36) DEFAULT NULL,
  `Count` int(11) DEFAULT NULL,
  PRIMARY KEY (`PageViewCountID`),
  UNIQUE KEY `ResourceID_UNIQUE` (`ResourceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `ProductID` char(36) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Content` mediumtext,
  `Version` varchar(10) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `ImageUrl` varchar(255) DEFAULT NULL,
  `Disc` varchar(255) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `CreateAt` datetime NOT NULL,
  PRIMARY KEY (`ProductID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `resourcestar`
--

DROP TABLE IF EXISTS `resourcestar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `resourcestar` (
  `ResourceStarID` char(36) NOT NULL,
  `ResourceID` char(36) NOT NULL,
  `ResourceType` int(11) NOT NULL,
  PRIMARY KEY (`ResourceStarID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='存储需要在首页推荐的文章，教程，产品';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tutorials`
--

DROP TABLE IF EXISTS `tutorials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tutorials` (
  `TutorialsID` char(36) NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Content` mediumtext,
  `ImageUrl` varchar(255) DEFAULT NULL,
  `Disc` varchar(255) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `CreateAt` datetime NOT NULL,
  `UpdateAt` datetime DEFAULT NULL,
  `UserId` char(36) NOT NULL,
  PRIMARY KEY (`TutorialsID`),
  KEY `FK_TUTORIALS_User_ID_idx` (`UserId`),
  CONSTRAINT `FK_TUTORIALS_User_ID` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `UserID` char(36) NOT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `DisplayName` varchar(45) DEFAULT NULL,
  `PasswordHash` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `MobilePhone` varchar(45) DEFAULT NULL,
  `CreateAt` datetime NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-07 16:37:42
