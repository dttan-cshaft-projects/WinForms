# WinForms
Windows Forms

# create table accounts
CREATE TABLE `accounts` (
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
# insert rows
INSERT INTO `accounts` VALUES ('tandoan','123456');

# Create table students
CREATE TABLE `students` (
  `id` int NOT NULL AUTO_INCREMENT,
  `student_name` varchar(45) DEFAULT NULL,
  `student_age` varchar(45) DEFAULT NULL,
  `student_address` varchar(45) DEFAULT NULL,
  `student_semester` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
