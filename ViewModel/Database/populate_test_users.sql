-- SQL Script to populate Course4U database with test users
-- This script creates test student and teacher accounts for testing login functionality

-- =============================================
-- IMPORTANT: Run this script in Microsoft Access
-- File -> Open -> Course4U.accdb
-- Create -> Query Design -> SQL View -> Paste this script -> Run
-- =============================================

-- First, let's insert a test user for a STUDENT
-- Note: Execute these statements ONE AT A TIME in Access

-- Insert User record for Student
INSERT INTO UserTbl (FirstName, LastName, Email, Password, BirthDate, Gender, PhoneNumber)
VALUES ('John', 'Doe', 'student@test.com', '123', #1/1/2005#, 'Male', '0501234567');

-- Get the ID of the user we just created (should be 1 if this is the first record)
-- Insert Student record with the same ID
INSERT INTO StudentTbl (ID, ParentPhoneNumber)
VALUES (1, '0509876543');

-- =============================================

-- Insert User record for another Student (Liel - mentioned in the error message)
INSERT INTO UserTbl (FirstName, LastName, Email, Password, BirthDate, Gender, PhoneNumber)
VALUES ('Liel', 'Cohen', 'liel', '123', #1/1/2006#, 'Female', '0505555555');

-- Insert Student record for Liel (assuming ID will be 2)
INSERT INTO StudentTbl (ID, ParentPhoneNumber)
VALUES (2, '0501111111');

-- =============================================

-- Insert User record for a TEACHER
INSERT INTO UserTbl (FirstName, LastName, Email, Password, BirthDate, Gender, PhoneNumber)
VALUES ('Sarah', 'Williams', 'teacher@test.com', '123', #5/15/1985#, 'Female', '0507777777');

-- Insert Teacher record (assuming ID will be 3)
INSERT INTO TeacherTbl (ID, Salary, TeachingCourseID)
VALUES (3, 10000, NULL);

-- =============================================
-- ALTERNATIVE: If you need to clear existing data first
-- =============================================

-- WARNING: These DELETE statements will remove ALL users!
-- Only run these if you want to start fresh

-- DELETE FROM StudentTbl;
-- DELETE FROM TeacherTbl;
-- DELETE FROM UserTbl;

-- After deleting, you can run the INSERT statements above

-- =============================================
-- VERIFICATION: Check what's in the database
-- =============================================

-- View all users
-- SELECT * FROM UserTbl;

-- View all students
-- SELECT UserTbl.*, StudentTbl.* 
-- FROM UserTbl INNER JOIN StudentTbl ON UserTbl.ID = StudentTbl.ID;

-- View all teachers  
-- SELECT UserTbl.*, TeacherTbl.* 
-- FROM UserTbl INNER JOIN TeacherTbl ON UserTbl.ID = TeacherTbl.ID;

-- =============================================
-- TEST CREDENTIALS
-- =============================================
-- After running this script, you can login with:
--
-- STUDENT 1:
--   Email: student@test.com
--   Password: 123
--
-- STUDENT 2 (Liel):
--   Email: liel
--   Password: 123
--
-- TEACHER:
--   Email: teacher@test.com
--   Password: 123
-- =============================================
