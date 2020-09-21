-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 10, 2020 at 01:39 PM
-- Server version: 10.1.35-MariaDB
-- PHP Version: 7.2.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `travelia`
--

-- --------------------------------------------------------

--
-- Table structure for table `bookinginfo`
--

CREATE TABLE `bookinginfo` (
  `id` int(20) NOT NULL,
  `travellermail` varchar(50) DEFAULT NULL,
  `hotelempmail` varchar(50) DEFAULT NULL,
  `hotelname` varchar(50) DEFAULT NULL,
  `checkin` varchar(100) DEFAULT NULL,
  `checkout` varchar(100) DEFAULT NULL,
  `days` varchar(20) DEFAULT NULL,
  `roomtype` varchar(200) DEFAULT NULL,
  `totalcost` varchar(50) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bookinginfo`
--

INSERT INTO `bookinginfo` (`id`, `travellermail`, `hotelempmail`, `hotelname`, `checkin`, `checkout`, `days`, `roomtype`, `totalcost`, `status`) VALUES
(8, 't@gmail.com', 'h@gmail.com', 'hotel sea crown', 'Sat Nov 30 2019 06:00:00 GMT+0600 (Bangladesh Standard Time)', 'Tue Dec 03 2019 06:00:00 GMT+0600 (Bangladesh Standard Time)', '3', 'single bed room-bdt 500', '1500', 'cancelled'),
(9, 't@gmail.com', 'h@gmail.com', 'hotel sea crown', 'Tue Nov 05 2019 06:00:00 GMT+0600 (Bangladesh Standard Time)', 'Fri Nov 08 2019 06:00:00 GMT+0600 (Bangladesh Standard Time)', '3', ' double bed room-bdt 900', '2700', 'successful'),
(10, 't@gmail.com', 'h3@gmail.com', 'hotel coxs crown', 'Tue Nov 05 2019 06:00:00 GMT+0600 (Bangladesh Standard Time)', 'Wed Nov 06 2019 06:00:00 GMT+0600 (Bangladesh Standard Time)', '1', 'single bed room-bdt 500', '500', 'requested');

-- --------------------------------------------------------

--
-- Table structure for table `customercaresalary`
--

CREATE TABLE `customercaresalary` (
  `id` int(20) NOT NULL,
  `custcaremail` varchar(50) DEFAULT NULL,
  `previoussalary` varchar(50) DEFAULT NULL,
  `currentsalary` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customercaresalary`
--

INSERT INTO `customercaresalary` (`id`, `custcaremail`, `previoussalary`, `currentsalary`) VALUES
(9, 'c1@gmail.com', '30000', '40000'),
(10, 'c2@gmail.com', '15000', '20000');

-- --------------------------------------------------------

--
-- Table structure for table `hotelinfo`
--

CREATE TABLE `hotelinfo` (
  `id` int(20) NOT NULL,
  `hotelempmail` varchar(50) DEFAULT NULL,
  `hotelname` varchar(50) DEFAULT NULL,
  `division` varchar(20) DEFAULT NULL,
  `location` varchar(250) DEFAULT NULL,
  `totalroom` varchar(20) DEFAULT NULL,
  `roomtypes` varchar(30000) DEFAULT NULL,
  `description` varchar(2000) DEFAULT NULL,
  `pictures` varchar(40) DEFAULT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `messagetocare`
--

CREATE TABLE `messagetocare` (
  `id` int(20) NOT NULL,
  `sendto` varchar(50) DEFAULT NULL,
  `message` varchar(50000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `messagetocare`
--

INSERT INTO `messagetocare` (`id`, `sendto`, `message`) VALUES
(3, 'c1@gmail.com', 'this is for c1'),
(4, 'c2@gmail.com', 'this is for c2'),
(5, 'c1@gmail.com', 'this is for c1'),
(6, 'c2@gmail.com', 'this is for c2');

-- --------------------------------------------------------

--
-- Table structure for table `messagetohotel`
--

CREATE TABLE `messagetohotel` (
  `id` int(20) NOT NULL,
  `msgfrom` varchar(50) DEFAULT NULL,
  `msgto` varchar(50) DEFAULT NULL,
  `msg` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `messagetohotel`
--

INSERT INTO `messagetohotel` (`id`, `msgfrom`, `msgto`, `msg`) VALUES
(3, 't@gmail.com', 'h@gmail.com', 'this is for t');

-- --------------------------------------------------------

--
-- Table structure for table `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `salarysheet`
--

CREATE TABLE `salarysheet` (
  `id` int(20) NOT NULL,
  `custcaremail` varchar(50) DEFAULT NULL,
  `salarypaid` varchar(50) DEFAULT NULL,
  `paidmonth` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `salarysheet`
--

INSERT INTO `salarysheet` (`id`, `custcaremail`, `salarypaid`, `paidmonth`) VALUES
(5, 'c1@gmail.com', '25000', 'January');

-- --------------------------------------------------------

--
-- Table structure for table `servicecharge`
--

CREATE TABLE `servicecharge` (
  `id` int(20) NOT NULL,
  `usermail` varchar(50) DEFAULT NULL,
  `paidmonth` varchar(20) DEFAULT NULL,
  `amount` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `servicecharge`
--

INSERT INTO `servicecharge` (`id`, `usermail`, `paidmonth`, `amount`) VALUES
(1, 'h@gmail.com', 'January', '1500'),
(2, 'h@gmail.com', 'February', '2500'),
(3, 'h@gmail.com', 'March', '4000');

-- --------------------------------------------------------

--
-- Table structure for table `travelplace`
--

CREATE TABLE `travelplace` (
  `id` int(20) NOT NULL,
  `travelplace` varchar(50) DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,
  `division` varchar(20) DEFAULT NULL,
  `description` varchar(1234) DEFAULT NULL,
  `travelguidermail` varchar(50) DEFAULT NULL,
  `pictures` varchar(30) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `travelplace`
--

INSERT INTO `travelplace` (`id`, `travelplace`, `location`, `division`, `description`, `travelguidermail`, `pictures`, `status`) VALUES
(7, 'jaflong', 'Gowainghat Upazila of Sylhet District', 'sylhet', 'a beautiful place', 'g@gmail.com', 'jaflong', 'pending'),
(8, 'tangoar haor', 'Tangoar Haor, Sunamgonj', 'sylhet', 'a beautiful haor', 'g@gmail.com', 'tangoar haor', 'pending'),
(9, 'coxs bazar', 'Coxs Bazar', 'chittagong', 'Coxs Bazar, the most attractive tourist spots for Bangladesh and not only for Bangladesh its the longest sea beach in the world ', 'g@gmail.com', 'coxs bazar', 'pending'),
(10, 'Nilgiri Mountains', 'Bandarban Bangladesh', 'chittagong', 'Everybody should visit Nilgiri for enjoying its scenic beauty.', 'g@gmail.com', 'Nilgiri Mountains', 'pending');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(20) NOT NULL,
  `usermail` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `usertype` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `usermail`, `password`, `usertype`) VALUES
(1, 'admin@admin.com', 'admin', 'admin'),
(7, 't2@gmail.com', 'tytyty2', 'Traveller'),
(9, 'h@gmail.com', 'hjhjhj1', 'Hotel Emp'),
(11, 'c1@gmail.com', 'cvcvcv1', 'customercare'),
(12, 'c2@gmail.com', 'cvcvcv2', 'customercare'),
(13, 'g@gmail.com', 'ghghgh1', 'Travel guider'),
(14, 't@gmail.com', 'tytyty1', 'Traveller'),
(15, 'h2@gmail.com', 'hjhjhj2', 'Hotel Emp'),
(16, 'h3@gmail.com', 'hjhjhj3', 'Hotel Emp'),
(19, 'h4@gmail.com', 'hjhjhj4', 'Hotel Emp');

-- --------------------------------------------------------

--
-- Table structure for table `userinfo`
--

CREATE TABLE `userinfo` (
  `id` int(20) NOT NULL,
  `firstname` varchar(50) DEFAULT NULL,
  `lastname` varchar(50) DEFAULT NULL,
  `usermail` varchar(70) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `usertype` varchar(20) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phoneno` varchar(30) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `userinfo`
--

INSERT INTO `userinfo` (`id`, `firstname`, `lastname`, `usermail`, `password`, `usertype`, `address`, `phoneno`, `status`) VALUES
(1, 'faf', 'ada', 'admin@admin.com', 'admin', 'admin', 'cssghdfh', '24324', NULL),
(6, 'tfirst', 'tl1', 't@gmail.com', 'tytyty1', 'Traveller', 'tadd', '012365', 'permitted'),
(7, 'tf2', 'tl2', 't2@gmail.com', 'tytyty2', 'Traveller', 'tadd', '9999', 'permitted'),
(9, 'hf1', 'hl1', 'h@gmail.com', 'hjhjhj1', 'Hotel Emp', 'hadd', '01478', 'permitted'),
(11, 'cf1', 'cl1', 'c1@gmail.com', 'cvcvcv1', 'customercare', 'c1add', '01212', 'permitted'),
(12, 'cf2', 'cl2', 'c2@gmail.com', 'cvcvcv2', 'customercare', 'c2add', '012123', 'permitted'),
(13, 'gfirst', 'glas', 'g@gmail.com', 'ghghgh1', 'Travel guider', 'guideraddress', '0123', 'restricted'),
(14, 'hf2', 'hl2', 'h2@gmail.com', 'hjhjhj2', 'Hotel Emp', 'h2 address', '0147852', 'permitted'),
(15, 'hf3', 'hl3', 'h2@gmail.com', 'hjhjhj3', 'Hotel Emp', 'h3 address', '0123654', 'permitted'),
(18, 'hf4', 'hl4', 'h4@gmail.com', 'hjhjhj4', 'Hotel Emp', 'h4 address', '01478', 'permitted');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bookinginfo`
--
ALTER TABLE `bookinginfo`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `customercaresalary`
--
ALTER TABLE `customercaresalary`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `hotelinfo`
--
ALTER TABLE `hotelinfo`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `messagetocare`
--
ALTER TABLE `messagetocare`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `messagetohotel`
--
ALTER TABLE `messagetohotel`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `salarysheet`
--
ALTER TABLE `salarysheet`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `servicecharge`
--
ALTER TABLE `servicecharge`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `travelplace`
--
ALTER TABLE `travelplace`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `userinfo`
--
ALTER TABLE `userinfo`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bookinginfo`
--
ALTER TABLE `bookinginfo`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `customercaresalary`
--
ALTER TABLE `customercaresalary`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `hotelinfo`
--
ALTER TABLE `hotelinfo`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `messagetocare`
--
ALTER TABLE `messagetocare`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `messagetohotel`
--
ALTER TABLE `messagetohotel`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `salarysheet`
--
ALTER TABLE `salarysheet`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `servicecharge`
--
ALTER TABLE `servicecharge`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `travelplace`
--
ALTER TABLE `travelplace`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `userinfo`
--
ALTER TABLE `userinfo`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
