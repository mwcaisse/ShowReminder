CREATE TABLE SHOW_REMINDER_DEV.SHOW (
  ID BIGINT NOT NULL AUTO_INCREMENT,
  TVDB_ID BIGINT NOT NULL,
  NAME VARCHAR(250) NOT NULL,
  FIRST_AIRED_DATE DATETIME NULL,
  AIR_DAY VARCHAR(50) NULL,
  AIR_TIME VARCHAR(50) NULL,
  
  LAST_EPISODE_DATE DATETIME NULL,
  NEXT_EPISODE_DATE DATETIME NULL,
  
  CREATE_DATE DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
  UPDATE_DATE DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  
  PRIMARY KEY (ID)
);  
  