CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
ALTER TABLE accounts ADD coverImg varchar(255) COMMENT 'Cover Image';

CREATE TABLE IF NOT EXISTS keep(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(100) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(255) NOT NULL,
  views INT NOT NULL,
  kept INT COMMENT 'Kept or saved ID',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';
ALTER TABLE keep ADD kept INT COMMENT 'Kept or saved ID';

CREATE TABLE IF NOT EXISTS vault(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL, 
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(255) NOT NULL,
  isPrivate BOOLEAN NOT NULL DEFAULT false,

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vaultKeep(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  vaultId INT NOT NULL,
  keepId INT NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vault(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keep(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';


            SELECT 
            kp.*,
            vk.*,
            act.*
            FROM vaultKeep vk
            JOIN keep kp ON vk.keepId = kp.id
            JOIN accounts act ON kp.creatorId = act.id
            WHERE vk.vaultId = 216;

            SELECT
            *
            FROM `vaultKeep`