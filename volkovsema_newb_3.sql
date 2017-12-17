-- phpMyAdmin SQL Dump
-- version 4.0.10deb1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 17, 2017 at 06:03 PM
-- Server version: 5.5.53-0ubuntu0.14.04.1
-- PHP Version: 5.5.9-1ubuntu4.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `volkovsema_newb`
--

-- --------------------------------------------------------

--
-- Table structure for table `Competition`
--

CREATE TABLE IF NOT EXISTS `Competition` (
  `Date` varchar(12) NOT NULL,
  `Name` text NOT NULL,
  `Location` varchar(50) DEFAULT NULL,
  `Intl` tinyint(1) NOT NULL,
  KEY `Date` (`Date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `info`
--

CREATE TABLE IF NOT EXISTS `info` (
  `date` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `jo`
--

CREATE TABLE IF NOT EXISTS `jo` (
  `Number` int(10) unsigned NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) unsigned NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `Region` varchar(12) NOT NULL,
  `Rating` int(10) unsigned NOT NULL,
  `Change` varchar(1) DEFAULT NULL,
  `Personal` int(10) unsigned NOT NULL,
  `Team` int(10) unsigned NOT NULL,
  `hash` varchar(32) NOT NULL,
  KEY `hash` (`hash`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `jo_participated`
--

CREATE TABLE IF NOT EXISTS `jo_participated` (
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `hash` varchar(32) NOT NULL,
  `date` varchar(12) NOT NULL,
  `points` int(11) NOT NULL,
  `included` varchar(100) NOT NULL,
  KEY `hash` (`hash`),
  KEY `date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `jp`
--

CREATE TABLE IF NOT EXISTS `jp` (
  `Number` int(10) unsigned NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) unsigned NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `Region` varchar(12) NOT NULL,
  `Rating` int(10) unsigned NOT NULL,
  `Change` varchar(1) DEFAULT NULL,
  `Personal` int(10) unsigned NOT NULL,
  `Team` int(10) unsigned NOT NULL,
  `hash` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `jp_participated`
--

CREATE TABLE IF NOT EXISTS `jp_participated` (
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `hash` varchar(32) NOT NULL,
  `date` varchar(12) NOT NULL,
  `points` int(11) NOT NULL,
  `included` varchar(100) NOT NULL,
  KEY `hash` (`hash`),
  KEY `date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `js`
--

CREATE TABLE IF NOT EXISTS `js` (
  `Number` int(10) unsigned NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) unsigned NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `Region` varchar(12) NOT NULL,
  `Rating` int(10) unsigned NOT NULL,
  `Change` varchar(1) DEFAULT NULL,
  `Personal` int(10) unsigned NOT NULL,
  `Team` int(10) unsigned NOT NULL,
  `hash` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `js_participated`
--

CREATE TABLE IF NOT EXISTS `js_participated` (
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `hash` varchar(32) NOT NULL,
  `date` varchar(12) NOT NULL,
  `points` int(11) NOT NULL,
  `included` varchar(100) NOT NULL,
  KEY `hash` (`hash`),
  KEY `date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mo`
--

CREATE TABLE IF NOT EXISTS `mo` (
  `Number` int(10) unsigned NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) unsigned NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `Region` varchar(12) NOT NULL,
  `Rating` int(10) unsigned NOT NULL,
  `Change` varchar(1) DEFAULT NULL,
  `Personal` int(10) unsigned NOT NULL,
  `Team` int(10) unsigned NOT NULL,
  `hash` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mo_participated`
--

CREATE TABLE IF NOT EXISTS `mo_participated` (
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `hash` varchar(32) NOT NULL,
  `date` varchar(12) NOT NULL,
  `points` int(11) NOT NULL,
  `included` varchar(100) NOT NULL,
  KEY `hash` (`hash`),
  KEY `date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mp`
--

CREATE TABLE IF NOT EXISTS `mp` (
  `Number` int(10) unsigned NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) unsigned NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `Region` varchar(12) NOT NULL,
  `Rating` int(10) unsigned NOT NULL,
  `Change` varchar(1) DEFAULT NULL,
  `Personal` int(10) unsigned NOT NULL,
  `Team` int(10) unsigned NOT NULL,
  `hash` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mp_participated`
--

CREATE TABLE IF NOT EXISTS `mp_participated` (
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `hash` varchar(32) NOT NULL,
  `date` varchar(12) NOT NULL,
  `points` int(11) NOT NULL,
  `included` varchar(100) NOT NULL,
  KEY `hash` (`hash`),
  KEY `date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `ms`
--

CREATE TABLE IF NOT EXISTS `ms` (
  `Number` int(10) unsigned NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) unsigned NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `Region` varchar(12) NOT NULL,
  `Rating` int(10) unsigned NOT NULL,
  `Change` varchar(1) DEFAULT NULL,
  `Personal` int(10) unsigned NOT NULL,
  `Team` int(10) unsigned NOT NULL,
  `hash` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `ms_participated`
--

CREATE TABLE IF NOT EXISTS `ms_participated` (
  `Name` varchar(50) NOT NULL,
  `BirthYear` int(10) NOT NULL,
  `Qualification` varchar(10) NOT NULL,
  `hash` varchar(32) NOT NULL,
  `date` varchar(12) NOT NULL,
  `points` int(11) NOT NULL,
  `included` varchar(100) NOT NULL,
  KEY `hash` (`hash`),
  KEY `date` (`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE IF NOT EXISTS `posts` (
  `author` varchar(50) NOT NULL,
  `date` datetime NOT NULL,
  `heading` varchar(100) NOT NULL,
  `text` text NOT NULL,
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=46 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
