-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 18. Feb 2020 um 18:35
-- Server-Version: 10.1.32-MariaDB
-- PHP-Version: 7.2.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `democar`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `cars`
--

CREATE TABLE `cars` (
  `ID` int(11) NOT NULL,
  `Brand` text COLLATE latin1_general_cs NOT NULL,
  `Chassis_Number` int(11) NOT NULL,
  `Level` int(11) NOT NULL,
  `Lot` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_cs;

--
-- Daten für Tabelle `cars`
--

INSERT INTO `cars` (`ID`, `Brand`, `Chassis_Number`, `Level`, `Lot`) VALUES
(2, 'Mazda', 123, 0, 0),
(3, 'VW', 1234, 0, 1),
(4, 'BMW', 2345, 0, 3),
(5, 'Tesla', 3456, 0, 5),
(6, 'Audi', 4567, 0, 6),
(7, 'Horch', 5678, 0, 7),
(8, 'Opel', 6789, 1, 1),
(9, 'Jaguar', 7890, 1, 2),
(10, 'Fiat', 8901, 1, 5),
(11, 'Volvo', 9012, 1, 9),
(12, 'Ford', 9876, 2, 5),
(13, 'Skoda', 8765, 2, 8),
(14, 'Seat', 7654, 2, 9),
(15, 'DeLorean', 7895, 1, 7);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `cars`
--
ALTER TABLE `cars`
  ADD UNIQUE KEY `ID` (`ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `cars`
--
ALTER TABLE `cars`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
