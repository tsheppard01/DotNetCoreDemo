CREATE DATABASE DemoApplication
GO
USE master
GO
CREATE LOGIN webAppUser WITH PASSWORD='SecureAF!', DEFAULT_DATABASE=DemoApplication
GO
ALTER LOGIN webAppUser ENABLE
GO
USE DemoApplication
GO
CREATE USER webAppUser FOR LOGIN webAppUser
EXEC sp_addrolemember 'db_owner', 'webAppUser'
GO
