SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

CREATE TABLE `images` (
  `imagesId` int(11) NOT NULL,
  `imagesUser` int(11) NOT NULL,
  `imagesName` varchar(128) NOT NULL,
  `imagesImage` mediumblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `projects` (
  `projectsId` int(11) NOT NULL,
  `projectsUser` int(11) NOT NULL,
  `projectsName` varchar(128) NOT NULL,
  `projectsWidth` int(11) NOT NULL,
  `projectsHeight` int(11) NOT NULL,
  `projectsSelSym` varchar(1) NOT NULL,
  `projectsContent` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `users` (
  `UsersID` int(11) NOT NULL,
  `UsersName` varchar(128) NOT NULL,
  `UsersEmail` varchar(128) NOT NULL,
  `UsersPwd` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `users` (`UsersID`, `UsersName`, `UsersEmail`, `UsersPwd`) VALUES
(1, 'simeongmilev432', 'simeongmilev432@gmail.com', '$2y$10$ilvS3rmN1/NlJ8mBnTfFJeT5z8Xe5IWnQCmDKZq6d0Ig72qNxra5W'),
(2, 'asd', 'leothebackgroundsheep@gmail.com', '$2y$10$jeJha5dp6R18rq5i3utjPe/XwU.GEdwAG9Er0XQbNAkO8vJWpcX4u'),
(3, 'a', 'wew@rewr.com', '$2y$10$wOZUDN1qiqTbNeOiPAUn5uqkAs99YAUk1jzKr.RaQhxGHXumWDlLe'),
(4, 'fd', 'as@ss.com', '$2y$10$ijBC3f2otk1fGZeCCx3lDucOtNY/8B8OSZ6wjewA2YFV1utUFt8/.'),
(5, 'f', 's@d.p', '$2y$10$.BnWhjvoQhtct59Ym0aNOe0O47WiaLeYFSV3qe/abosyKgFuHbldm'),
(6, 's', 's@d.s', '$2y$10$rlJPU5XxB9OqionGDjg3sONeaP74pL/yu8vz71pqu7B8BtXAWS2wi'),
(7, 'dd', 'sa@d.s', '$2y$10$SX20Dh3cqUtn2Bh0Z1u9suNvGzHA.Wa6SQiHxT8qRwArP53BTdpwi');

ALTER TABLE `images`
  ADD PRIMARY KEY (`imagesId`)
;
ALTER TABLE `projects`
  ADD PRIMARY KEY (`projectsId`);

ALTER TABLE `users`
  ADD PRIMARY KEY (`UsersID`);

ALTER TABLE `images`
  MODIFY `imagesId` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `projects`
  MODIFY `projectsId` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `users`
  MODIFY `UsersID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

